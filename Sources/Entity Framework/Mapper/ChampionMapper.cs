using Model;

namespace Entity_Framework.Mapper;

public static class ChampionMapper
{
    public static ChampionEntity ToChampionEntity(this Champion champion)
    {
        var championEntity= new ChampionEntity{
            Name = champion.Name, 
            Bio = champion.Bio, 
            Icon = champion.Icon, 
            Image = champion.Image.Base64
        };
        return championEntity;
    }

    public static Champion ToChampion(this ChampionEntity championEntity)
    {
        var champion = new Champion(championEntity.Id, championEntity.Name, ChampionClass.Assassin)
        {
            Bio = championEntity.Bio,
            Icon = championEntity.Icon,
        };
        return champion;
    }
}