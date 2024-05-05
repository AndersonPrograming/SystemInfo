using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemInfo.Models.GameModels;
using SystemInfo.Services;
using SystemInfo.Services.GameServices;

namespace SystemInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Login(string Username, string Password)
        {
            var login = await _loginService.Login(Username, Password);
            if (login == null)
            {
                return BadRequest("Username or Password Incorrect");
            }
            return Ok(login);
        }

    }
}
