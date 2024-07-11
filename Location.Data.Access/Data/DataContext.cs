using Location.Data.Object.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Location.Data.Access.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CountryEntity>()
            .HasOne(c => c.SubRegion)
            .WithMany()
            .HasForeignKey(c => c.SubRegionId)
            .OnDelete(DeleteBehavior.NoAction); 
    }

    public DbSet<CityEntity> Cities { get; set; }
    public DbSet<RegionEntity> Regions { get; set; }
    public DbSet<StateEntity> States { get; set; }
    public DbSet<SubRegionEntity> SubRegions { get; set; }
    public DbSet<CountryEntity> Countries { get; set; }
}
