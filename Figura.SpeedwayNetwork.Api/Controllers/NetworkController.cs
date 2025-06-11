using Figura.SpeedwayNetwork.Model.DAO;
using Figura.SpeedwayNetwork.Service;
using Microsoft.AspNetCore.Mvc;

namespace Figura.SpeedwayNetwork.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NetworkController : Controller
    {
        private readonly INetworkService _service;

        public NetworkController(INetworkService service)
        {
            _service = service;
        }

        [HttpGet("AllCountries")]
        public async Task<List<Country>> FetchAllCountries()
        {
            var res = await _service.GetAllCountries();

            return res;
        }

        [HttpGet("AllNames")]
        public async Task<List<FirstName>> FetchAllNames()
        {
            var res = await _service.GetAllNames();

            return res;
        }

        [HttpPost("FirstName")]
        public async Task<Country> AddCountry([FromBody] Country country)
        {
            var res = await _service.AddCountry(country);

            return res;
        }

        [HttpPost("Country")]
        public async Task<FirstName> AddName([FromBody] FirstName name)
        {
            var res = await _service.AddName(name);

            return res;
        }
    }
}
