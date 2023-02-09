using API_lol.Mapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;
using StubLib;

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

        // [HttpPost("Add")]
        // public async Task<IActionResult> Add([FromBody] ChampionDTO c)
        // {
        //     var stub = new StubData();
        //     // var lesChampions = await stub.ChampionsMgr.GetItems(0, await stub.ChampionsMgr.GetNbItems());
        //
        //
        //     stub.Add(c.ToChampion());
        //     return Ok(lesChampions);
        // }
        /*
                [HttpGet("{string:Name}")]
                public async Task<IActionResult> GetByName(string Name)
                {
                    var stub = new StubData();
                    List<Champion> champions = new List<Champion>();

                    var champion = await stub.ChampionsMgr.GetItemsByCharacteristic(Name, 1, 1);
                    var dto = new ChampionDTO();
                    dto.AddRange(champions);
        *//*            ChampionDTO dto = await champions;
        *//* 
                    return Ok(dto);
                }

                [HttpDelete]
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
