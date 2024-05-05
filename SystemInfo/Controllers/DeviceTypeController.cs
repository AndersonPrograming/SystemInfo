using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemInfo.Models;
using SystemInfo.Services;

namespace SystemInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceTypeController : ControllerBase
    {
        private readonly IDeviceTypeService _deviceTypeService;

        public DeviceTypeController(IDeviceTypeService deviceTypeService)
        {
            _deviceTypeService = deviceTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DeviceType>>> GetAll()
        {
            return Ok(await _deviceTypeService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceType>> GetDeviceType(int id)
        {
            var deviceType = await _deviceTypeService.GetDeviceType(id);
            if (deviceType == null)
            {
                return BadRequest("DeviceType not found");
            }

            return Ok(deviceType);
        }
        [HttpPost]
        public async Task<ActionResult<DeviceType>> create(string deviceType)
        {
            var createDeviceType = await _deviceTypeService.Create(deviceType);
            if (createDeviceType == null)
            {
                return BadRequest("DeviceType not Created");
            }
            return Ok(createDeviceType);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, string deviceType)
        {
            var createDeviceType = await _deviceTypeService.Update(id, deviceType);
            if (createDeviceType == null)
            {
                return BadRequest("DeviceType not Updated");
            }
            return Ok(deviceType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceType(int id)
        {
            var deviceType = await _deviceTypeService.DeleteDeviceType(id);
            if (deviceType == null)
            {
                return BadRequest("DeviceType not Deleted");
            }
            return Ok(deviceType);

        }
    }
}
