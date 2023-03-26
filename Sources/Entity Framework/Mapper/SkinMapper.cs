using Model;

namespace Entity_Framework.Mapper;

public static class SkinMapper
{
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

    public static Skin ToSkin(this SkinEntity skinEntity)
    {
        var skin = new Skin(skinEntity.Id, skinEntity.Name, skinEntity.Champion, skinEntity.Price,skinEntity.Icon, skinEntity.Image, skinEntity.Description);
        return skin;
    }
}