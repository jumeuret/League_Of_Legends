using DTO;
using Model;

namespace API_lol.Mapper;

public static class RunePageMapper
{
    public static RunePageDTO ToDTO(this RunePage runePage)
    {
        var runePageDTO = new RunePageDTO(0, runePage.Name);
        foreach (var rune in runePage.Runes)
        { 
            runePageDTO.addRune((rune.Value).ToDTO(rune.Key.ToString()));   
        }
        return runePageDTO;
    }

    public static RunePage FromDTO(this RunePageDTO runePageDTO)
    {
        var runePage = new RunePage(runePageDTO.Name);
        foreach (var runeDTO in runePageDTO.Runes)
        {
            runePage.Runes.Append(new KeyValuePair<RunePage.Category, Rune>((RunePage.Category)Enum.Parse(typeof(RunePage.Category), runeDTO.Categorie),runeDTO.FromDTO()));
        }
        return runePage;
    }
}