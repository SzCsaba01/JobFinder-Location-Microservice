using Location.Data.Access.Helpers.DTO.City;
using Location.Data.Access.Helpers.DTO.CountryStateCity;

namespace Location.Services.Contracts;
public interface ICityService
{
    public Task<List<LocationDto>> GetCitiesByNamesAsync(ICollection<string> cityName);
    public Task<List<LocationDto>> GetCitiesByStateAndCityNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos);
    public Task<List<LocationDto>> GetCitiesByCityAndCountryNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos);
    public Task<List<LocationDto>> GetCitiesByCountryAndStateAndCityNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos);
}
