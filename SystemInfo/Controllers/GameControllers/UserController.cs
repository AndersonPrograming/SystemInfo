using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using SystemInfo.Models.GameModels;
using SystemInfo.Repositories;
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
        public async Task<ActionResult<User>> create([FromBody] CreatingModel model)
        {
            var createUser = await _userService.Create(model.Email, model.Username, model.Password, model.Image);
            if (createUser == null)
            {
                return BadRequest("User not Created");
            }
            return Ok(createUser);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserAuth>> Login([FromBody] LoginModel model)
        {
            var LoginUser = await _userService.Login(model.Username, model.Password);
            if (LoginUser == null)
            {
                return BadRequest("user or password incorrect");
            }
            return Ok(LoginUser);
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public class CreatingModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Image { get; set; }
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
