namespace API_lol.Mapper
{
    using Model;
    using DTO;
    public static class ChampionMapper
    {

        // Transformer un champion en champion DTO 
        // ex enlever le mot de passe pour que le client ne le récupère pas
        public static ChampionDTO ToDTO(this Champion champion)
        {
            var championDTO = new ChampionDTO(0, champion.Name, champion.Bio, champion.Class.ToString(), champion.Icon, champion.Image.ToString());
            return championDTO;
        }

        public static Champion FromDTO(this ChampionDTO champDTO)
        {
            var champion = new Champion(champDTO.Name, (ChampionClass)Enum.Parse(typeof(ChampionClass), champDTO.Class), champDTO.Icon, champDTO.Image, champDTO.Bio);
            return champion;
        }
    }
}