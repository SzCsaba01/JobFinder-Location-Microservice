using Location.Data.Access.Data;
using Location.Data.Contracts;
using Location.Data.Object.Entities;
using Microsoft.EntityFrameworkCore;

namespace Location.Data.Access;
public class RegionRepository : IRegionRepository
{
    private readonly DataContext _dataContext;

    public RegionRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<RegionEntity?> GetRegionByCountryIso2CodeAsync(string countryIso2Code)
    {
        return await _dataContext.Countries
            .Where(country => country.Iso2Code.ToLower().Equals(countryIso2Code.ToLower()))
            .Include(country => country.Region)
            .Select(country => country.Region)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<List<RegionEntity>> GetRegionsByRegionNameAsync(string regionName)
    {
        return await _dataContext.Regions
            .Where(region => region.Name.ToLower().Contains(regionName.ToLower()))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<RegionEntity>> GetRegionsByNames(ICollection<string> regionNames)
    {
        return await _dataContext.Regions
            .Where(region => regionNames.Contains(region.Name))
            .AsNoTracking() 
            .ToListAsync();
    }
}
