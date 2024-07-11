using Location.Data.Access.Data;
using Location.Data.Contracts;
using Location.Data.Object.Entities;
using Microsoft.EntityFrameworkCore;

namespace Location.Data.Access;
public class SubRegionRepository : ISubRegionRepository
{
    private readonly DataContext _dataContext;

    public SubRegionRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<SubRegionEntity>> GetSubRegionsByNames(ICollection<string> subRegionNames)
    {
        return await _dataContext.SubRegions
            .Where(subRegion => subRegionNames.Contains(subRegion.Name))
            .Include(subRegion => subRegion.Region)
            .ToListAsync();
    }
}
