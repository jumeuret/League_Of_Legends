using Entity_Framework.Mapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Shared;

namespace Entity_Framework;

public class ChampionManager : IGenericDataManager<Champion>
{
    public Task<int> GetNbItems()
    {
        throw new NotImplementedException();
    }

    public Task<Champion> GetById(int id)
    {
        throw new NotImplementedException();
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
        // using (var context = new ApplicationDbContext())
        // {
        //     var championOldEntity = oldItem.ToChampionEntity();
        //     var championNewEntity = newItem.ToChampionEntity();
        //     var update = context.ChampionSet.SingleAsync(championOldEntity);
        //
        // }
        throw new NotImplementedException();

    }

    public Task<Champion> AddItem(Champion item)
    {
        // using (var context = new ApplicationDbContext())
        // {
        //     var championEntity = item.ToChampionEntity();
        //     var champion = context.ChampionSet.Add(championEntity);
        // }
        throw new NotImplementedException();

    }

    public Task<bool> DeleteItem(Champion item)
    {
        // using (var context = new ApplicationDbContext())
        // {
        //     var championEntity = item.ToChampionEntity();
        //     var champion = context.ChampionSet.Remove(championEntity);
        // }
        throw new NotImplementedException();

    }
}