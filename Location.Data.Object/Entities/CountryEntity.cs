using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Location.Data.Object.Entities;

[Table("Countries")]
[Index(nameof(Name), IsUnique = true)]
public class CountryEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Iso2Code { get; set; }

    [Required]
    public string Iso3Code { get; set; }

    public int? RegionId { get; set; }

    public int SubRegionId { get; set; }

    public RegionEntity? Region { get; set; }
    
    public SubRegionEntity? SubRegion { get; set; }
}
