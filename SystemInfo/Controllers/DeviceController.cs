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
        public async Task<ActionResult<DeviceType>> create(string DeviceBrand, string GenerationCapacity, int FarmId, int EnergyMeterId, int DeviceTypeId)
        {
            var createDevice = await _deviceService.Create(DeviceBrand, GenerationCapacity, FarmId, EnergyMeterId, DeviceTypeId);
            if (createDevice == null)
            {
                return BadRequest("Device not Created");
            }
            return Ok(createDevice);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, string DeviceBrand, string GenerationCapacity, int FarmId, int EnergyMeterId, int DeviceTypeId)
        {
            var createDevice = await _deviceService.Update(id, DeviceBrand, GenerationCapacity, FarmId, EnergyMeterId, DeviceTypeId);
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
    }
}
