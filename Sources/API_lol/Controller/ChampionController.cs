using API_lol.Mapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_lol.Controllers
{
    /// <summary>
    /// Controller de la classe Champion contenant différentes méthodes CRUD
    /// </summary>
    [Route("api/[controller]")]
    //[ApiVersion("1.0")]
    [ApiController]
    public class ChampionController : ControllerBase
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
        public ChampionController(IDataManager dataManager, ILogger<ChampionController> logger)
        {
            _dataManager = dataManager;
            _logger = logger;
            // _configuration = configuration;
        }

        /// <summary>
        ///  Permet de lister tous les champions
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PageDTO<IEnumerable<ChampionDTO>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetChampions([FromQuery] int index = 0, int count = 10)
        {
            if (count > 50)
            {
                _logger.LogWarning($"Method GetChampions call with {count} (which is too large)");
                count = 5;
            }

            var lesChampions =
                await _dataManager.ChampionsMgr.GetItems(index, count);

            PageDTO<IEnumerable<ChampionDTO>> page = new PageDTO<IEnumerable<ChampionDTO>>
            {
                Data = lesChampions.Select(champion => champion?.ToDTO()),
                Index = index,
                Count = count,
                TotalCount = await _dataManager.ChampionsMgr.GetNbItems()
            };

            return Ok(page); // les retours API doivent être des DTO
        }

        /// <summary>
        /// Récupération du champion, s'il existe, connu grâce à son id
        /// </summary>
        /// <param name="id"> l'identifiant du champion à récupérer</param>
        /// <response code="200">Le champion a été récupéré</response>
        /// <response code="404">Valeur manquante ou non valide pour le champion</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChampionDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetChampionById(int id)
        {
            // _logger.LogInformation("Méthode GetById");
            // _logger.LogWarning("Ceci est un avertissement!");
            // _logger.LogError("");
            var leChampion = await _dataManager.ChampionsMgr.GetById(id);
            if (leChampion == null)
            {
                return Unauthorized();
            }

            var leChampionDto = leChampion.ToDTO();
            return Ok(leChampionDto);
        }

        /// <summary>
        /// Insertion d'un champion
        /// </summary>
        /// <param name="champion"> le champion à inserrer</param>
        /// <response code="200">Le champion a bien été insérré</response>
        /// <response code="404">Valeur manquante ou non valide pour le champion</response>
        /// <response code="500">Un problème s'est produit sur le serveur</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChampionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddChampion([FromBody] ChampionDTO champion)
        {
            try
            {
                var championModel = champion.FromDTO();
                if (championModel is null)
                {
                    _logger.LogWarning("Le champion est incorrect");
                    return NotFound();
                }

                var championResult = await _dataManager.ChampionsMgr.AddItem(championModel);
                var championResultDto = championResult.ToDTO();

                return Ok(championResultDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Une erreur s'est produite lors de l'ajout du champion");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Suppression d'un champion
        /// </summary>
        /// <param name="id">l'identifiant du champion à supprimer</param>
        /// <response code="200">Le champion est supprimé</response>
        /// <response code="404">Valeur manquante ou non valide pour le champion</response>
        /// <response code="500">Un problème s'est produit sur le serveur</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChampionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteChampion(int id)
        {
            try
            {
                var leChampion = await _dataManager.ChampionsMgr.GetById(id);
                if (leChampion == null)
                {
                    _logger.LogWarning($"Aucun champion n'a été trouvé avec cette identifiant {id}");
                    return NotFound();
                }

                var championResult = await _dataManager.ChampionsMgr.DeleteItem(leChampion);
                return Ok(championResult); // est sensé pas indiquer 200 si l'id n'existe pas
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Une erreur s'est produite lors de la suppresion du champion");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        /// <summary>
        /// Modification du nom du champion connu grâce à son l'id 
        /// </summary>
        /// <param name="id">l'identitifiant du champion à modifier</param>
        /// <param name="newName"> le nouveau nom du champion</param>
        /// <response code="200">Le champions a bien été modifié</response>
        /// <response code="404">Valeur manquante ou non valide pour le champion</response>
        /// <response code="500">Un problème s'est produit sur le serveur</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChampionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ModifyNameChampion(int id, [FromBody] string newName)
        {
            try
            {
                var leChampion = await _dataManager.ChampionsMgr.GetById(id);
                if (leChampion == null)
                {
                    _logger.LogWarning($"Aucun champion n'a été trouvé avec cet identifiant {id}");
                    return NotFound();
                }

                var newChampion = new Champion(leChampion.Id, newName, leChampion.Class, leChampion.Icon,
                    leChampion.Image.Base64, leChampion.Bio);
                leChampion = await _dataManager.ChampionsMgr.UpdateItem(leChampion, newChampion);
                var championResultDto = leChampion.ToDTO();
                return Ok(championResultDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Une erreur s'est produite lors de la modification du nom du champion");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Récupération de la liste des skins d'un champion spécifié
        /// </summary>
        /// <param name="idChampion">l'identitifiant du champion auquel appartient les kins</param>
        /// <returns>La liste de skins du champion</returns>
        /// <response code="200">Le champion a été récupéré</response>
        /// <response code="404">Valeur manquante ou non valide pour le champion</response>
        [HttpGet("{idChampion}/skin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChampionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSkinsByChampion(int idChampion)
        {
            var champion = await _dataManager.ChampionsMgr.GetById(idChampion);

            if (champion == null)
            {
                _logger.LogWarning($"Aucun champion n'a été trouvé avec cette identifiant {idChampion}");
                return NotFound();
            }

            var skins = await _dataManager.SkinsMgr.GetItemsByChampion(champion, 0,
                await _dataManager.SkinsMgr.GetNbItems());
            var lesSkinsDto = skins.Select(skins => skins.ToDTO());

            return Ok(lesSkinsDto);
        }
        

        /// <summary>
        /// Permet de récupérer le nombre de Champions existants
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retourne le nombre total de champions</response>
        [HttpGet("Champion/count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> GetNbChampion()
        {
            var nbChampion = await _dataManager.ChampionsMgr.GetNbItems();

            return Ok(nbChampion);
        }
    }
}


