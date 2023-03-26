using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity_Framework;

namespace Entity_Framework;

[Table("Characteristic")]
public class CharacteristicsEntity
{
    [Key]
    public string Nom { get; set; }
    public int Niveau { get; set; }
    public ICollection<ChampionEntity> Champions { get; set; }
}