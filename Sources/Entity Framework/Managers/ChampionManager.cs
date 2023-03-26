using Entity_Framework.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using Shared;

namespace Entity_Framework;

/// <summary>
/// Cette classe sert à implémenter des méthodes afin que les données sur les Champions soient synchronisées avec leur table
/// dans la base de données en fonction de ce que le client décide de  faire (récupérer des champions, en supprimer, etc)
/// </summary>
 public class ChampionManager : IChampionsManager
{

   
    public Task<int> GetNbItems()
    {
        using (var context = new ApplicationDbContext())
        {
            var nombreItem = context.ChampionSet.Count();
            return Task.FromResult(nombreItem);
        }
    }

    public Task<Champion> GetById(int id)
    {
        using (var context = new ApplicationDbContext())
        {
            var championEntity = context.ChampionSet.SingleOrDefault (c => c.Id == id);
            return Task.FromResult(championEntity.ToChampion());
        }
    }

    public Task<int> GetNbItemsByCharacteristic(string charName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Champion?>> GetItemsByCharacteristic(string charName, int index, int count, string? orderingPropertyName = null,
        bool descending = false)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetNbItemsByClass(ChampionClass championClass)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Champion?>> GetItemsByClass(ChampionClass championClass, int index, int count, string? orderingPropertyName = null,
        bool descending = false)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetNbItemsBySkill(Skill? skill)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Champion?>> GetItemsBySkill(Skill? skill, int index, int count, string? orderingPropertyName = null, bool descending = false)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetNbItemsByRunePage(RunePage? runePage)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Champion?>> GetItemsByRunePage(RunePage? runePage, int index, int count, string? orderingPropertyName = null,
        bool descending = false)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetNbItemsBySkill(string skill)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Champion?>> GetItemsBySkill(string skill, int index, int count, string? orderingPropertyName = null, bool descending = false)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Champion>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
    {
        using (var context = new ApplicationDbContext())
        {
            var championsEntity = context.ChampionSet.AsEnumerable();

            if (!string.IsNullOrEmpty(orderingPropertyName))
            {
                var propertyInfo = typeof(Champion).GetProperty(orderingPropertyName);
                if (propertyInfo != null)
                {
                    championsEntity = descending
                        ? championsEntity.OrderByDescending(championEntity => propertyInfo.GetValue(championEntity))
                        : championsEntity.OrderBy(championEntity => propertyInfo.GetValue(championEntity));
                }
            }

            championsEntity = championsEntity.Skip(index).Take(count);

            var champions =  championsEntity.Select(champion => champion.ToChampion());

            return Task.FromResult(champions);
        }
    }

    public Task<int> GetNbItemsByName(string substring)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Champion>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null,
        bool descending = false)
    {
        throw new NotImplementedException();
    }

    public Task<Champion> UpdateItem(Champion oldItem, Champion newItem)
    {
        using (var context = new ApplicationDbContext())
        {
            var championOldEntity = oldItem.ToChampionEntity();
            var championNewEntity = newItem.ToChampionEntity();
            var championUpdate = context.ChampionSet.Single(c => c == championOldEntity);
            context.Entry(championUpdate).CurrentValues.SetValues(championNewEntity);
            context.SaveChanges();
            return Task.FromResult(championUpdate.ToChampion());
        }
    }

    public Task<Champion> AddItem(Champion item)
    {
       using (var context = new ApplicationDbContext())
       {
            var championEntity = item.ToChampionEntity();
            var champion = context.ChampionSet.Add(championEntity);
            context.SaveChanges();

            return Task.FromResult(champion.Entity.ToChampion());
       }
    } 
     public async Task<bool> DeleteItem(Champion item){
         try
         {
             using (var context = new ApplicationDbContext())
             {
                 var championEntity = item.ToChampionEntity();

                 var champion = await context.ChampionSet.SingleOrDefaultAsync(c=> c.Id == championEntity.Id);
                 if (champion == null)
                 {
                     return false;
                 }
                 context.ChampionSet.Remove(championEntity);
                 context.SaveChanges();

                 return true;
             }
         }
         catch (Exception e)
         {
             return false; 
         }
     }
}   

