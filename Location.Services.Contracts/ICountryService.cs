using Location.Data.Access.Helpers.DTO.City;
using Location.Data.Access.Helpers.DTO.CountryStateCity;

namespace Location.Services.Contracts;
public interface ICountryService
{
    public Task<List<LocationDto>> GetCountriesByNamesAsync(ICollection<string> countryNames);
    public Task<LocationDto> GetCountryByRegionAndCountryNameAsync(CountryStateCityRegionDto countryStateCityRegionDto);
}
