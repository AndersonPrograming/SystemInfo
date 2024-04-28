using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemInfo.Models;
using SystemInfo.Services;

namespace SystemInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypeController : ControllerBase
    {
        private readonly ContactTypeService _service;

        public ContactTypeController(ContactTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactType>>> GetAll()
        {
            var result = await _service.GetAll();
            if (!result.Any())
            {
                return NotFound(new { message = "Farmer not found" });
            }

            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactType>> GetContactType(int id)
        {
            try
            {
                var contactType = await _service.GetContactType(id);
                return contactType;
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Farmer not found" });
            }
        }
        [HttpPost]
        public async Task<ActionResult<ContactType>> Create(ContactType contactType)
        {
            try
            {
                var createContactType = await _service.Create(contactType);
                return CreatedAtAction("GetContactType", new { id = createContactType.ContactTypeId }, createContactType);
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new { message = "ContatType cannot be null." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ContactType contactType)
        {
            if (id != contactType.ContactTypeId)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(contactType);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "ContactType not found" });
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmer(int id)
        {
            try
            {
                await _service.DeleteContactType(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "ContactType not found" });
            }
        }
    }
}
