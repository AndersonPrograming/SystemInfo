using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemInfo.Models;
using SystemInfo.Services;

namespace SystemInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyMeterController : ControllerBase
    {
        private readonly EnergyMeterService _service;

        public EnergyMeterController(EnergyMeterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergyMeter>>> GetAll()
        {
            var result = await _service.GetAll();
            if (!result.Any())
            {
                return NotFound(new { message = "EnergyMeter not found" });
            }

            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyMeter>> GetEnergyMeter(int id)
        {
            try
            {
                var energyMeter = await _service.GetEnergyMeter(id);
                return energyMeter;
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "EnergyMeter not found" });
            }
        }
        [HttpPost]
        public async Task<ActionResult<EnergyMeter>> create(EnergyMeter energyMeter)
        {
            try
            {
                var createEnergyMeter = await _service.Create(energyMeter);
                return CreatedAtAction("GetEnergyMeter", new { id = createEnergyMeter.EnergyMeterId }, createEnergyMeter);
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new { message = "EnergyMeter cannot be null" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EnergyMeter energyMeter)
        {
            if (id != energyMeter.EnergyMeterId)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(energyMeter);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "EnergyMeter not found" });
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnergyMeter(int id)
        {
            try
            {
                await _service.DeleteEnergyMeter(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "EnergyMeter not found" });
            }
        }
    }
}
