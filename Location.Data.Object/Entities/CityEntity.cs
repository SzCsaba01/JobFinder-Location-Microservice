using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Location.Data.Object.Entities;

[Table("Cities")]
[Index(nameof(Name))]
public class CityEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int StateId { get; set; }

    public StateEntity State { get; set; }
}
