using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models.Requests;
using ApplicationCore.Models.Results;

namespace ApplicationCore.Interfaces
{
    public interface IAthleteService
    {
        Task RegisterNew(RegisterAthleteRequest request);
        Task<IEnumerable<AthleteOverview>> ListAll();
        Task<AthleteDetails> GetDetails(Guid id);
    }
}
