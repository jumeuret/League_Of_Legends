using Model;

namespace Entity_Framework.Mapper;

/// <summary>
/// Classe permetant de faire des convertion de type sur les Skin et SkinEntity
/// </summary>
public static class SkinMapper
{
    /// <summary>
    /// Permet de convertir un Skin en SkinEntity
    /// </summary>
    /// <param name="skin">Le skin à convertir</param>
    /// <returns>Un SkinEntity</returns>
    public static SkinEntity ToSkinEntity(this Skin skin)
    {
        var skinEntity = new SkinEntity()
        {
            Id = skin.Id,
            Name = skin.Name,
            Description = skin.Description,
            Image = skin.Image.Base64,
            Icon = skin.Icon,
            Price = skin.Price

        };
        return skinEntity;
    }

    /// <summary>
    /// Permet de convertir un SkinEntity en Skin
    /// </summary>
    /// <param name="skinEntity">Le SkinEntity à convertir</param>
    /// <returns>Un Skin</returns>
    public static Skin ToSkin(this SkinEntity skinEntity)
    {
        var skin = new Skin(skinEntity.Id, skinEntity.Name, skinEntity.ChampionEntity.ToChampion(), skinEntity.Price,skinEntity.Icon, skinEntity.Image, skinEntity.Description);
        return skin;
    }
}