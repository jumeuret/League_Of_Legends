using Entity_Framework.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using Shared;

namespace Entity_Framework;

public class ChampionManager : IGenericDataManager<Champion>
{
    private readonly ILogger<ChampionManager> _logger;
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

    public Task<IEnumerable<Champion>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
    {
        throw new NotImplementedException();
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
            championUpdate = championNewEntity;
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