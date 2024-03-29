﻿using API_lol.Controllers;
using API_lol.Mapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_lol.Controller;

/// <summary>
/// Controler de la classe Skin contenant différentes méthodes CRUD
/// </summary>
[Route("api/[controller]")]
//[ApiVersion("1.0")]
[ApiController]
public class SkinController : ControllerBase
{
    private readonly IDataManager _dataManager;
    private readonly ILogger<ChampionController> _logger;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Constructeur de la classe ChampionControllers
    /// </summary>
    /// <param name="dataManager">Iterface permettant d'accéder aux ressources de l'application</param>
    /// <param name="logger">Le logger utilisé pour l'enregistrement des messages de journalisation</param>
    /// <param name="configuration">La configuration de l'application</param>
    public SkinController(IDataManager dataManager, ILogger<ChampionController> logger)
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
        var skinsDTO = skins.Select(s => s.ToDTO());
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
                return BadRequest($"Aucun skin n'a été trouvé avec cette identifiant {idSkin}");
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
    [HttpGet("/Champion/{idChamp}/Skin/{idSkin}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkinDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetChampionSkinById(int idChamp, int idSkin)
    {
        _logger.LogInformation($"Appel API : GetChampionSkinById, idChamp : {idChamp}, idSkin : {idSkin}");
        var champion = await _dataManager.ChampionsMgr.GetById(idChamp);
        var skin = await _dataManager.SkinsMgr.GetById(idSkin);
        if (champion == null || skin == null)
        {
            return BadRequest($"Aucun skin n'a été trouvé avec cette identifiant {idSkin} pour ce champion {idChamp}");
        }
        var championSkin = await _dataManager.SkinsMgr.GetItemByChampion(champion, skin);
        return Ok(championSkin.ToDTO());
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
        var skinsDto = skins.Select(s => s.ToDTO());
        return Ok(skinsDto);
    }
    /// <summary>
    /// Permet d'ajouter un skin
    /// </summary>
    /// <param name="skinDTO">Le skinDTO à ajouter</param>
    /// <returns>Le code retour correspondant à ce qu'il c'est passer pour informer le client</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkinDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddSkin([FromBody] SkinDTO skinDTO)
    {
        try
        {
            var skinModel = skinDTO.FromDTO();
            if (skinModel == null)
            {
                _logger.LogWarning("Le skin est incorrect");
                return NotFound("Le skin est incorrect");
            }

            var skinResult = await _dataManager.SkinsMgr.AddItem(skinModel);
            var skinResultDto = skinResult.ToDTO();

            return Ok(skinResultDto); 
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Une erreur s'est produite lors de l'ajout du champion");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}