using Location.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Location.Microservice.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RegionController : ControllerBase
{
    private readonly IRegionService _regionService;

    public RegionController(IRegionService regionService)
    {
        _regionService = regionService;
    }

    [HttpPost("GetRegionsByNames")]
    public async Task<IActionResult> GetRegionsByNamesAsync([FromBody] ICollection<string> regionName)
    {
        var regions = await _regionService.GetRegionsByNamesAsync(regionName);

        return Ok(regions);
    }

    [HttpGet("GetRegionByCountryIso2Code")]
    public async Task<IActionResult> GetRegionByCountryIso2CodeAsync([FromQuery] string countryIso2Code)
    {
        var region = await _regionService.GetRegionByCountryIso2CodeAsync(countryIso2Code);

        return Ok(region);
    }
}
