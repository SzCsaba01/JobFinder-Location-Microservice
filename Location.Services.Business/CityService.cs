using Location.Data.Access.Helpers.DTO.City;
using Location.Data.Access.Helpers.DTO.CountryStateCity;
using Location.Data.Contracts;
using Location.Services.Contracts;

namespace Location.Services.Business;
public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<List<LocationDto>> GetCitiesByNamesAsync(ICollection<string> cityName)
    {
        var cityEntities = await _cityRepository.GetCitiesByNamesAsync(cityName);
        return cityEntities.Select(cityEntity => new LocationDto
        {
            City = cityEntity.Name,
            State = cityEntity.State.Name,
            StateCode = cityEntity.State.StateCode,
            Country = cityEntity.State.Country.Name,
            CountryIso2Code = cityEntity.State.Country.Iso2Code,
            CountryIso3Code = cityEntity.State.Country.Iso3Code,
            Region = cityEntity.State.Country.Region.Name,
        }).ToList();
    }

    public async Task<List<LocationDto>> GetCitiesByStateAndCityNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos)
    {
        var cityEntities = await _cityRepository.GetCitiesByStateAndCityNamesAsync(countryStateCityRegionDtos);

        return cityEntities.Select(cityEntity => new LocationDto
        {
            City = cityEntity.Name,
            State = cityEntity.State.Name,
            StateCode = cityEntity.State.StateCode,
            Country = cityEntity.State.Country.Name,
            CountryIso2Code = cityEntity.State.Country.Iso2Code,
            CountryIso3Code = cityEntity.State.Country.Iso3Code,
            Region = cityEntity.State.Country.Region.Name,
        }).ToList();
    }

    public async Task<List<LocationDto>> GetCitiesByCountryAndStateAndCityNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos)
    {
        var cityEntities = await _cityRepository.GetCitiesByCountryAndStateAndCityNamesAsync(countryStateCityRegionDtos);

        return cityEntities.Select(cityEntity => new LocationDto
        {
            City = cityEntity.Name,
            StateCode = cityEntity.State.StateCode,
            State = cityEntity.State.Name,
            Country = cityEntity.State.Country.Name,
            CountryIso2Code = cityEntity.State.Country.Iso2Code,
            CountryIso3Code = cityEntity.State.Country.Iso3Code,
            Region = cityEntity.State.Country.Region.Name,
        }).ToList();
    }

    public async Task<List<LocationDto>> GetCitiesByCityAndCountryNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos)
    {
        var cityEntities = await _cityRepository.GetCitiesByCityAndCountryNamesAsync(countryStateCityRegionDtos);
        
        return cityEntities.Select(cityEntity => new LocationDto
        {
            City = cityEntity.Name,
            State = cityEntity.State.Name,
            StateCode = cityEntity.State.StateCode,
            Country = cityEntity.State.Country.Name,
            CountryIso2Code = cityEntity.State.Country.Iso2Code,
            CountryIso3Code = cityEntity.State.Country.Iso3Code,
            Region = cityEntity.State.Country.Region.Name,
        }).ToList();
    }
}
