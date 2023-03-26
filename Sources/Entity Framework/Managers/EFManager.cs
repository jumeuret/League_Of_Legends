using Microsoft.EntityFrameworkCore;
using Model;
using Shared;
using StubLib;

namespace Entity_Framework;

public class EFManager<T> : IGenericDataManager<T>
{
    private readonly DbContext _dbContext;
    private IChampionsManager championsMgr;
    private ISkinsManager skinsMgr;

    public EFManager()
    {
        ChampionsMgr = new ChampionManager(this);
        SkinsMgr = new StubData.SkinsManager(this);
    }
    
    public IChampionsManager ChampionsMgr { get; }
    public ISkinsManager SkinsMgr { get; }
    public Task<int> GetNbItems()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetNbItemsByName(string substring)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null,
        bool descending = false)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateItem(T oldItem, T newItem)
    {
        throw new NotImplementedException();
    }

    public Task<T> AddItem(T item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteItem(T item)
    {
        throw new NotImplementedException();
    }
}