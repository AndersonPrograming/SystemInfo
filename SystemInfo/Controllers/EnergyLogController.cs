using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemInfo.Models;
using SystemInfo.Services;

namespace SystemInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyLogController : ControllerBase
    {
        private readonly EnergyLogService _service;

        public EnergyLogController(EnergyLogService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergyLog>>> GetAll()
        {
            var result = await _service.GetAll();
            if (!result.Any())
            {
                return NotFound(new { message = "EnergyLog not found" });
            }

            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyLog>> GetEnergyLog(int id)
        {
            try
            {
                var energyLog = await _service.GetEnergyLog(id);
                return energyLog;
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "EnergyLog not found" });
            }
        }
        [HttpPost]
        public async Task<ActionResult<EnergyLog>> create(EnergyLog energyLog)
        {
            try
            {
                var createEnergyLog = await _service.Create(energyLog);
                return CreatedAtAction("GetEnergyLog", new { id = createEnergyLog.EnergyLogId }, createEnergyLog);
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new { message = "EnergyLog cannot be null" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EnergyLog energyLog)
        {
            if (id != energyLog.EnergyLogId)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(energyLog);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "EnergyLog not found" });
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnergyLog(int id)
        {
            try
            {
                await _service.DeleteEnergyLog(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "EnergyLog not found" });
            }
        }
    }
}
