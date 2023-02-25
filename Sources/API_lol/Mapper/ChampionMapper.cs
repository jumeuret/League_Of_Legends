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

        public static Champion ToChampion(this ChampionDTO champDto)
        {
            var champion = new Champion(champDto.Id, champDto.Name, ChampionClass.Assassin)
            {
                Bio = champDto.Bio,
                Icon = champDto.Icon,
            };
            return champion;
        }
    }
}

