using Location.Data.Access;
using Location.Data.Access.Data;
using Location.Data.Access.Helpers.DTO.CountryStateCity;
using Location.Data.Object.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class RepositoryTests
{
    private readonly DbContextOptions<DataContext> _contextOptions;

    public RepositoryTests()
    {
        _contextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
    }


    [Fact]
    public async Task CityRepository_GetCitiesByCityNameAsync_ReturnsCities()
    {
        using var context = new DataContext(_contextOptions);
        context.Cities.Add(new CityEntity
        {
            Name = "TestCity",
            State = new StateEntity
            {
                Name = "TestState",
                StateCode = "TS",
                Country = new CountryEntity
                {
                    Name = "TestCountry",
                    Iso2Code = "TC",
                    Iso3Code = "TCO",
                    Region = new RegionEntity { Name = "TestRegion" }
                }
            }
        });
        await context.SaveChangesAsync();

        var repository = new CityRepository(context);
        var result = await repository.GetCitiesByCityNameAsync("TestCity");

        Assert.Single(result);
        Assert.Equal("TestCity", result.First().Name);
    }

    [Fact]
    public async Task CountryRepository_GetCountriesByCountryNameAsync_ReturnsCountries()
    {
        using var context = new DataContext(_contextOptions);
        context.Countries.Add(new CountryEntity
        {
            Name = "TestCountry",
            Iso2Code = "TC",
            Iso3Code = "TCO",
            Region = new RegionEntity { Name = "TestRegion" }
        });
        await context.SaveChangesAsync();

        var repository = new CountryRepository(context);
        var result = await repository.GetCountriesByCountryNameAsync("TestCountry");

        Assert.Single(result);
        Assert.Equal("TestCountry", result.First().Name);
    }

    [Fact]
    public async Task RegionRepository_GetRegionsByRegionNameAsync_ReturnsRegions()
    {
        using var context = new DataContext(_contextOptions);
        context.Regions.Add(new RegionEntity { Name = "TestRegion" });
        await context.SaveChangesAsync();

        var repository = new RegionRepository(context);
        var result = await repository.GetRegionsByRegionNameAsync("TestRegion");

        Assert.Single(result);
        Assert.Equal("TestRegion", result.First().Name);
    }

    [Fact]
    public async Task StateRepository_GetStatesByStateNameAsync_ReturnsStates()
    {
        using var context = new DataContext(_contextOptions);
        context.States.Add(new StateEntity
        {
            Name = "TestState",
            StateCode = "TS",
            Country = new CountryEntity
            {
                Name = "TestCountry",
                Iso2Code = "TC",
                Iso3Code = "TCO",
                Region = new RegionEntity { Name = "TestRegion" }
            }
        });
        await context.SaveChangesAsync();

        var repository = new StateRepository(context);
        var result = await repository.GetStatesByStateNameAsync("teststate");

        Assert.Single(result);
        Assert.Equal("TestState", result.First().Name);
    }

    [Fact]
    public async Task SubRegionRepository_GetSubRegionsByNames_ReturnsSubRegions()
    {
        using var context = new DataContext(_contextOptions);
        context.SubRegions.Add(new SubRegionEntity { Name = "TestSubRegion", Region = new RegionEntity { Name = "TestRegion" } });
        await context.SaveChangesAsync();

        var repository = new SubRegionRepository(context);
        var result = await repository.GetSubRegionsByNames(new List<string> { "TestSubRegion" });

        Assert.Single(result);
        Assert.Equal("TestSubRegion", result.First().Name);
    }

    [Fact]
    public async Task CityRepository_GetCitiesByNamesAsync_ReturnsCities()
    {
        using var context = new DataContext(_contextOptions);
        context.Cities.Add(new CityEntity
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
        });
        await context.SaveChangesAsync();

        var repository = new CityRepository(context);
        var result = await repository.GetCitiesByNamesAsync(new List<string> { "City1" });

        Assert.Single(result);
        Assert.Equal("City1", result.First().Name);
    }

    [Fact]
    public async Task CountryRepository_GetCountriesByNamesAsync_ReturnsCountries()
    {
        using var context = new DataContext(_contextOptions);
        context.Countries.Add(new CountryEntity
        {
            Name = "Country1",
            Iso2Code = "C1",
            Iso3Code = "CO1",
            Region = new RegionEntity { Name = "Region1" }
        });
        await context.SaveChangesAsync();

        var repository = new CountryRepository(context);
        var result = await repository.GetCountriesByNamesAsync(new List<string> { "country1" });

        Assert.Single(result);
        Assert.Equal("Country1", result.First().Name);
    }

    [Fact]
    public async Task StateRepository_GetStatesByNamesAsync_ReturnsStates()
    {
        using var context = new DataContext(_contextOptions);
        context.States.Add(new StateEntity
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
        });
        await context.SaveChangesAsync();

        var repository = new StateRepository(context);
        var result = await repository.GetStatesByNamesAsync(new List<string> { "State1" });

        Assert.Single(result);
        Assert.Equal("State1", result.First().Name);
    }

    [Fact]
    public async Task RegionRepository_GetRegionsByNames_ReturnsRegions()
    {
        using var context = new DataContext(_contextOptions);
        context.Regions.Add(new RegionEntity { Name = "Region1" });
        await context.SaveChangesAsync();

        var repository = new RegionRepository(context);
        var result = await repository.GetRegionsByNames(new List<string> { "Region1" });

        Assert.Single(result);
        Assert.Equal("Region1", result.First().Name);
    }

    [Fact]
    public async Task CityRepository_GetCitiesByStateAndCityNamesAsync_ReturnsCities()
    {
        using var context = new DataContext(_contextOptions);
        context.Cities.Add(new CityEntity
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
        });
        await context.SaveChangesAsync();

        var repository = new CityRepository(context);
        var result = await repository.GetCitiesByStateAndCityNamesAsync(new List<CountryStateCityRegionDto> { new CountryStateCityRegionDto { City = "City1", State = "State1" } });

        Assert.Single(result);
        Assert.Equal("City1", result.First().Name);
    }

    [Fact]
    public async Task CityRepository_GetCitiesByCityAndCountryNamesAsync_ReturnsCities()
    {
        using var context = new DataContext(_contextOptions);
        context.Cities.Add(new CityEntity
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
        });
        await context.SaveChangesAsync();

        var repository = new CityRepository(context);
        var result = await repository.GetCitiesByCityAndCountryNamesAsync(new List<CountryStateCityRegionDto> { new CountryStateCityRegionDto { City = "City1", Country = "Country1" } });

        Assert.Single(result);
        Assert.Equal("City1", result.First().Name);
    }

    [Fact]
    public async Task CityRepository_GetCitiesByCountryAndStateAndCityNamesAsync_ReturnsCities()
    {
        using var context = new DataContext(_contextOptions);
        context.Cities.Add(new CityEntity
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
        });
        await context.SaveChangesAsync();

        var repository = new CityRepository(context);
        var result = await repository.GetCitiesByCountryAndStateAndCityNamesAsync(new List<CountryStateCityRegionDto> { new CountryStateCityRegionDto { City = "City1", State = "State1", Country = "Country1" } });

        Assert.Single(result);
        Assert.Equal("City1", result.First().Name);
    }

    [Fact]
    public async Task CountryRepository_GetCountryByRegionAndCountryNameAsync_ReturnsCountries()
    {
        using var context = new DataContext(_contextOptions);
        context.Countries.Add(new CountryEntity
        {
            Name = "Country1",
            Iso2Code = "C1",
            Iso3Code = "CO1",
            Region = new RegionEntity { Name = "Region1" }
        });
        await context.SaveChangesAsync();

        var repository = new CountryRepository(context);
        var result = await repository.GetCountryByRegionAndCountryNameAsync(new CountryStateCityRegionDto { Country = "Country1", Region = "Region1" });

        Assert.Single(result);
        Assert.Equal("Country1", result.First().Name);
    }

    [Fact]
    public async Task RegionRepository_GetRegionByCountryIso2CodeAsync_ReturnsRegion()
    {
        using var context = new DataContext(_contextOptions);
        context.Countries.Add(new CountryEntity
        {
            Name = "Country1",
            Iso2Code = "C1",
            Iso3Code = "CO1",
            Region = new RegionEntity { Name = "Region1" }
        });
        await context.SaveChangesAsync();

        var repository = new RegionRepository(context);
        var result = await repository.GetRegionByCountryIso2CodeAsync("C1");

        Assert.NotNull(result);
        Assert.Equal("Region1", result.Name);
    }
}
