using FlagExplorer.Application.DTO;
using FlagExplorer.Application.Interfaces;
using FlagExplorer.Application.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FlagExplorer.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("countries")]
        [SwaggerOperation(Summary = "Retrieve all countries", Description = "A list of countries")]
        public async Task<List<CountryDetailsDto>> GetAllCountries(CancellationToken cancellationToken = default)
        {
            return await _countryService.GetAllCountries(cancellationToken);
        }

        [HttpGet("countries/{name}")]
        [SwaggerOperation(Summary = "Get country information", Description = "The name of the country")]
        public async Task<ActionResult> getCountryByName([FromRoute] string name, CancellationToken cancellationToken = default)
        {
            var country = new CountryDTO() { Name = name }; 
            var validator = new CountryValidator();
            var result = validator.Validate(country);

            if(!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            return Ok(await _countryService.SearchByName(country, cancellationToken));
        }
    }

}
