using System.Collections;

namespace Entity_Framework;

public interface IChampionManager
{
    public int GetNbItemsByCharacteristic(string charName);

    public ICollection<ChampionEntity> GetItemsByCharacteristic(string charName, int index, int count, string? orderingPropertyName,
        bool descending);

    public int GetNbItemsByClass(string ChampionClass);

    public ICollection<ChampionEntity> GetItemsByClass(string championClass, int index, int count,
        string? orderingPropertyName,
        bool descending);

    public int GetNbItemsBySkill(SkillEntity? skill);
    
    public ICollection<ChampionEntity> GetItemsBySkill(SkillEntity? skill, int index, int count, string? orderingPropertyName,
        bool descending);

    public int GetNbItemsBySkill(string skill);

    public ICollection<ChampionEntity> GetItemsBySkill(string skill, int index, int count, string? orderingPropertyName,
        bool descending);

    public int GetNbItemsByRunePage(RunePageEntity? runePage);

    public ICollection<ChampionEntity> GetItemsByRunePage(RunePageEntity? runePage, int index, int count,
        string? orderingPropertyName, bool descending);
}