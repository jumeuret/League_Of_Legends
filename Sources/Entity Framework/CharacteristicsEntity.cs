using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework;

[Table("Characteristics")]
public class CharacteristicsEntity
{
    [Key]
    public string Nom { get; set; }
    public int Niveau { get; set; }
}