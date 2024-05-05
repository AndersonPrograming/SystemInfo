using System.Runtime.InteropServices;
using SystemInfo.Models;
using SystemInfo.Models.GameModels;
using SystemInfo.Repositories;
using SystemInfo.Repositories.GameRepositories;

namespace SystemInfo.Services.GameServices
{
    // create interface
    public interface IGameService
    {
        Task<List<Game>> GetAll();
        Task<Game> GetGame(int? id);
        Task<Game> Create(int UserId, DateTime GameDate, string EnergyType);
        Task<Game> Update(int id, int UserId, DateTime GameDate, string EnergyType);
        Task<Game> DeleteGame(int id);
    }
    public class GameService : IGameService
    {
        public readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Game> Create(int UserId, DateTime GameDate, string EnergyType)
        {
            return await _gameRepository.Create(UserId, GameDate, EnergyType);
        }

        public async Task<Game> DeleteGame(int id)
        {
            return await _gameRepository.DeleteGame(id);
        }

        public async Task<List<Game>> GetAll()
        {
            return await _gameRepository.GetAll();
        }

        public async Task<Game> GetGame(int? id)
        {
           return await _gameRepository.GetGame(id);
        }

        public async Task<Game> Update(int id, int UserId, DateTime GameDate, string EnergyType)
        {
            return await _gameRepository.Update(id, UserId, GameDate, EnergyType);
        }
    }
}
