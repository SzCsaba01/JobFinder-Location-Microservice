using Location.Data.Access.Helpers.DTO.CountryStateCity;
using Location.Data.Object.Entities;

namespace Location.Data.Contracts;
public interface ICityRepository
{
    public Task<List<CityEntity>> GetCitiesByCityNameAsync(string cityName);
    public Task<List<CityEntity>> GetCitiesByNamesAsync(ICollection<string> cityNames);
    public Task<List<CityEntity>> GetCitiesByStateAndCityNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos);
    public Task<List<CityEntity>> GetCitiesByCityAndCountryNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos);
    public Task<List<CityEntity>> GetCitiesByCountryAndStateAndCityNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos);
}
