using Model;

namespace Entity_Framework.Mapper;

/// <summary>
/// Classe permetant de faire des convertion de type sur les Champion et ChampionEntity
/// </summary>
public static class ChampionMapper
{
    /// <summary>
    /// Permet de convertir un Champion en ChampionEntity
    /// </summary>
    /// <param name="champion"> Le champion à convertir en championEntity</param>
    /// <returns>Un championEntity</returns>
    public static ChampionEntity ToChampionEntity(this Champion champion)
    {
        var championEntity = new ChampionEntity()
        {
            Id = champion.Id,
            Name = champion.Name,
            Bio = champion.Bio,
            Class = champion.Class.ToString(),
            Icon = champion.Icon,
            Image = champion.Image.ToString()
        };

        List<SkinEntity> skins = new List<SkinEntity>();
        foreach (Skin skin in champion.Skins)
        {
            skins.Add(new SkinEntity(){
                Name = skin.Name,
                Description = skin.Description,
                Icon = skin.Icon,
                Image = skin.Image.ToString(),
                Price = skin.Price
            });
        }
        
        List<SkillEntity> skills = new List<SkillEntity>();
        foreach (Skill skill in champion.Skills)
        {
            skills.Add(new SkillEntity(){
                Name = skill.Name,
                Description = skill.Description,
                Type = skill.Type.ToString(),
            });
        }
        
        List<CharacteristicsEntity> characteristics = new List<CharacteristicsEntity>();
        foreach (KeyValuePair<string,int> characteristic in champion.Characteristics)
        {
            characteristics.Add(new CharacteristicsEntity(){
                Nom = characteristic.Key,
                Niveau = characteristic.Value,
            });
        }

        championEntity.Skins = skins;
        championEntity.Skills = skills;
        championEntity.Characteristics = characteristics;

        return championEntity;
    }

    /// <summary>
    /// Permet de convertir un ChampionEntity en Champion
    /// </summary>
    /// <param name="champEntity"> Le ChampionEntity à convertir</param>
    /// <returns>Un Champion</returns>
    public static Champion ToChampion(this ChampionEntity champEntity)
    {
        var champion = new Champion(champEntity.Id, champEntity.Name, (ChampionClass)Enum.Parse(typeof(ChampionClass), champEntity.Class), champEntity.Icon, champEntity.Image, champEntity.Bio);
        
        List<Skin> skins = new List<Skin>();
        foreach (SkinEntity skin in champEntity.Skins)
        {
            skins.Add(new Skin(skin.Id, skin.Name, champion, skin.Price, skin.Icon, skin.Image, skin.Description));
        }
        
        foreach (SkillEntity skill in champEntity.Skills)
        {
            champion.AddSkill(new Skill(skill.Name, (SkillType)Enum.Parse(typeof(SkillType), skill.Type), skill.Description));
        }
        
        Tuple<string, int>[] characteristics;
        foreach (CharacteristicsEntity characteristic in champEntity.Characteristics)
        {
            champion.AddCharacteristics(new Tuple<string, int>(characteristic.Nom, characteristic.Niveau));
        }

        return champion;
    }
}