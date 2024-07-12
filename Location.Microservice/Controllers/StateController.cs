using Location.Data.Access.Helpers.DTO.CountryStateCity;
using Location.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Location.Microservice.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StateController : ControllerBase
{
    private readonly IStateService _stateService;

    public StateController(IStateService stateService)
    {
        _stateService = stateService;
    }

    [HttpPost("GetStatesByNames")]
    public async Task<IActionResult> GetStatesByNamesAsync([FromBody] ICollection<string> stateNames)
    {
        var states = await _stateService.GetStatesByNamesAsync(stateNames);
        return Ok(states);
    }

    [HttpPost("GetCountryStateCityRegionByNames")]
    public async Task<IActionResult> GetStateByRegionAndStateNameAsync([FromBody] ICollection<CountryStateCityRegionDto> countryStateCityRegionDto)
    {
        var state = await _stateService.GetStatesByCountryAndStateNamesAsync(countryStateCityRegionDto);
        return Ok(state);
    }
}
