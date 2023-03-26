using Entity_Framework.Mapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Shared;

namespace Entity_Framework;
/// <summary>
/// Cette classe sert à implémenter des méthodes afin que les données sur les Skins soient synchronisées avec leur table
/// dans la base de données en fonction de ce que le client décide de  faire (récupérer des champions, en supprimer, etc)
/// </summary>
public class SkinManager : ISkinsManager
{
    private readonly EFManager parent;

    public SkinManager(EFManager parent)
    {
        this.parent = parent;
    }
    public Task<int> GetNbItems()
    {
        using (var context = new ApplicationDbContext())
        {
            var nombreItem = context.SkinSet.Count();
            return Task.FromResult(nombreItem);
        }
    }

    public Task<IEnumerable<Skin>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
    {
        using (var context = new ApplicationDbContext())
        {
            var skinsEntity = context.SkinSet.AsEnumerable();

            if (!string.IsNullOrEmpty(orderingPropertyName))
            {
                var propertyInfo = typeof(Champion).GetProperty(orderingPropertyName);
                if (propertyInfo != null)
                {
                    skinsEntity = descending
                        ? skinsEntity.OrderByDescending(skinEntity => propertyInfo.GetValue(skinEntity))
                        : skinsEntity.OrderBy(skinEntity => propertyInfo.GetValue(skinEntity));
                }
            }

            skinsEntity = skinsEntity.Skip(index).Take(count);

            var skins =  skinsEntity.Select(skin => skin.ToSkin());

            return Task.FromResult(skins);
        }
    }

    public Task<int> GetNbItemsByName(string substring)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Skin>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null,
        bool descending = false)
    {
        using (var context = new ApplicationDbContext())
        {
            var skinsEntity = context.SkinSet.Where(s => s.Name.Contains(substring)).AsEnumerable();

            if (!string.IsNullOrEmpty(orderingPropertyName))
            {
                var propertyInfo = typeof(Skin).GetProperty(orderingPropertyName);
                if (propertyInfo != null)
                {
                    skinsEntity = descending ? skinsEntity.OrderByDescending(s => propertyInfo.GetValue(s)) : skinsEntity.OrderBy(s => propertyInfo.GetValue(s));
                }
            }

            var skins = skinsEntity.Select(s => s.ToSkin());
            return Task.FromResult(skins);
        }
    }
    
    public Task<Skin> UpdateItem(Skin oldItem, Skin newItem)
    {
        using (var context = new ApplicationDbContext())
        {
            var skinOldEntity = oldItem.ToSkinEntity();
            var skinNewEntity = newItem.ToSkinEntity();
            var skinUpdate = context.SkinSet.Single(s => s == skinOldEntity);
            
            context.Entry(skinUpdate).CurrentValues.SetValues(skinNewEntity);
            context.SaveChanges();

            return Task.FromResult(skinUpdate.ToSkin());
        }    
    }

    public Task<Skin> AddItem(Skin item)
    {
        using (var context = new ApplicationDbContext())
        {
            var skinEntity = item.ToSkinEntity();
            var skin = context.SkinSet.Add(skinEntity);
            context.SaveChanges();

            return Task.FromResult(skin.Entity.ToSkin());
        }    
    }

    public async Task<bool> DeleteItem(Skin item)
    {
        using (var context = new ApplicationDbContext())
        {
            var skinEntity = item.ToSkinEntity();

            var skin = await context.ChampionSet.SingleOrDefaultAsync(s=> s.Id == skinEntity.Id);
            if (skin == null)
            {
                return false;
            }
            context.SkinSet.Remove(skinEntity);
            context.SaveChanges();

            return true;
        }
    }
    public Task<Skin> GetById(int id)
    {
        using (var context = new ApplicationDbContext())
        {
            var skinEntity = context.SkinSet.SingleOrDefault (s => s.Id == id);
            return Task.FromResult(skinEntity.ToSkin());
        }
    }

    public Task<int> GetNbItemsByChampion(Champion? champion)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Skin?>> GetItemsByChampion(Champion? champion, int index, int count, string? orderingPropertyName = null,
        bool descending = false)
    {
        throw new NotImplementedException();
    }

    public Task<Skin?> GetItemByChampion(Champion champion, Skin skin)
    {
        using (var context = new ApplicationDbContext())
        {
            var skinEntity = context.SkinSet.SingleOrDefault(s => s.ChampionEntity.ToChampion() == champion && s.Id == skin.Id);
            return Task.FromResult(skinEntity.ToSkin());
        }
    }


}