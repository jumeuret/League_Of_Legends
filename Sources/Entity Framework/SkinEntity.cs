using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity_Framework;
using Model;

namespace Entity_Framework;

/// <summary>
/// Classe correspondant à une entité skin
/// </summary>
[Table("Skin")]
public class SkinEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    [Required]
    public float Price { get; set; }
    
    public ChampionEntity ChampionEntity { get; set; }

    public override string ToString()
    {
        return $"{Id}: {Name} {Description}, {Icon} {Image}, {Price}";
    }
}