using Microsoft.EntityFrameworkCore;
using SystemInfo.Context;
using SystemInfo.Models.GameModels;

namespace SystemInfo.Repositories.GameRepositories
{
    // create interface
    public interface IBadgeRepository
    {
        Task<List<Badge>> GetAll();
        Task<Badge> Create(int UserId, string NameBadge, string Description, bool Completed, int Experience, string image);
    }
    public class BadgeRepository : IBadgeRepository
    {
        private readonly SystemContext _db;

        // we do a dependency injection
        public BadgeRepository(SystemContext db)
        {
            _db = db;
        }
        public async Task<Badge> Create(int UserId, string NameBadge, string Description, bool Completed, int Experience, string image)
        {
            Badge resultGame = new Badge
            {
                UserId = UserId,
                NameBadge = NameBadge,
                Description = Description,
                Completed = Completed,
                Experience = Experience,
                Image = image
            };
            await _db.Badges.AddAsync(resultGame);
            _db.SaveChanges();
            return resultGame;
        }

        public async Task<List<Badge>> GetAll()
        {
            return await _db.Badges.ToListAsync();
        }
    }
}
