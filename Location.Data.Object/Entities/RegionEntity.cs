using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Location.Data.Object.Entities;

[Table("Regions")]
[Index(nameof(Name), IsUnique = true)]
public class RegionEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<SubRegionEntity>? SubRegion { get; set; }
}
