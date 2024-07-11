using Location.Data.Access.Helpers.DTO.City;

namespace Location.Services.Contracts;
public interface IRegionService
{
    public Task<List<LocationDto>> GetRegionsByNamesAsync(ICollection<string> regionName);
    public Task<string> GetRegionByCountryIso2CodeAsync(string countryIso2Code);
}
