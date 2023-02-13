using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Migrations;
using Model;

namespace Entity_Framework;


[Table("Champion")]
public class ChampionEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Icon { get; set; }
    public string Bio { get; set; }
    public string Image { get; set; }
    public string Class { get; set; }
    public ICollection<SkinEntity> Skins { get; set; } = new List<SkinEntity>();
}

