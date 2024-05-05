using Microsoft.EntityFrameworkCore;
using SystemInfo.Context;
using SystemInfo.Models;
using SystemInfo.Models.GameModels;

namespace SystemInfo.Repositories.GameRepositories
{
    // create interface
    public interface IGameRepository
    {
        Task<List<Game>> GetAll();
        Task<Game> GetGame(int? id);
        Task<Game> Create(int UserId, DateTime GameDate, string EnergyType);
        Task<Game> Update(int id, int UserId, DateTime GameDate, string EnergyType);
        Task<Game> DeleteGame(int id);
    }
    public class GameRepository : IGameRepository
    {
        // we create a variable for the connection 
        private readonly SystemContext _db;

        // we do a dependency injection
        public GameRepository(SystemContext db)
        {
            _db = db;
        }
        public async Task<Game> Create(int UserId, DateTime GameDate, string EnergyType)
        {
            Game resultGame = new Game
            {
                UserId = UserId,
                GameDate = GameDate,
                EnergyType = EnergyType
            };
            await _db.Games.AddAsync(resultGame);
            _db.SaveChanges();
            return resultGame;
        }

        public async Task<Game> DeleteGame(int id)
        {
            Game game = await GetGame(id);
            if (game != null)
            {
                game.isDeleted = true;
            }
            return game;
        }

        public async Task<List<Game>> GetAll()
        {
            return await _db.Games.ToListAsync();
        }

        public async Task<Game> GetGame(int? id)
        {
            return await _db.Games.FirstOrDefaultAsync(u => u.GameId == id);
        }

        public async Task<Game> Update(int id, int UserId, DateTime GameDate, string EnergyType)
        {
            Game resultGame = await GetGame(id);
            if(resultGame != null)
            {
                resultGame.UserId = UserId;
                resultGame.GameDate = GameDate;
                resultGame.EnergyType = EnergyType;

                await _db.SaveChangesAsync();
            }
            return resultGame;
        }

     
    }
}
