using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemInfo.Models;
using SystemInfo.Services;

namespace SystemInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Device>>> GetAll()
        {
            return Ok(await _deviceService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            var device = await _deviceService.GetDevice(id);
            if (device == null)
            {
                return BadRequest("Device not found");
            }

            return Ok(device);
        }
        [HttpPost]
        public async Task<ActionResult<Device>> create([FromBody] DeviceModel model)
        {
            var createDevice = await _deviceService.Create(model.deviceBrand, model.generationCapacity, model.farmId, model.energyMeterId, model.deviceTypeId);
            if (createDevice == null)
            {
                return BadRequest("Device not Created");
            }
            return Ok(createDevice);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] DeviceModelU model)
        {
            var createDevice = await _deviceService.Update(model.id, model.deviceBrand, model.generationCapacity, model.farmId, model.energyMeterId, model.deviceTypeId);
            if (createDevice == null)
            {
                return BadRequest("Device not Updated");
            }
            return Ok(createDevice);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _deviceService.DeleteDevice(id);
            if (device == null)
            {
                return BadRequest("Device not Deleted");
            }
            return Ok(device);

        }

        public class DeviceModel
        {
            public string deviceBrand { get; set; }
            public string generationCapacity { get; set; }
            public int farmId { get; set; }
            public int energyMeterId { get; set; }
            public int deviceTypeId { get; set; }
        }
        public class DeviceModelU
        {
            public int id { get; set; }
            public string deviceBrand { get; set; }
            public string generationCapacity { get; set; }
            public int farmId { get; set; }
            public int energyMeterId { get; set; }
            public int deviceTypeId { get; set; }
        }
    }
}
