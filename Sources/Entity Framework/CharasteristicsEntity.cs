using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework;

[Table("Characteristics")]
public class CharasteristicsEntity
{
    [Key]
    public string nom { get; set; }
    [Required]
    public int niveau { get; set; }
}