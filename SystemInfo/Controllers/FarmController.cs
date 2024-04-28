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
        private readonly FarmService _service;

        public FarmController(FarmService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Farm>>> GetAll()
        {
            var result = await _service.GetAll();
            if (!result.Any())
            {
                return NotFound(new { message = "Farm not found" });
            }

            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Farm>> GetFarm(int id)
        {
            try
            {
                var farm = await _service.GetFarm(id);
                return farm;
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Farm not found" });
            }
        }
        [HttpPost]
        public async Task<ActionResult<Farm>> create(Farm farm)
        {
            try
            {
                var createFarm = await _service.Create(farm);
                return CreatedAtAction("GetFarm", new { id = createFarm.FarmId }, createFarm);
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new { message = "Farmer cannot be null." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Farm farm)
        {
            if (id != farm.FarmId)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(farm);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Farm not found" });
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarm(int id)
        {
            try
            {
                await _service.DeleteFarm(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Farm not found" });
            }
        }
    }
}
