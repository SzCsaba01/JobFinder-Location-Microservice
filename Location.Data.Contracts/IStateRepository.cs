using Location.Data.Access.Helpers.DTO.CountryStateCity;
using Location.Data.Object.Entities;

namespace Location.Data.Contracts;
public interface IStateRepository
{
    public Task<List<StateEntity>> GetStatesByStateNameAsync(string stateName);
    public Task<List<StateEntity>> GetStatesByNamesAsync(ICollection<string> stateNames);
    public Task<List<StateEntity>> GetStatesByCountryAndStateNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionEntities);
}
