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
        public async Task<ActionResult<Farmer>> create([FromBody] FarmerModel model)
        {
            var createFarmer = await _farmerService.Create(model.name, model.lastname, model.contactTypeId, model.contact, model.address);
            if (createFarmer == null)
            {
                return BadRequest("Farmer not Created");
            }
            return Ok(createFarmer);
        }

        [HttpPatch()]
        public async Task<IActionResult> Update([FromBody] FarmerModelU model)
        {
            var createFarmer = await _farmerService.Update(model.id, model.name, model.lastName, model.contactTypeId, model.contact, model.address);
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

        public class FarmerModel
        {
            public string name { get; set; }
            public string lastname { get; set; }
            public int contactTypeId { get; set; }
            public string contact { get; set; }
            public string address { get; set; }
        }
        public class FarmerModelU
        {
            public int id { get; set; }
            public string name { get; set; }
            public string lastName { get; set; }
            public int contactTypeId { get; set; }
            public string contact { get; set; }
            public string address { get; set; }
        }
    }
}

