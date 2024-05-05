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
        public async Task<ActionResult<Farm>> create(string farmName, string location, string farmArea, string image, int farmerId, int farmTypeId)
        {
            var createFarm = await _farmService.Create( farmName, location, farmArea, image, farmerId, farmTypeId);
            if (createFarm == null)
            {
                return BadRequest("Farm not Created");
            }
            return Ok(createFarm);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, string farmName, string location, string farmArea, string image, int farmerId, int farmTypeId)
        {
            var createFarm = await _farmService.Update(id, farmName, location, farmArea, image, farmerId, farmTypeId);
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
    }
}
