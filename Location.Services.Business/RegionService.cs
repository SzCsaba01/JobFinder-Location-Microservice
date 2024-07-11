using Location.Data.Access.Helpers.DTO.City;
using Location.Data.Contracts;
using Location.Services.Contracts;

namespace Location.Services.Business;
public class RegionService : IRegionService
{
    private readonly IRegionRepository _regionRepository;

    public RegionService(IRegionRepository regionRepository)
    {
        _regionRepository = regionRepository;
    }

    public async Task<List<LocationDto>> GetRegionsByNamesAsync(ICollection<string> regionName)
    {
        var regions = await _regionRepository.GetRegionsByNames(regionName);

        return regions.Select(region => new LocationDto
        {
            Region = region.Name,
        }).ToList();
    }

    public async Task<string> GetRegionByCountryIso2CodeAsync(string countryIso2Code)
    {
        var region = await _regionRepository.GetRegionByCountryIso2CodeAsync(countryIso2Code);

        return region?.Name ?? string.Empty;
    }
}
