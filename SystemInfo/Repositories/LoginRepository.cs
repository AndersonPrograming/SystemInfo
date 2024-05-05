using Microsoft.EntityFrameworkCore;
using SystemInfo.Context;
using SystemInfo.Models;
using SystemInfo.Models.GameModels;

namespace SystemInfo.Repositories
{
    public interface ILoginRepository
    {
        Task<User> Login(string Username, string Password);
    }
    public class LoginRepository: ILoginRepository
    {
        private readonly SystemContext _db;

        // we do a dependency injection
        public LoginRepository(SystemContext db)
        {
            _db = db;
        }

        public async Task<User> Login(string Username, string Password)
        {
            User user = await _db.Users.FirstOrDefaultAsync(u => u.Username == Username);
            if (user == null)
            {
               return null;
            }
            if (VerifyPassword(Password, user.Password))
            {
                return user;
            }
            return null;

        }
        private bool VerifyPassword(string password, string hashedPassword)
        {
            // Verificar si la contraseña proporcionada coincide con la contraseña almacenada
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
