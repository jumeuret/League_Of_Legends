using API_lol.Mapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;
using StubLib;

namespace API_lol.Controllers;

[Route("api/skins")]
[ApiController]
public class SkinControllers : ControllerBase
{
    private readonly IDataManager _dataManager;
    private readonly ILogger<ChampionController> _logger;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Constructeur de la classe ChampionControllers
    /// </summary>
    /// <param name="dataManager"></param>
    /// <param name="logger"></param>
    /// <param name="configuration"></param>
    public SkinControllers(IDataManager dataManager, ILogger<ChampionController> logger)
    {
        _dataManager = dataManager;
        _logger = logger;
        // _configuration = configuration;
    }

    /// <summary>
    /// Permet de lister tous les skins 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkinDTO))]
    public async Task<IActionResult> GetSkins()
    {
        var skins = await _dataManager.SkinsMgr.GetItems(0, await _dataManager.SkinsMgr.GetNbItems());
        var skinsDTO = skins.Select(s => s.toDTO());
        return Ok(skinsDTO);    
    }
    /// <summary>
    /// Suppression du skin à partir de son id
    /// </summary>
    /// <param name="idSkin"> L'identifiant du skin à supprimer</param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkinDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteSkin(int idSkin)
    {
        try
        {
            _logger.LogInformation("Cette requête a pour but de supprimer un skin à partir de l'id qui a été fourni");
            var skin = await _dataManager.SkinsMgr.GetById(idSkin);
            if (skin == null)
            {
                _logger.LogWarning($"Aucun skin n'a été trouvé avec cette identifiant {idSkin}");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var result = await _dataManager.SkinsMgr.DeleteItem(skin);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Une erreur s'est produite lors de la suppression d'un skin");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Permet de trouver le skin correspondant au champion à partir de id du champion et du skin 
    /// </summary>
    /// <param name="idChamp">l'id du champion</param>
    /// <param name="idSkin">l'id du skin</param>
    /// <returns></returns>
    [HttpGet("/champions/{idChamp}/skins/{idSkin}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkinDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetChampionSkinById(int idChamp, int idSkin)
    {
        var champion = await _dataManager.ChampionsMgr.GetById(idChamp);
        var skin = await _dataManager.SkinsMgr.GetById(idSkin);
        if (champion == null || skin == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        var championSkin = await _dataManager.SkinsMgr.GetItemByChampion(champion, skin);
        return Ok(championSkin.toDTO());
    }
    /// <summary>
    /// Permet de trouver toutes les skins qui ont le nom entré par le client
    /// </summary>
    /// <param name="name">Le nom des skins à trouver</param>
    /// <returns>La liste des skins qui possèdent le nom</returns>
    [HttpGet("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkinDTO))]
    public async Task<IActionResult> GetSkinByName(String name)
    {
        var skins = await _dataManager.SkinsMgr.GetItemsByName(name, 0, await _dataManager.SkinsMgr.GetNbItems());
        var skinsDto = skins.Select(s => s.toDTO());
        return Ok(skinsDto);
    }
}