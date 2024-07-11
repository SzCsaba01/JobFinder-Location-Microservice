using Location.Data.Object.Entities;

namespace Location.Data.Contracts;
public interface IRegionRepository
{
    public Task<RegionEntity?> GetRegionByCountryIso2CodeAsync(string countryIso2Code);
    public Task<List<RegionEntity>> GetRegionsByRegionNameAsync(string regionName);
    public Task<List<RegionEntity>> GetRegionsByNames(ICollection<string> regionNames);
}
