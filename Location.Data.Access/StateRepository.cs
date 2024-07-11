using Location.Data.Access.Data;
using Location.Data.Access.Helpers.DTO.CountryStateCity;
using Location.Data.Contracts;
using Location.Data.Object.Entities;
using Microsoft.EntityFrameworkCore;

namespace Location.Data.Access;
public class StateRepository : IStateRepository
{
    private readonly DataContext _dataContext;

    public StateRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<StateEntity>> GetStatesByStateNameAsync(string stateName)
    {
        return await _dataContext.States
            .Where(state => state.Name.ToLower().Contains(stateName) || state.StateCode.ToLower().Contains(stateName))
            .Include(state => state.Country)
                .ThenInclude(country => country.Region)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<StateEntity>> GetStatesByNamesAsync(ICollection<string> stateNames)
    {
        return await _dataContext.States
            .Where(state => stateNames.Contains(state.Name) || stateNames.Contains(state.StateCode))
            .Include(state => state.Country)
                .ThenInclude(country => country.Region)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<StateEntity>> GetStatesByCountryAndStateNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionEntities)
    {
        var stateNames = countryStateCityRegionEntities.Select(x => x.State).ToList();
        
        var states = await _dataContext.States
            .Where(state => stateNames.Contains(state.Name) || stateNames.Contains(state.StateCode))
            .Include(state => state.Country)
                .ThenInclude(country => country.Region)
            .AsNoTracking()
            .ToListAsync();

        return states
            .Where(state => countryStateCityRegionEntities.Any(entity =>
                            entity.Country == state.Country.Name || entity.Country == state.Country.Iso2Code ||
                            entity.Country == state.Country.Iso3Code))
            .ToList();
    }
}
