using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class RunePageEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RuneEntity> Runes { get; set; } = new List<RuneEntity>();
    }
}
