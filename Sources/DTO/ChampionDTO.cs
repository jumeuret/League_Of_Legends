using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChampionDTO
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Icon { get; set; }

        public ChampionDTO(string Name, string Bio, string Icon)
        {
            this.Name = Name;
            this.Bio = Bio;
            this.Icon = Icon;
        }

    }
}
