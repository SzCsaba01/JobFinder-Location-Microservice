using Location.Data.Access.Helpers.DTO.City;
using Location.Data.Access.Helpers.DTO.CountryStateCity;
using Location.Data.Contracts;
using Location.Services.Contracts;

namespace Location.Services.Business;
public class StateService : IStateService
{
    private readonly IStateRepository _stateRepository;

    public StateService(IStateRepository stateRepository)
    {
        _stateRepository = stateRepository;
    }

    public async Task<List<LocationDto>> GetStatesByCountryAndStateNamesAsync(ICollection<CountryStateCityRegionDto> countryStateCityRegionDtos)
    {
        var states = await _stateRepository.GetStatesByCountryAndStateNamesAsync(countryStateCityRegionDtos);

        return states.Select(state => new LocationDto
        {
            StateCode = state.StateCode,
            State = state.Name,
            Country = state.Country.Name,
            CountryIso2Code = state.Country.Iso2Code,
            CountryIso3Code = state.Country.Iso3Code,
            Region = state.Country.Region.Name
        }).ToList();
    }

    public async Task<List<LocationDto>> GetStatesByNamesAsync(ICollection<string> stateName)
    {
        var states = await _stateRepository.GetStatesByNamesAsync(stateName);

        return states.Select(state => new LocationDto
        {
            StateCode = state.StateCode,
            State = state.Name,
            Country = state.Country.Name,
            CountryIso2Code = state.Country.Iso2Code,
            CountryIso3Code = state.Country.Iso3Code,
            Region = state.Country.Region.Name
        }).ToList();
    }
}
