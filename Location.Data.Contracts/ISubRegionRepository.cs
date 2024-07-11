using Location.Data.Object.Entities;

namespace Location.Data.Contracts;
public interface ISubRegionRepository
{
    public Task<List<SubRegionEntity>> GetSubRegionsByNames(ICollection<string> subRegionNames);
}
