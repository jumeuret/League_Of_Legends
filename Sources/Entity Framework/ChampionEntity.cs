using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Migrations;
using Model;

namespace Entity_Framework;

[Table("Champions")]
public class ChampionEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    public string? Icon { get; set; }
    public string Bio { get; set; }
    public string Image { get; set; }
    public string Class { get; set; }
    public ICollection<SkinEntity> Skins { get; set; } = new List<SkinEntity>();
}

