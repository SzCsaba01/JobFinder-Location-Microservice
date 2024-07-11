using Location.Data.Access.Helpers.DTO.CountryStateCity;
using Location.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Location.Microservice.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpPost("GetCitiesByNames")]
    public async Task<IActionResult> GetCitiesByNamesAsync([FromBody] ICollection<string> cityName)
    {
        var cities = await _cityService.GetCitiesByNamesAsync(cityName);
        return Ok(cities);
    }

    [HttpPost("GetCitiesByStateAndCityNames")]
    public async Task<IActionResult> GetCitiesByStateAndCityNamesAsync([FromBody] ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos)
    {
        var cities = await _cityService.GetCitiesByStateAndCityNamesAsync(countryStateCityRegionDtos);
        return Ok(cities);
    }

    [HttpPost("GetCitiesByCountryAndStateAndCityNames")]
    public async Task<IActionResult> GetCitiesByCountryAndStateAndCityNamesAsync([FromBody] ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos)
    {
        var cities = await _cityService.GetCitiesByCountryAndStateAndCityNamesAsync(countryStateCityRegionDtos);
        return Ok(cities);
    }

    [HttpPost("GetCitiesByCityAndCountryNames")]
    public async Task<IActionResult> GetCitiesByCountryAndCityNamesAsync([FromBody] ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos)
    {
        var cities = await _cityService.GetCitiesByCityAndCountryNamesAsync(countryStateCityRegionDtos);
        return Ok(cities);
    }
}
