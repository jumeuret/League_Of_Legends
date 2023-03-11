using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity_Framework;
using Model;

namespace EntityFramework.Migrations;

[Table("Skins")]
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
    
    public override string ToString()
    {
        return $"{Id}: {Name} {Description}, {Icon} {Image}, {Price}";
    }
}