using Location.Data.Access.Helpers.DTO.City;
using Location.Data.Access.Helpers.DTO.CountryStateCity;
using Location.Data.Contracts;
using Location.Services.Contracts;

namespace Location.Services.Business;
public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<List<LocationDto>> GetCountriesByNamesAsync(ICollection<string> countryNames)
    {
        countryNames = countryNames.Select(x => x.ToLower()).ToList();
        var countries = await _countryRepository.GetCountriesByNamesAsync(countryNames);
        
        return countries.Select(country => new LocationDto
        {
            Country = country.Name,
            CountryIso2Code = country.Iso2Code,
            CountryIso3Code = country.Iso3Code,
            Region = country.Region.Name,
        }).ToList();
    }

    public async Task<LocationDto> GetCountryByRegionAndCountryNameAsync(CountryStateCityRegionDto countryStateCityRegionDto)
    {
        var country = await _countryRepository.GetCountryByRegionAndCountryNameAsync(countryStateCityRegionDto);

        return new LocationDto
        {
            Country = country.First().Name,
            CountryIso2Code = country.First().Iso2Code,
            CountryIso3Code = country.First().Iso3Code,
            Region = country.First().Region.Name,
        };

    }
}
