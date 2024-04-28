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
        private readonly DeviceService _service;

        public DeviceController(DeviceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetAll()
        {
            var result = await _service.GetAll();
            if (!result.Any())
            {
                return NotFound(new { message = "Devices not found" });
            }

            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            try
            {
                var device = await _service.GetDevice(id);
                return device;
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Device not found" });
            }
        }
        [HttpPost]
        public async Task<ActionResult<Device>> create(Device device)
        {
            try
            {
                var createDevice = await _service.Create(device);
                return CreatedAtAction("GetDevice", new { id = createDevice.DeviceId }, createDevice);
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new { message = "Device cannot be null" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Device device)
        {
            if (id != device.DeviceId)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(device);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Device not found" });
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            try
            {
                await _service.DeleteDevice(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Device not found" });
            }
        }
    }
}
