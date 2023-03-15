using Model;

namespace Entity_Framework.Mapper;

public static class ChampionMapper
{
    public static ChampionEntity ToChampionEntity(this Champion champion)
    {
        var championEntity = new ChampionEntity()
        {
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

    public static Champion ToChampion(this ChampionEntity champEntity)
    {
        var champion = new Champion(champEntity.Name, (ChampionClass)Enum.Parse(typeof(ChampionClass), champEntity.Class), champEntity.Icon, champEntity.Image, champEntity.Bio);
        
        List<Skin> skins = new List<Skin>();
        foreach (SkinEntity skin in champEntity.Skins)
        {
            skins.Add(new Skin(skin.Name, champion, skin.Price, skin.Icon, skin.Image, skin.Description));
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

        // Manquant (Pb internal)
        //champion.AddSkin(skins);

        return champion;
    }
}