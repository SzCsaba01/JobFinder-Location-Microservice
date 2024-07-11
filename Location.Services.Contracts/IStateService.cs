using Location.Data.Access.Helpers.DTO.City;
using Location.Data.Access.Helpers.DTO.CountryStateCity;

namespace Location.Services.Contracts;
public interface IStateService
{
    public Task<List<LocationDto>> GetStatesByNamesAsync(ICollection<string> stateName);
    public Task<List<LocationDto>> GetStatesByCountryAndStateNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos);
}
