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
        private readonly IEnergyLogService _energyLogService;

        public EnergyLogController(IEnergyLogService energyLogService)
        {
            _energyLogService = energyLogService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EnergyLog>>> GetAll()
        {
            return Ok(await _energyLogService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyLog>> GetEnergyLog(int id)
        {
            var energyLog = await _energyLogService.GetEnergyLog(id);
            if (energyLog == null)
            {
                return BadRequest("energyLog not found");
            }

            return Ok(energyLog);
        }
        [HttpPost]
        public async Task<ActionResult<EnergyLog>> create(DateTime ReadingDate, string GeneratedEnergyKWH, string ConsumedEnergyKWH, int EnergyMeterId)
        {
            var createEnergyLog = await _energyLogService.Create(ReadingDate, GeneratedEnergyKWH, ConsumedEnergyKWH, EnergyMeterId);
            if (createEnergyLog == null)
            {
                return BadRequest("EnergyLog not Created");
            }
            return Ok(createEnergyLog);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, DateTime ReadingDate, string GeneratedEnergyKWH, string ConsumedEnergyKWH, int EnergyMeterId)
        {
            var createEnergyLog = await _energyLogService.Update(id, ReadingDate, GeneratedEnergyKWH, ConsumedEnergyKWH, EnergyMeterId);
            if (createEnergyLog == null)
            {
                return BadRequest("EnergyLog not Updated");
            }
            return Ok(createEnergyLog);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnergyLog(int id)
        {
            var energyLog = await _energyLogService.DeleteEnergyLog(id);
            if (energyLog == null)
            {
                return BadRequest("EnergyLog not Deleted");
            }
            return Ok(energyLog);

        }
    }
}
