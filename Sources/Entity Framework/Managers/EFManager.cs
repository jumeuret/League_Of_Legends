using Microsoft.EntityFrameworkCore;
using Model;
using Shared;
using StubLib;

namespace Entity_Framework;

/// <summary>
/// Cette classe permet d'instancier les managers de Champions et de Skins en fonction des requêtes du client
/// en utilisant Entity Framework pour communiquer avec la base de données.
/// </summary>
public class EFManager: IDataManager
{
    private readonly DbContext _dbContext;
    private IChampionsManager championsMgr;
    private ISkinsManager skinsMgr;

    public EFManager()
    {
        ChampionsMgr = new ChampionManager();
        SkinsMgr = new SkinManager();
    }
    public IChampionsManager ChampionsMgr { get; }
    public ISkinsManager SkinsMgr { get; }
    
    public IRunesManager RunesMgr { get; }
    public IRunePagesManager RunePagesMgr { get; }
}