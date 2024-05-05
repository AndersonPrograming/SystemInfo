using Microsoft.EntityFrameworkCore;
using SystemInfo.Context;
using SystemInfo.Models;
using SystemInfo.Models.GameModels;

namespace SystemInfo.Repositories.GameRepositories
{
    // create interface
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetUser(int? id);
        Task<User> Create(string Email, string Username, string Password, string image);
        Task<User> Update(int id, string Email, string Username, string Password, string image);
        Task<User> DeleteUser(int id);
        Task<User> GetUserByEmail(string email);
    }
    public class UserRepository : IUserRepository
    {
        // we create a variable for the connection 
        private readonly SystemContext _db;

        // we do a dependency injection
        public UserRepository(SystemContext db)
        {
            _db = db;
        }
        public async Task<User> Create(string Email, string Username, string Password, string image)
        {
            User resultUser = new User
            {
                Email = Email,
                Username = Username,
                Password = Password,
                Image = image
            };
            await _db.Users.AddAsync(resultUser);
            _db.SaveChanges();
            return resultUser;
        }

        public async Task<User> DeleteUser(int id)
        {
            User user = await GetUser(id);
            if (user != null)
            {
                user.isDeleted = true;
            }
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> GetUser(int? id)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> Update(int id, string Email, string Username, string Password, string image)
        {
            User resultUser = await GetUser(id);
            if (resultUser != null)
            {
                resultUser.Email = Email;
                resultUser.Username = Username;
                resultUser.Password = Password;
                resultUser.Image = image;

                await _db.SaveChangesAsync();
            }
            return resultUser;
        }


    }
}
