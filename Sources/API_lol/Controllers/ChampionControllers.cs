using API_lol.Mapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_lol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionControllers : ControllerBase
    {
        private readonly IDataManager _dataManager;

        public ChampionControllers(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetChampions()
        {
            var lesChampions = await _dataManager.ChampionsMgr.GetItems(0, await _dataManager.ChampionsMgr.GetNbItems());

            var lesChampionsDto = lesChampions.Select(champion => champion?.ToDTO());
           
            return Ok(lesChampionsDto); // les retours API doivent être des DTO
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var leChampion = await _dataManager.ChampionsMgr.GetById(id);
            var leChampionDto = leChampion.ToDTO();
            return Ok(leChampionDto);
   
        }
        
         [HttpPost] 
         public async Task<IActionResult> Post([FromBody] ChampionDTO champion)
         {
             var championModel = champion.ToChampion();
             var championResult = await _dataManager.ChampionsMgr.AddItem(championModel);
             var championResultDto = championResult.ToDTO();
             var truc = _dataManager.ChampionsMgr.GetById(championResultDto.Id);

             return CreatedAtAction(nameof(GetById), new {Id = championResultDto.Id, championResultDto}); //CreatedAtAction = Code 20
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

                   *//*var dto = new ChampionDTO();*//*
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
    }
}
