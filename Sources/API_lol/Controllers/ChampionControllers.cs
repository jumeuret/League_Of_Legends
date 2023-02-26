using System.Collections;
using API_lol.Mapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_lol.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChampionControllers : ControllerBase
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
        public ChampionControllers(IDataManager dataManager)
        {
            _dataManager = dataManager;
            // _logger = logger;
            // _configuration = configuration;
        }

        /// <summary>
        ///  Récupération de la liste des champions
        /// </summary>
        /// <response code="200">Les champions ont été récupérés</response>
        /// <response code="404">Valeur manquante ou non valide pour le champion</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChampionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetChampions()
        {
            var lesChampions =
                await _dataManager.ChampionsMgr.GetItems(0, await _dataManager.ChampionsMgr.GetNbItems());

            var lesChampionsDto = lesChampions.Select(champion => champion?.ToDTO());

            return Ok(lesChampionsDto); // les retours API doivent être des DTO
        }

        /// <summary>
        /// Récupération du champion, s'il existe, connu grâce à son id
        /// </summary>
        /// <param name="id"> l'identifiant du champion à récupérer</param>
        /// <response code="200">Le champion a été récupéré</response>
        /// <response code="404">Valeur manquante ou non valide pour le champion</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChampionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetChampionById(int id)
        {
            // _logger.LogInformation("Méthode GetById");
            // _logger.LogWarning("Ceci est un avertissement!");
            // _logger.LogError("");
            var leChampion = await _dataManager.ChampionsMgr.GetById(id);
            if (leChampion == null)
            {
                return NotFound();
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChampionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddChampion([FromBody] ChampionDTO champion)
        {
            // try
            // {
            var championModel = champion.ToChampion();
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

        /// <summary>
        /// Suppression d'un champion
        /// </summary>
        /// <param name="id">l'identifiant du champion à supprimer</param>
        /// <response code="200">Le champion est supprimé</response>
        /// <response code="404">Valeur manquante ou non valide pour le champion</response>
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
        /// <summary>
        /// Modification du nom du champion connu grâce à son l'id 
        /// </summary>
        /// <param name="id">l'identitifiant du champion à modifier</param>
        /// <param name="newName"> le nouveau nom du champion</param>
        /// <response code="200">Le champions a bien été modifié</response>
        /// <response code="404">Valeur manquante ou non valide pour le champion</response>
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
            var newChampion = new Champion(leChampion.Id, newName, leChampion.Class, leChampion.Icon,
                leChampion.Image.Base64, leChampion.Bio);
            leChampion = await _dataManager.ChampionsMgr.UpdateItem(leChampion, newChampion);
            var championResultDto = leChampion.ToDTO();
            return Ok(championResultDto); 
        }
    }
}

/*  [HttpGet("{string:Name}")]
  public async Task<IActionResult> GetByName(string Name)
  {
      var stub = new StubData();
      List<Champion> champions = new List<Champion>();

      var champion = await stub.ChampionsMgr.GetItemsByCharacteristic(Name, 1, 1);
      var dto = new ChampionDTO();
      dto.AddRange(champions);
      ChampionDTO dto = await champions;

      return Ok(dto);
  }

/*  [HttpDelete]
  public async Task<IActionResult> Delete()
  {
      var stub = new StubData();

      */ /*var dto = new ChampionDTO();*/ /*
                    var champions = await stub.ChampionsMgr
                   ;
                    return Ok(champions);
                }*/


    // des exemples

    // POST api/<ChampionController>
    /*[HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ChampionController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ChampionController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }*/


