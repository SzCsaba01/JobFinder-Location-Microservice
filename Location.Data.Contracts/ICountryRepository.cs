using Location.Data.Access.Helpers.DTO.CountryStateCity;
using Location.Data.Object.Entities;

namespace Location.Data.Contracts;
public interface ICountryRepository
{
    public Task<List<CountryEntity>> GetCountriesByCountryNameAsync(string countryName);
    public Task<List<CountryEntity>> GetCountriesByNamesAsync(ICollection<string> countryNames);
    public Task<List<CountryEntity>> GetCountryByRegionAndCountryNameAsync(CountryStateCityRegionDto countryStateCityRegionDto);
}
