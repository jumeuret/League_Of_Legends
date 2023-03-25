using API_lol.Mapper;
using Microsoft.AspNetCore.Mvc;
using Model;
using StubLib;

namespace API_lol.Controllers;

[Route("api/skins")]
[ApiController]
public class SkinControllers : ControllerBase
{
    private readonly IDataManager _dataManager;
    private readonly ILogger<ChampionControllers> _logger;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Constructeur de la classe ChampionControllers
    /// </summary>
    /// <param name="dataManager"></param>
    /// <param name="logger"></param>
    /// <param name="configuration"></param>
    public SkinControllers(IDataManager dataManager, ILogger<ChampionControllers> logger)
    {
        _dataManager = dataManager;
        _logger = logger;
        // _configuration = configuration;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Skin))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSkins()
    {
        var skins = await _dataManager.SkinsMgr.GetItems(0, await _dataManager.SkinsMgr.GetNbItems());
        var skinsDTO = skins.Select(s => s.toDTO());
        return Ok(skinsDTO);    
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSkin(int idSkin)
    {
        var skin = _dataManager.SkinsMgr.GetById();
        if (skin == null)
        {
            return NotFound();
        }
    }

}