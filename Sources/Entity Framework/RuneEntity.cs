using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    [Table("Rune")]
    public class RuneEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Family { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public string Categorie { get; set; }
        public ICollection<RunePageEntity> RunePages { get; set; } = new List<RunePageEntity>();
    }
}
