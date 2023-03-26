using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework;

[Table("Skill")]
public class SkillEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public ChampionEntity ChampionEntity { get; set; }
}