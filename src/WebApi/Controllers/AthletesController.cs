using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models.Requests;
using ApplicationCore.Models.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthletesController : ControllerBase
    {
        private readonly IAthleteService _athleteService;

        public AthletesController(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAthleteRequest request)
        {
            await _athleteService.RegisterNew(request);
            return Ok();
        }
        [HttpGet]
        public async Task<IEnumerable<AthleteOverview>> ListAll()
        {
            return await _athleteService.ListAll();
        }
    }
}
