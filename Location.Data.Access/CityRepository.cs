using Location.Data.Access.Data;
using Location.Data.Access.Helpers.DTO.CountryStateCity;
using Location.Data.Contracts;
using Location.Data.Object.Entities;
using Microsoft.EntityFrameworkCore;

namespace Location.Data.Access;
public class CityRepository : ICityRepository
{
    private readonly DataContext _dataContext;

    public CityRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<CityEntity>> GetCitiesByCityNameAsync(string cityName)
    {
        return await _dataContext.Cities
            .Where(city => city.Name.Contains(cityName))
            .Take(10)
            .Include(city => city.State)
                .ThenInclude(state => state.Country)
                    .ThenInclude(country => country.Region)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<CityEntity>> GetCitiesByNamesAsync(ICollection<string> cityNames)
    {
        return await _dataContext.Cities
            .Where(city => cityNames.Contains(city.Name))
            .Include(city => city.State)
                .ThenInclude(state => state.Country)
                    .ThenInclude(country => country.Region)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<CityEntity>> GetCitiesByStateAndCityNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos)
    {
        var cityNames = countryStateCityRegionDtos.Select(x => x.City).ToList();

        var cities = await _dataContext.Cities
            .Where(city => cityNames.Contains(city.Name))
            .Include(city => city.State)
                .ThenInclude(state => state.Country)
                    .ThenInclude(country => country.Region)
            .AsNoTracking()
            .ToListAsync();

        return cities
            .Where(city => countryStateCityRegionDtos.Any(entity =>
                            entity.State == city.State.Name || entity.State == city.State.StateCode))
            .ToList();
    }

    public async Task<List<CityEntity>> GetCitiesByCityAndCountryNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos)
    {
        var cityNames = countryStateCityRegionDtos.Select(x => x.City).ToList();
        
        var cities = await _dataContext.Cities
            .Where(city => cityNames.Contains(city.Name))
            .Include(city => city.State)
                .ThenInclude(state => state.Country)
                    .ThenInclude(country => country.Region)
            .AsNoTracking()
            .ToListAsync();

        return cities
            .Where(city => countryStateCityRegionDtos.Any(entity =>
                            (entity.Country == city.State.Country.Name || entity.Country == city.State.Country.Iso2Code ||
                            entity.Country == city.State.Country.Iso3Code)))
            .ToList();
    }

    public async Task<List<CityEntity>> GetCitiesByCountryAndStateAndCityNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos)
    {
        var citieNames = countryStateCityRegionDtos.Select(x => x.City).ToList();

        var cities = await _dataContext.Cities
            .Where(city => citieNames.Contains(city.Name))
            .Include(city => city.State)
                .ThenInclude(state => state.Country)
                    .ThenInclude(country => country.Region)
            .AsNoTracking()
            .ToListAsync();

        return cities
            .Where(city => countryStateCityRegionDtos.Any(entity =>
                           (entity.Country == city.State.Country.Name || entity.Country == city.State.Country.Iso2Code ||
                            entity.Country == city.State.Country.Iso3Code) &&
                            (entity.State == city.State.Name || entity.State == city.State.StateCode)))
            .ToList();
    }

}
