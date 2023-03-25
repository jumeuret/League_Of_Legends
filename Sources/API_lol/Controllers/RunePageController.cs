using System.Collections;
using API_lol.Mapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_lol.Controllers
{
    [Route("[runePages]")]
    [ApiController]
    public class RunePageController : ControllerBase
    {
        private readonly IDataManager _dataManager;
        private readonly ILogger<RunePageController> _logger;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructeur de la classe RunePageController
        /// </summary>
        /// <param name="dataManager"></param>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        public RunePageController(IDataManager dataManager)
        {
            _dataManager = dataManager;
            // _logger = logger;
            // _configuration = configuration;
        }

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
/*
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RunePageDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRunePageById(int id)
        {
            // _logger.LogInformation("Méthode GetById");
            // _logger.LogWarning("Ceci est un avertissement!");
            // _logger.LogError("");
            var laRunePage = await _dataManager.RunePagesMgr. .GetById(id);
            if (leChampion == null)
            {
                return NotFound();
            }

            var leChampionDto = leChampion.ToDTO();
            return Ok(leChampionDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChampionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddChampion([FromBody] ChampionDTO champion)
        {
            // try
            // {
            var championModel = champion.FromDTO();
            if (championModel == null)
            {
                return NotFound();
            }

            var championResult = await _dataManager.ChampionsMgr.AddItem(championModel);
            var championResultDto = championResult.ToDTO();
            var truc = _dataManager.ChampionsMgr.GetById(championResultDto.Id);

            return CreatedAtAction(nameof(GetChampionById),
                new { Id = championResultDto.Id, championResultDto }); //CreatedAtAction = Code 20
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChampionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteChampion(int id)
        {
            var leChampion = await _dataManager.ChampionsMgr.GetById(id);
            if (leChampion == null)
            {
                return NotFound();
            }

            var championResult = await _dataManager.ChampionsMgr.DeleteItem(leChampion);
            return Ok(championResult); // est sensé pas indiquer 200 si l'id n'existe pas
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChampionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ModifyNameChampion(int id, [FromBody] string newName)
        {
            var leChampion = await _dataManager.ChampionsMgr.GetById(id);
            if (leChampion == null)
            {
                return NotFound();
            }

            var newChampion = new Champion(newName, leChampion.Class, leChampion.Icon,
                leChampion.Image.Base64, leChampion.Bio);
            leChampion = await _dataManager.ChampionsMgr.UpdateItem(leChampion, newChampion);
            var championResultDto = leChampion.ToDTO();
            return Ok(championResultDto);
        }
*/
    }
}