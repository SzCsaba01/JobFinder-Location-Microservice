using Location.Data.Access.Helpers.DTO.CountryStateCity;
using Location.Data.Contracts;
using Location.Data.Object.Entities;
using Location.Services.Business;
using Moq;
using Xunit;

public class ServiceTests
{
    private readonly Mock<ICityRepository> _cityRepositoryMock;
    private readonly Mock<ICountryRepository> _countryRepositoryMock;
    private readonly Mock<IRegionRepository> _regionRepositoryMock;
    private readonly Mock<IStateRepository> _stateRepositoryMock;

    private readonly CityService _cityService;
    private readonly CountryService _countryService;
    private readonly RegionService _regionService;
    private readonly StateService _stateService;

    public ServiceTests()
    {
        _cityRepositoryMock = new Mock<ICityRepository>();
        _countryRepositoryMock = new Mock<ICountryRepository>();
        _regionRepositoryMock = new Mock<IRegionRepository>();
        _stateRepositoryMock = new Mock<IStateRepository>();

        _cityService = new CityService(_cityRepositoryMock.Object);
        _countryService = new CountryService(_countryRepositoryMock.Object);
        _regionService = new RegionService(_regionRepositoryMock.Object);
        _stateService = new StateService(_stateRepositoryMock.Object);
    }

    [Fact]
    public async Task CityService_GetCitiesByNamesAsync_ReturnsCities()
    {
        var cities = new List<CityEntity>
        {
            new CityEntity
            {
                Name = "City1",
                State = new StateEntity
                {
                    Name = "State1",
                    StateCode = "S1",
                    Country = new CountryEntity
                    {
                        Name = "Country1",
                        Iso2Code = "C1",
                        Iso3Code = "CO1",
                        Region = new RegionEntity { Name = "Region1" }
                    }
                }
            }
        };

        _cityRepositoryMock.Setup(repo => repo.GetCitiesByNamesAsync(It.IsAny<ICollection<string>>())).ReturnsAsync(cities);

        var result = await _cityService.GetCitiesByNamesAsync(new List<string> { "City1" });

        Assert.Single(result);
        Assert.Equal("City1", result.First().City);
    }

    [Fact]
    public async Task CountryService_GetCountriesByNamesAsync_ReturnsCountries()
    {
        var countries = new List<CountryEntity>
        {
            new CountryEntity
            {
                Name = "Country1",
                Iso2Code = "C1",
                Iso3Code = "CO1",
                Region = new RegionEntity { Name = "Region1" }
            }
        };

        _countryRepositoryMock.Setup(repo => repo.GetCountriesByNamesAsync(It.IsAny<ICollection<string>>())).ReturnsAsync(countries);

        var result = await _countryService.GetCountriesByNamesAsync(new List<string> { "Country1" });

        Assert.Single(result);
        Assert.Equal("Country1", result.First().Country);
    }

    [Fact]
    public async Task RegionService_GetRegionsByNamesAsync_ReturnsRegions()
    {
        var regions = new List<RegionEntity>
        {
            new RegionEntity { Name = "Region1" }
        };

        _regionRepositoryMock.Setup(repo => repo.GetRegionsByNames(It.IsAny<ICollection<string>>())).ReturnsAsync(regions);

        var result = await _regionService.GetRegionsByNamesAsync(new List<string> { "Region1" });

        Assert.Single(result);
        Assert.Equal("Region1", result.First().Region);
    }

    [Fact]
    public async Task StateService_GetStatesByNamesAsync_ReturnsStates()
    {
        var states = new List<StateEntity>
        {
            new StateEntity
            {
                Name = "State1",
                StateCode = "S1",
                Country = new CountryEntity
                {
                    Name = "Country1",
                    Iso2Code = "C1",
                    Iso3Code = "CO1",
                    Region = new RegionEntity { Name = "Region1" }
                }
            }
        };

        _stateRepositoryMock.Setup(repo => repo.GetStatesByNamesAsync(It.IsAny<ICollection<string>>())).ReturnsAsync(states);

        var result = await _stateService.GetStatesByNamesAsync(new List<string> { "State1" });

        Assert.Single(result);
        Assert.Equal("State1", result.First().State);
    }

    [Fact]
    public async Task CityService_GetCitiesByStateAndCityNamesAsync_ReturnsCities()
    {
        var cities = new List<CityEntity>
        {
            new CityEntity
            {
                Name = "City1",
                State = new StateEntity
                {
                    Name = "State1",
                    StateCode = "S1",
                    Country = new CountryEntity
                    {
                        Name = "Country1",
                        Iso2Code = "C1",
                        Iso3Code = "CO1",
                        Region = new RegionEntity { Name = "Region1" }
                    }
                }
            }
        };

        _cityRepositoryMock.Setup(repo => repo.GetCitiesByStateAndCityNamesAsync(It.IsAny<ICollection<CountryStateCityRegionDto>>())).ReturnsAsync(cities);

        var result = await _cityService.GetCitiesByStateAndCityNamesAsync(new List<CountryStateCityRegionDto> { new CountryStateCityRegionDto { City = "City1", State = "State1" } });

        Assert.Single(result);
        Assert.Equal("City1", result.First().City);
    }

    [Fact]
    public async Task CityService_GetCitiesByCountryAndStateAndCityNamesAsync_ReturnsCities()
    {
        var cities = new List<CityEntity>
        {
            new CityEntity
            {
                Name = "City1",
                State = new StateEntity
                {
                    Name = "State1",
                    StateCode = "S1",
                    Country = new CountryEntity
                    {
                        Name = "Country1",
                        Iso2Code = "C1",
                        Iso3Code = "CO1",
                        Region = new RegionEntity { Name = "Region1" }
                    }
                }
            }
        };

        _cityRepositoryMock.Setup(repo => repo.GetCitiesByCountryAndStateAndCityNamesAsync(It.IsAny<ICollection<CountryStateCityRegionDto>>())).ReturnsAsync(cities);

        var result = await _cityService.GetCitiesByCountryAndStateAndCityNamesAsync(new List<CountryStateCityRegionDto> { new CountryStateCityRegionDto { City = "City1", State = "State1", Country = "Country1" } });

        Assert.Single(result);
        Assert.Equal("City1", result.First().City);
    }

    [Fact]
    public async Task CityService_GetCitiesByCityAndCountryNamesAsync_ReturnsCities()
    {
        var cities = new List<CityEntity>
        {
            new CityEntity
            {
                Name = "City1",
                State = new StateEntity
                {
                    Name = "State1",
                    StateCode = "S1",
                    Country = new CountryEntity
                    {
                        Name = "Country1",
                        Iso2Code = "C1",
                        Iso3Code = "CO1",
                        Region = new RegionEntity { Name = "Region1" }
                    }
                }
            }
        };

        _cityRepositoryMock.Setup(repo => repo.GetCitiesByCityAndCountryNamesAsync(It.IsAny<ICollection<CountryStateCityRegionDto>>())).ReturnsAsync(cities);

        var result = await _cityService.GetCitiesByCityAndCountryNamesAsync(new List<CountryStateCityRegionDto> { new CountryStateCityRegionDto { City = "City1", Country = "Country1" } });

        Assert.Single(result);
        Assert.Equal("City1", result.First().City);
    }

    [Fact]
    public async Task CountryService_GetCountryByRegionAndCountryNameAsync_ReturnsCountry()
    {
        var countries = new List<CountryEntity>
        {
            new CountryEntity
            {
                Name = "Country1",
                Iso2Code = "C1",
                Iso3Code = "CO1",
                Region = new RegionEntity { Name = "Region1" }
            }
        };

        _countryRepositoryMock.Setup(repo => repo.GetCountryByRegionAndCountryNameAsync(It.IsAny<CountryStateCityRegionDto>())).ReturnsAsync(countries);

        var result = await _countryService.GetCountryByRegionAndCountryNameAsync(new CountryStateCityRegionDto { Country = "Country1", Region = "Region1" });

        Assert.Equal("Country1", result.Country);
    }

    [Fact]
    public async Task RegionService_GetRegionByCountryIso2CodeAsync_ReturnsRegion()
    {
        var region = new RegionEntity { Name = "Region1" };

        _regionRepositoryMock.Setup(repo => repo.GetRegionByCountryIso2CodeAsync(It.IsAny<string>())).ReturnsAsync(region);

        var result = await _regionService.GetRegionByCountryIso2CodeAsync("C1");

        Assert.Equal("Region1", result);
    }

    [Fact]
    public async Task StateService_GetStatesByCountryAndStateNamesAsync_ReturnsStates()
    {
        var states = new List<StateEntity>
        {
            new StateEntity
            {
                Name = "State1",
                StateCode = "S1",
                Country = new CountryEntity
                {
                    Name = "Country1",
                    Iso2Code = "C1",
                    Iso3Code = "CO1",
                    Region = new RegionEntity { Name = "Region1" }
                }
            }
        };

        _stateRepositoryMock.Setup(repo => repo.GetStatesByCountryAndStateNamesAsync(It.IsAny<ICollection<CountryStateCityRegionDto>>())).ReturnsAsync(states);

        var result = await _stateService.GetStatesByCountryAndStateNamesAsync(new List<CountryStateCityRegionDto> { new CountryStateCityRegionDto { State = "State1", Country = "Country1" } });

        Assert.Single(result);
        Assert.Equal("State1", result.First().State);
    }
}
