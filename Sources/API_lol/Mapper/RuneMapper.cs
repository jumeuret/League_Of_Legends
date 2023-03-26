using DTO;
using Model;

namespace API_lol.Mapper;

public static class RuneMapper
{
    public static RuneDTO ToDTO(this Rune rune, string categorie)
    {
        var runeDTO = new RuneDTO(0, rune.Name, rune.Description, rune.Family.ToString(), rune.Icon,
            rune.Image.ToString(), categorie);
        return runeDTO;
    }

    public static Rune FromDTO(this RuneDTO runeDTO)
    {
        var rune = new Rune(runeDTO.Name, (RuneFamily)Enum.Parse(typeof(RuneFamily), runeDTO.Family), runeDTO.Icon,
            runeDTO.Image, runeDTO.Description);
        return rune;
    }
}