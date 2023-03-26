using DTO;
using Microsoft.Maui.Platform;
using Model;

namespace API_lol.Mapper;

public static class SkinMapper
{
    public static SkinDTO ToDTO(this Skin skin)
    {
        var skinDTO = new SkinDTO(skin.Id, skin.Name, skin.Champion, skin.Price, skin.Icon, skin.Image.Base64, skin.Description);
        return skinDTO;
    }

    public static Skin FromDTO(this SkinDTO skinDTO)
    {
        var skin = new Skin(skinDTO.Id, skinDTO.Name, skinDTO.Champion, skinDTO.Price, skinDTO.Icon, skinDTO.Image, skinDTO.Description);
        return skin;
    }
}