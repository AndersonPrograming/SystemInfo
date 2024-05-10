using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        Task<UserAuth> Login(string Username, string Password);
        Task<User> Update(int id, string Email, string Username, string Password, string image);
        Task<User> DeleteUser(int id);
        Task<User> GetUserByEmail(string email);
    }
    public class UserRepository : IUserRepository
    {
        // we create a variable for the connection 
        private readonly SystemContext _db;
        private IConfiguration config;


        // we do a dependency injection
        public UserRepository(SystemContext db, IConfiguration config)
        {
            _db = db;
            this.config = config;
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

        public async Task<UserAuth> Login(string Username, string Password)
        {
            User user = await _db.Users.FirstOrDefaultAsync(u => u.Username == Username || u.Email == Username);

            if (user != null && VerifyPassword(Password, user.Password))
            {
                string jwtToken = GenerarToken(user);
                UserAuth userAuth = new UserAuth
                {
                    User = user,
                    Token = jwtToken
                };
                return userAuth;
            }
            return null;
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

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        private string GenerarToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value));
            var credenciales = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature);

            var SecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credenciales);

            var token = new JwtSecurityTokenHandler().WriteToken(SecurityToken);

            return token;
        }


    }


}
