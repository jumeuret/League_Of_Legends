using System.Net.Mime;

namespace API_lol.Mapper
{
    using Model;
    using DTO;
    public static class ChampionMapper
    {

        // Transformer un champion en champion DTO 
        // ex enlever le mot de pass pour pas que le client le récupère
        public static ChampionDTO ToDTO(this Champion champion)
        {
            var championDTO = new ChampionDTO(champion.Name, champion.Bio, champion.Class.ToString(), champion.Icon);
            return championDTO;
        }

        public static Champion FromDTO(this ChampionDTO champDTO)
        {
            var champion = new Champion(champDTO.Name, (ChampionClass)Enum.Parse(typeof(ChampionClass), champDTO.Class), champDTO.Icon, null, champDTO.Bio);
            return champion;
        }
    }
}