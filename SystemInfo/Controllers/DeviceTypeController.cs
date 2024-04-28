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
        private readonly DeviceTypeService _service;

        public DeviceTypeController(DeviceTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceType>>> GetAll()
        {
            var result = await _service.GetAll();
            if (!result.Any())
            {
                return NotFound(new { message = "DeviceType not found" });
            }

            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceType>> GetDeviceType(int id)
        {
            try
            {
                var deviceType = await _service.GetDeviceType(id);
                return deviceType;
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "DeviceType not found" });
            }
        }
        [HttpPost]
        public async Task<ActionResult<DeviceType>> create(DeviceType deviceType)
        {
            try
            {
                var createDeviceType = await _service.Create(deviceType);
                return CreatedAtAction("GetDeviceType", new { id = createDeviceType.DeviceTypeId }, createDeviceType);
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new { message = "DeviceType cannot be null" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DeviceType deviceType)
        {
            if (id != deviceType.DeviceTypeId)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(deviceType);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "DeviceType not found" });
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceType(int id)
        {
            try
            {
                await _service.DeleteDeviceType(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "DeviceType not found" });
            }
        }
    }
}
