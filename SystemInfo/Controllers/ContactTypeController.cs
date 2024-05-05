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
        private readonly IContactTypeService _contactTypeService;

        public ContactTypeController(IContactTypeService contactTypeService)
        {
            _contactTypeService = contactTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactType>>> GetAll()
        {
            return Ok(await _contactTypeService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactType>> GetContactType(int id)
        {
            var contactType = await _contactTypeService.GetContactType(id);
            if (contactType == null)
            {
                return BadRequest("ContactType not found");
            }

            return Ok(contactType);
        }
        [HttpPost]
        public async Task<ActionResult<ContactType>> create(string contactType)
        {
            var createContactType = await _contactTypeService.Create(contactType);
            if (createContactType == null)
            {
                return BadRequest("ContactType not Created");
            }
            return Ok(createContactType);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, string contactType)
        {
            var createContactType = await _contactTypeService.Update(id, contactType);
            if (createContactType == null)
            {
                return BadRequest("ContactType not Updated");
            }
            return Ok(contactType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactType(int id)
        {
            var contactType = await _contactTypeService.DeleteContactType(id);
            if (contactType == null)
            {
                return BadRequest("ContactType not Deleted");
            }
            return Ok(contactType);

        }
    }
}
