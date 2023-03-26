using API_lol.Mapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_lol.Controllers
{
    /// <summary>
    /// Controller de la classe RunePage contenant différentes méthodes CRUD
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RunePageController : ControllerBase
    {
        private readonly IDataManager _dataManager;
        private readonly ILogger<RunePageController> _logger;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructeur de la classe RunePageController.
        /// </summary>
        /// <param name="dataManager">Iterface permettant d'accéder aux ressources de l'application</param>
        /// <param name="logger">Le logger utilisé pour l'enregistrement des messages de journalisation</param>
        /// <param name="configuration">La configuration de l'application</param>
        public RunePageController(IDataManager dataManager)
        {
            _dataManager = dataManager;
            // _logger = logger;
            // _configuration = configuration;
        }

        /// <summary>
        /// Permet de lister toutes les pages de runes
        /// </summary>
        /// <param name="index">L'indice de la première page de runes à récupérer.</param>
        /// <param name="count">Le nombre de pages de runes à récupérer.</param>
        /// <returns>Une liste contenant les pages de runes correspondantes à la plage d'indices spécifiée.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PageDTO<IEnumerable<RunePageDTO>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRunePages([FromQuery] int index = 0, int count = 10)
        {
            if (count > 50)
            {
                _logger.LogWarning($"Method GetRunePages call with {count} (which is too large)");
                count = 5;
            }

            var lesRunePages =
                await _dataManager.RunePagesMgr.GetItems(index, count);

            PageDTO<IEnumerable<RunePageDTO>> page = new PageDTO<IEnumerable<RunePageDTO>>
            {
                Data = lesRunePages.Select(rune => rune?.ToDTO()),
                Index = index,
                Count = count,
                TotalCount = await _dataManager.RunePagesMgr.GetNbItems()
            };

            return Ok(page); // les retours API doivent être des DTO
        }

        /*[HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RunePageDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRunePageById(int id)
        {
            // _logger.LogInformation("Méthode GetById");
            // _logger.LogWarning("Ceci est un avertissement!");
            // _logger.LogError("");
            var laRunePage = await _dataManager.RunePagesMgr.GetItemsByRune(id);
            if (leChampion == null)
            {
                return NotFound();
            }

            var leChampionDto = leChampion.ToDTO();
            return Ok(leChampionDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RunePageDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddRunePage([FromBody] RunePageDTO runePageDTO)
        {
            try
            {
                var runePageModel = runePageDTO.FromDTO();
                if (runePageModel == null)
                {
                    _logger.LogWarning("La RunePage est incorrecte");
                    return Unauthorized();
                }

                var runePageResult = await _dataManager.RunePagesMgr.AddItem(runePageModel);
                var runePageResultDto = runePageResult.ToDTO();
                var truc = _dataManager.RunePagesMgr.
                    ChampionsMgr.GetById(runePageResultDto.Id);

                return CreatedAtAction(nameof(GetChampionById),
                    new { Id = championResultDto.Id, championResultDto }); //CreatedAtAction = Code 20
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Une erreur s'est produite lors de l'ajout du champion");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

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

                var newChampion = new Champion(newName, leChampion.Class, leChampion.Icon,
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
        }*/
    }
}