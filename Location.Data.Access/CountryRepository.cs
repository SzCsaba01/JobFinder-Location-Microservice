using Location.Data.Access.Data;
using Location.Data.Access.Helpers.DTO.CountryStateCity;
using Location.Data.Contracts;
using Location.Data.Object.Entities;
using Microsoft.EntityFrameworkCore;

namespace Location.Data.Access;
public class CountryRepository : ICountryRepository
{
    private readonly DataContext _dataContext;

    public CountryRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<CountryEntity>> GetCountriesByCountryNameAsync(string countryName)
    {
        return await _dataContext.Countries
            .Where(c => c.Name.ToLower().Contains(countryName.ToLower()) || 
                        c.Iso2Code.ToLower().Contains(countryName.ToLower()) || 
                        c.Iso3Code.ToLower().Contains(countryName.ToLower()))
            .Include(c => c.Region)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<CountryEntity>> GetCountriesByNamesAsync(ICollection<string> countryNames)
    {
        return await _dataContext.Countries
            .Where(c => countryNames.Contains(c.Name.ToLower()) || countryNames.Contains(c.Iso2Code.ToLower()) || countryNames.Contains(c.Iso3Code.ToLower()))
            .Include(c => c.Region)
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<List<CountryEntity>> GetCountryByRegionAndCountryNameAsync(CountryStateCityRegionDto countryStateCityRegionDto)
    {
        return _dataContext.Countries
            .Where(c => c.Region.Name == countryStateCityRegionDto.Region && 
                        (c.Name == countryStateCityRegionDto.Country || c.Iso2Code == countryStateCityRegionDto.Country ||
                        c.Iso3Code == countryStateCityRegionDto.Country))
            .Include(c => c.Region)
            .AsNoTracking()
            .ToListAsync();
    }
}
