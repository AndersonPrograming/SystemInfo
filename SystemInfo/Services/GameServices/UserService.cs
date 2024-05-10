using SystemInfo.Models.GameModels;
using SystemInfo.Repositories.GameRepositories;

namespace SystemInfo.Services.GameServices
{
    // create interface
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetUser(int? id);
        Task<User> Create(string Email, string Username, string Password, string image);
        Task<UserAuth> Login(string Username, string Password);
        Task<User> Update(int id, string Email, string Username, string Password, string image);
        Task<User> DeleteUser(int id);
    }
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Create(string Email, string Username, string Password, string image)
        {
            if(await EmailExists(Email)) {

                return null;
            }
            string PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password);
      

            return await _userRepository.Create(Email, Username, PasswordHash, image);
        }

        public async Task<UserAuth> Login(string Username, string Password)
        {
            return await _userRepository.Login(Username, Password);
        }

        public async Task<User> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUser(int? id)
        {
            return await _userRepository.GetUser(id);
        }

        public async Task<User> Update(int id, string Email, string Username, string Password, string image)
        {
            return await _userRepository.Update(id, Email, Username, Password, image);
        }

        public async Task<bool> EmailExists(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            return user != null;
        }


    }

}
