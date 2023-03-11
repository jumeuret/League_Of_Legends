using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DTO
{
    public class ChampionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        
        public string Class { get; set; }
        public string Icon { get; set; }
        
        //public string Image { get; set; }
        
        //public Dictionary<string, int> Characteristics { get; set; }
        //public Collection<Skin> Skins { get; set; }
        //public IEnumerable<Skill> Skills { get; set; }

        public ChampionDTO(int Id, string Name, string Bio, string Class, string Icon)
        {
            this.Id = Id;
            this.Name = Name;
            this.Bio = Bio;
            this.Class = Class;
            this.Icon = Icon;
        }

    }
}
