using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemInfo.Models;
using SystemInfo.Services;

namespace SystemInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmTypeController : ControllerBase
    {
        private readonly IFarmTypeService _farmTypeService;

        public FarmTypeController(IFarmTypeService farmTypeService)
        {
            _farmTypeService = farmTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FarmType>>> GetAll()
        {
            return Ok(await _farmTypeService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FarmType>> GetFarmType(int id)
        {
            var farmType = await _farmTypeService.GetFarmType(id);
            if(farmType == null)
            {
                return BadRequest("FarmType not found");
            }

            return Ok(farmType);
        }
        [HttpPost]
        public async Task<ActionResult<FarmType>> create(string farmType)
        {
            var createFarmType = await _farmTypeService.Create(farmType);
            if(createFarmType == null)
            {
                return BadRequest("FarmType not Created");
            }
            return Ok(createFarmType);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, string farmType)
        {
           var farm = await _farmTypeService.Update(id, farmType);
            if(farm == null)
            {
                return BadRequest("FarmType not Updated");
            }
           return Ok(farm);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmType(int id)
        {
            var farmType = await _farmTypeService.DeleteFarmType(id);
            if(farmType == null)
            {
                return BadRequest("FarmType not Deleted");
            }
            return Ok(farmType);
           
        }
    }
}
