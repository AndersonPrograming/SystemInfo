using SystemInfo.Models;
using SystemInfo.Models.GameModels;
using SystemInfo.Repositories;

namespace SystemInfo.Services
{
    public interface ILoginService
    {
        Task<User> Login(string Username, string Password);

    }
    public class LoginService : ILoginService
    {
        public readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<User> Login(string Username, string Password)
        {
            return await _loginRepository.Login(Username, Password);
        }
    }
}
