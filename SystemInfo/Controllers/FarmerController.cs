using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemInfo.Models;
using SystemInfo.Services;

namespace SystemInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly IFarmerService _farmerService;

        public FarmerController(IFarmerService farmerService)
        {
            _farmerService = farmerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FarmType>>> GetAll()
        {
            return Ok(await _farmerService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Farmer>> GetFarmer(int id)
        {
            var farmer = await _farmerService.GetFarmer(id);
            if (farmer == null)
            {
                return BadRequest("Farmer not found");
            }

            return Ok(farmer);
        }
        [HttpPost]
        public async Task<ActionResult<Farmer>> create(string name, string lastname, int contactType, string contact, string address)
        {
            var createFarmer = await _farmerService.Create(name, lastname, contactType, contact, address);
            if (createFarmer == null)
            {
                return BadRequest("Farmer not Created");
            }
            return Ok(createFarmer);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, string name, string lastname, int contactType, string contact, string address)
        {
            var createFarmer = await _farmerService.Update(id, name, lastname, contactType, contact, address);
            if (createFarmer == null)
            {
                return BadRequest("Farmer not Updated");
            }
            return Ok(createFarmer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmType(int id)
        {
            var farmer = await _farmerService.DeleteFarmer(id);
            if (farmer == null)
            {
                return BadRequest("Farmer not Deleted");
            }
            return Ok(farmer);

        }
    }
}

