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
        public async Task<ActionResult<EnergyLog>> create([FromBody] EnergyLogModel model)
        {
            var createEnergyLog = await _energyLogService.Create(model.readingDate, model.generatedEnergyKWH, model.consumedEnergyKWH, model.energyMeterId);
            if (createEnergyLog == null)
            {
                return BadRequest("EnergyLog not Created");
            }
            return Ok(createEnergyLog);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] EnergyLogModelU model)
        {
            var createEnergyLog = await _energyLogService.Update(model.id, model.readingDate, model.generatedEnergyKWH, model.consumedEnergyKWH, model.energyMeterId);
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

        public class EnergyLogModel
        {
            public DateTime readingDate { get; set; }
            public string generatedEnergyKWH { get; set; }
            public string consumedEnergyKWH { get; set; }
            public int energyMeterId { get; set; }
        }
        public class EnergyLogModelU
        {
            public int id { get; set; }
            public DateTime readingDate { get; set; }
            public string generatedEnergyKWH { get; set; }
            public string consumedEnergyKWH { get; set; }
            public int energyMeterId { get; set; }
        }
    }
}
