using SystemInfo.Models.GameModels;
using SystemInfo.Repositories.GameRepositories;

namespace SystemInfo.Services.GameServices
{
    // create interface
    public interface IScoreService
    {
        Task<List<Score>> GetAll();
        Task<Score> GetScore(int? id);
        Task<Score> Create(int GameId, string ScoreValue);
        Task<Score> Update(int id, int GameId, string ScoreValue);
        Task<Score> DeleteScore(int id);
    }
    public class ScoreService : IScoreService
    {
        public readonly IScoreRepository _scoreRepository;

        public ScoreService(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        public async Task<Score> Create(int GameId, string ScoreValue)
        {
            return await _scoreRepository.Create(GameId, ScoreValue);
        }

        public async Task<Score> DeleteScore(int id)
        {
            return await _scoreRepository.DeleteScore(id);
        }

        public async Task<List<Score>> GetAll()
        {
            return await _scoreRepository.GetAll();
        }

        public async Task<Score> GetScore(int? id)
        {
            return await _scoreRepository.GetScore(id);
        }

        public async Task<Score> Update(int id, int GameId, string ScoreValue)
        {
            return await _scoreRepository.Update(id, GameId, ScoreValue);
        }
    }
}
