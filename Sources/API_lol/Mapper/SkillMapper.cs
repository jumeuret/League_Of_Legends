using DTO;
using Model;

namespace API_lol.Mapper;

public static class SkillMapper
{
    public static SkillDTO toDTO(this Skill skill)
    {
        var skillDTO = new SkillDTO(skill.Name, skill.Description, skill.Type.ToString());
        return skillDTO;
    }

    public static Skill fromDTO(this SkillDTO skillDTO)
    {
        var skill = new Skill(skillDTO.Name, (SkillType)Enum.Parse(typeof(SkillType), skillDTO.Type), skillDTO.Description);
        return skill;
    }
}