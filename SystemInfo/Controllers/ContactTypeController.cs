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
        public async Task<ActionResult<ContactType>> create([FromBody] ModelC model)
        {
            var createContactType = await _contactTypeService.Create(model.contacType);
            if (createContactType == null)
            {
                return BadRequest("ContactType not Created");
            }
            return Ok(createContactType);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromBody] ModelCU model)
        {
            var createContactType = await _contactTypeService.Update(model.contacTypeId, model.contacType);
            if (createContactType == null)
            {
                return BadRequest("ContactType not Updated");
            }
            return Ok(createContactType);
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

        public class ModelC
        {
            public string contacType { get; set; }
        }
        public class ModelCU
        {
            public int contacTypeId { get; set; }
            public string contacType { get; set; }
        }
    }
}
