using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using ApplicationCore.Models.Requests;
using ApplicationCore.Models.Results;
using Microsoft.Extensions.Logging;

namespace ApplicationCore.Services
{
    public class AthleteService : IAthleteService
    {
        private readonly IRepository<Athlete> _repository;
        private readonly ILogger<AthleteService> _logger;

        public AthleteService(IRepository<Athlete> repository,
                              ILogger<AthleteService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task RegisterNew(RegisterAthleteRequest request)
        {
            // custom validate
            var newAthelete = Athlete.RegisterNew(request.Name, request.Surname, request.Weight, request.Height);

            await _repository.AddAsync(newAthelete);
            await _repository.SaveChangesAsync();

            _logger.LogInformation("Successfully registered new athlete {$athlete}", newAthelete);
        }
        public async Task<AthleteDetails> GetDetails(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException($"'{nameof(id)}' cannot be null empty", nameof(id));
            }
            var athlete = await _repository.GetByIdAsync(id) ?? throw new ResourceNotExistsException();
            var result = new AthleteDetails
            {
                Name = athlete.Name,
                Surname = athlete.Surname,
                Height = athlete.Height,
                Weight = athlete.Weight
            };
            return result;
        }

        public async Task<IEnumerable<AthleteOverview>> ListAll()
        {
            var athletes = await _repository.ListAsync();
            var result = athletes.Select(x => new AthleteOverview
            {
                Name = x.Name,
                Surname = x.Surname,
                Category = x.Weight switch
                {
                    <= 59f => WeightClass.Men_59,
                    <= 66 => WeightClass.Men_66,
                    <= 74 => WeightClass.Men_74,
                    <= 83 => WeightClass.Men_83,
                    <= 93 => WeightClass.Men_93,
                    <= 105 => WeightClass.Men_105,
                    <= 120 => WeightClass.Men_120,
                    _ => WeightClass.Men_plus,
                }
            });
            return result;
        }

    }
}
