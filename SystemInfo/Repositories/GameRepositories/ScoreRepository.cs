using Microsoft.EntityFrameworkCore;
using SystemInfo.Context;
using SystemInfo.Models.GameModels;

namespace SystemInfo.Repositories.GameRepositories
{  
    // create interface
    public interface IScoreRepository
    {
        Task<List<Score>> GetAll();
        Task<Score> GetScore(int? id);
        Task<Score> Create(int GameId, string ScoreValue);
        Task<Score> Update(int id, int GameId, string ScoreValue);
        Task<Score> DeleteScore(int id);
    }
    public class ScoreRepository : IScoreRepository
    {
        // we create a variable for the connection 
        private readonly SystemContext _db;

        // we do a dependency injection
        public ScoreRepository(SystemContext db)
        {
            _db = db;
        }
        public async Task<Score> Create(int GameId, string ScoreValue)
        {
            Score resultScore = new Score
            {
                GameId = GameId,
                ScoreValue = ScoreValue
            };
            await _db.Scores.AddAsync(resultScore);
            _db.SaveChanges();
            return resultScore;
        }

        public async Task<Score> DeleteScore(int id)
        {
            Score score = await GetScore(id);
            if (score != null)
            {
                score.isDeleted = true;
            }
            return score;
        }

        public async Task<List<Score>> GetAll()
        {
            return await _db.Scores.ToListAsync();
        }

        public async Task<Score> GetScore(int? id)
        {
            return await _db.Scores.FirstOrDefaultAsync(u => u.ScoreId == id);
        }

        public async Task<Score> Update(int id, int GameId, string ScoreValue)
        {
            Score resultScore = await GetScore(id);
            if (resultScore != null)
            {
                resultScore.GameId = GameId;
                resultScore.ScoreValue = ScoreValue;

                await _db.SaveChangesAsync();
            }
            return resultScore;
        }


    }
}
