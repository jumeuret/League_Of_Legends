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
    /// <summary>
    /// Classe correspondant à un cCampion, elle sert à transférer des données entre l'API et l'application cliente
    /// Elle permet de limiter les données échangées en ne renvoyant que les informations utiles au client
    /// </summary>
    public class ChampionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        
        public string Class { get; set; }
        public string Icon { get; set; }
        
        public string Image { get; set; }
        
        //public Dictionary<string, int> Characteristics { get; set; }
        //public Collection<Skin> Skins { get; set; }
        //public IEnumerable<Skill> Skills { get; set; }

        public ChampionDTO(int Id, string Name, string Bio, string Class, string Icon, string Image)
        {
            this.Id = Id;
            this.Name = Name;
            this.Bio = Bio;
            this.Class = Class;
            this.Icon = Icon;
            this.Image = Image;
        }

    }
}
