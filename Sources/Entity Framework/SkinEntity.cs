using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Migrations;

[Table("Skin")]
public class SkinEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public string Image { get; set; }
    public float Price { get; set; }
}