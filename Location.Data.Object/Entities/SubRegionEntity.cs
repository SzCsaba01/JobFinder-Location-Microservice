using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Location.Data.Object.Entities;

[Table("SubRegions")]
[Index(nameof(Name))]
public class SubRegionEntity
{
    [Key]
    public int Id { get; set; }

    public int? RegionId { get; set; }

    public int? CountryId { get; set; }

    [Required]
    public string Name { get; set; }

    public CountryEntity? Country { get; set; }

    public RegionEntity? Region { get; set; }
}
