using DTO;
using Model;

namespace API_lol.Mapper;

public static class SkinMapper
{
    public static SkinDTO toDTO(this Skin skin)
    {
        var skinDTO = new SkinDTO(skin.Name, skin.Champion, skin.Price, skin.Icon, skin.Image.Base64, skin.Description);
        return skinDTO;
    }

    public static Skin fromDTO(this SkinDTO skinDTO)
    {
        var skin = new Skin(skinDTO.Name, skinDTO.Champion, skinDTO.Price, skinDTO.Icon, skinDTO.Image, skinDTO.Description);
        return skin;
    }
}