using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemInfo.Models;
using SystemInfo.Services;

namespace SystemInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly IFarmService _farmService;

        public FarmController(IFarmService farmService)
        {
            _farmService = farmService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Farm>>> GetAll()
        {
            return Ok(await _farmService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Farm>> GetFarm(int id)
        {
            var farm = await _farmService.GetFarm(id);
            if (farm == null)
            {
                return BadRequest("Farm not found");
            }

            return Ok(farm);
        }
        [HttpPost]
        public async Task<ActionResult<Farm>> create([FromBody] FarmModel model)
        {
            var createFarm = await _farmService.Create( model.farmName, model.location, model.farmArea, model.image, model.farmerId, model.farmTypeId);
            if (createFarm == null)
            {
                return BadRequest("Farm not Created");
            }
            return Ok(createFarm);
        }

        [HttpPatch()]
        public async Task<IActionResult> Update([FromBody] FarmModelU model)
        {
            var createFarm = await _farmService.Update(model.id, model.farmName, model.location, model.farmArea, model.image, model.farmerId, model.farmTypeId);
            if (createFarm == null)
            {
                return BadRequest("Farm not Updated");
            }
            return Ok(createFarm);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarm(int id)
        {
            var farm = await _farmService.DeleteFarm(id);
            if (farm == null)
            {
                return BadRequest("Farm not Deleted");
            }
            return Ok(farm);

        }

        public class FarmModel
        {
            public string farmName { get; set; }
            public string location { get; set; }
            public string farmArea { get; set; }
            public string image { get; set; }   
            public int farmerId { get; set; }
            public int farmTypeId { get; set; }
        }
        public class FarmModelU
        {
            public int id { get; set; }
            public string farmName { get; set; }
            public string location { get; set; }
            public string farmArea { get; set; }
            public string image { get; set; }
            public int farmerId { get; set; }
            public int farmTypeId { get; set; }
        }
    }
}
