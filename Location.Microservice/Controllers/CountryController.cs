using Location.Data.Access.Helpers.DTO.CountryStateCity;
using Location.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Location.Microservice.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpPost("GetCountriesByNames")]
    public async Task<IActionResult> GetCountriesByNamesAsync([FromBody] ICollection<string> countryNames)
    {
        var countries = await _countryService.GetCountriesByNamesAsync(countryNames);
        return Ok(countries);
    }

    [HttpPost("GetCountryByRegionAndCountryName")]
    public async Task<IActionResult> GetCountryByRegionAndCountryNameAsync([FromBody] CountryStateCityRegionDto countryStateCityRegionDto)
    {
        var country = await _countryService.GetCountryByRegionAndCountryNameAsync(countryStateCityRegionDto);
        return Ok(country);
    }

}
