using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework;

[Table("Skill")]
public class SkillEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
}