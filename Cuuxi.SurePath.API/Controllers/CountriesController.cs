using Cuuxi.SurePath.API.BLL;
using Cuuxi.SurePath.DAL.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Cuuxi.SurePath.API.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly Connector _connector;

        public CountriesController(Connector connector)
        {
            _connector = connector;
        }

        [HttpGet]
        public async Task<ActionResult<List<CountryDto>>> GetAllAsync()
        {
            var countries = await _connector.Users.GetCountriesAsync();
            return Ok(countries);
        }
    }
}
