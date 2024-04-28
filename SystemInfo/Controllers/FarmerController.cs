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
        private readonly FarmerService _service;

        public FarmerController(FarmerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Farmer>>> GetAll()
        {
            var result = await _service.GetAll();
            if (!result.Any())
            {
                return NotFound(new { message = "Farmer not found" });
            }

            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Farmer>> GetFarmer(int id)
        {
            try
            {
                var farmer = await _service.GetFarmer(id);
                return farmer;
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Farmer not found" });
            }
        }
        [HttpPost]
        public async Task<ActionResult<Farmer>> create(Farmer farmer)
        {
            try
            {
                var createFarmer = await _service.Create(farmer);
                return CreatedAtAction("GetFarmer", new { id = createFarmer.FarmerId }, createFarmer);
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new { message = "Farmer cannot be null." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Farmer farmer)
        {
            if (id != farmer.FarmerId)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(farmer);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Farmer not found" });
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmer(int id)
        {
            try
            {
                await _service.DeleteFarmer(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Farmer not found" });
            }
        }
    }
}

