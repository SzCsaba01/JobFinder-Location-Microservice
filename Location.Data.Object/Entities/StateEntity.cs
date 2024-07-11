using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Location.Data.Object.Entities;

[Table("States")]
[Index(nameof(Name))]
public class StateEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string StateCode { get; set; }

    [Required]
    public int CountryId { get; set; }

    public CountryEntity Country { get; set; }
}
