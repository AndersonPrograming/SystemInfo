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
        private readonly IEnergyMeterService _energyMeterService;

        public EnergyMeterController(IEnergyMeterService energyMeterService)
        {
            _energyMeterService = energyMeterService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EnergyMeter>>> GetAll()
        {
            return Ok(await _energyMeterService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyMeter>> GetEnergyMeter(int id)
        {
            var energyMeter = await _energyMeterService.GetEnergyMeter(id);
            if (energyMeter == null)
            {
                return BadRequest("FarmType not found");
            }

            return Ok(energyMeter);
        }
        [HttpPost]
        public async Task<ActionResult<EnergyMeter>> create([FromBody] EnergyMeterModel model)
        {
            var createEnergyMeter = await _energyMeterService.Create(model.energyMeterBrand, model.instalationDate);
            if (createEnergyMeter == null)
            {
                return BadRequest("FarmType not Created");
            }
            return Ok(createEnergyMeter);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] EnergyMeterModelU model)
        {
            var createEnergyMeter = await _energyMeterService.Update(model.id, model.energyMeterBrand, model.instalationDate);
            if (createEnergyMeter == null)
            {
                return BadRequest("EnergyMeter not Updated");
            }
            return Ok(createEnergyMeter);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnergyMeter(int id)
        {
            var energyMeter = await _energyMeterService.DeleteEnergyMeter(id);
            if (energyMeter == null)
            {
                return BadRequest("EnergyMeter not Deleted");
            }
            return Ok(energyMeter);

        }

        public class EnergyMeterModel
        {
            public string energyMeterBrand { get; set; } 
            public DateTime instalationDate { get; set; }
        }

        public class EnergyMeterModelU
        {
            public int id { get; set; }
            public string energyMeterBrand { get; set; }
            public DateTime instalationDate { get; set; }
        }
    }
}
