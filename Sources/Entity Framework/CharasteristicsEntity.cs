using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework;

[Table("Characteristics")]
public class CharasteristicsEntity
{
    [Key]
    public string nom { get; set; }
    public int niveau { get; set; }
}