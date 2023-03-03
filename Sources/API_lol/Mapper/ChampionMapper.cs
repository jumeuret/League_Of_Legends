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
            var championDTO = new ChampionDTO(champion.Id, champion.Name, champion.Bio, champion.Icon);
            return championDTO;
        }

        public static Champion FromDTO(this ChampionDTO champDTO)
        {
            var champion = new Champion(champDTO.Id, champDTO.Name, ChampionClass.Assassin)
            {
                Bio = champDTO.Bio,
                Icon = champDTO.Icon,
            };
            return champion;
        }
    }
}