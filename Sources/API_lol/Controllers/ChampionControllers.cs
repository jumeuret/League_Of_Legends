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
        public IActionResult Get()
        {
            var stub = new StubData();

            var dto = new ChampionDTO();
            var lesChampions = new List<Champion>();

            return Ok(lesChampions);
        }

        // des exemples

        // POST api/<ChampionController>
        [HttpPost]
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
        }
    }
}
