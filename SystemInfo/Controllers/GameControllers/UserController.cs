using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemInfo.Models.GameModels;
using SystemInfo.Services.GameServices;

namespace SystemInfo.Controllers.GameControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<User>> create(string Email, string Username, string Password, string image)
        {
            var createUser = await _userService.Create(Email, Username, Password, image);
            if (createUser == null)
            {
                return BadRequest("User not Created");
            }
            return Ok(createUser);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, string Email, string Username, string Password, string image)
        {
            var createUser = await _userService.Update(id, Email, Username, Password, image);
            if (createUser == null)
            {
                return BadRequest("User not Updated");
            }
            return Ok(createUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var createUser = await _userService.DeleteUser(id);
            if (createUser == null)
            {
                return BadRequest("User not Deleted");
            }
            return Ok(createUser);

        }
    }
}
