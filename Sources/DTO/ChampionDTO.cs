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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Icon { get; set; }

        public ChampionDTO(int Id, string Name, string Bio, string Icon)
        {
            this.Id = Id;
            this.Name = Name;
            this.Bio = Bio;
            this.Icon = Icon;
        }

    }
}
