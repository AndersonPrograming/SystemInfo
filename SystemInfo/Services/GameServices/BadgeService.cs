using SystemInfo.Models.GameModels;
using SystemInfo.Repositories.GameRepositories;

namespace SystemInfo.Services.GameServices
{
    // create interface
    public interface IBadgeService
    {
        Task<List<Badge>> GetAll();
        Task<Badge> Create(int UserId, string NameBadge, string Description, bool Completed, int Experience, string image);
    }
    public class BadgeService: IBadgeService
    {
        public readonly IBadgeRepository _gameRepository;

        public BadgeService(IBadgeRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Badge> Create(int UserId, string NameBadge, string Description, bool Completed, int Experience, string image)
        {
            return await _gameRepository.Create(UserId, NameBadge, Description, Completed, Experience, image);
        }

        public async Task<List<Badge>> GetAll()
        {
            return await _gameRepository.GetAll();
        }
    }
}
