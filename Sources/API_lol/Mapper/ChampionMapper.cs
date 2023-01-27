namespace API_lol.Mapper
{
    using Model;
    using DTO;

    public static class ChampionMapper
    {

        // Transformer un champion en champion DTO 
        // ex enlever le mot de pass pour pas que le client le récupère
        public ChampionDTO ToDTO(this Champion champion)
        {
            var championDTO = new ChampionDTO()
            {
               Name = champion.Name,
               Bio = champion.Bio,

            }
            return championDTO;
        }
    }
}
