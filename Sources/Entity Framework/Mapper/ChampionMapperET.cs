using System.Reflection.PortableExecutable;
using EntityFramework.Migrations;

namespace Entity_Framework.Mapper;

using Model;
using EntityFramework;

public static class ChampionMapperET
{
    public static ChampionEntity ToEntity(this Champion champion)
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

    public static Champion FromEntity(this ChampionEntity champEntity)
    {
        var champion = new Champion(champEntity.Name, (ChampionClass)Enum.Parse(typeof(ChampionClass), champEntity.Class), champEntity.Icon, champEntity.Image, champEntity.Bio);
        
        List<Skin> skins = new List<Skin>();
        foreach (SkinEntity skin in champEntity.Skins)
        {
            skins.Add(new Skin(skin.Name, champion, skin.Price, skin.Icon, skin.Image, skin.Description));
        }
        
        List<Skill> skills = new List<Skill>();
        foreach (SkillEntity skill in champEntity.Skills)
        {
            skills.Add(new Skill(skill.Name, (SkillType)Enum.Parse(typeof(SkillType), skill.Type), skill.Description));
        }
        
        List<Characteristics> characteristics = new List<Characteristics>();
        foreach (CharacteristicsEntity characteristic in champEntity.Characteristics)
        {
            characteristics.Add(new Dictionary<string, int>(characteristic.Nom, characteristic.Niveau));
        }

        champion.AddSkin(skins);
        
        
        return champion;
    }
}