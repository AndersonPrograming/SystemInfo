using Microsoft.VisualBasic;
using SystemInfo.Models;
using SystemInfo.Repositories;

namespace SystemInfo.Services
{
    // create interface
    public interface IEnergyLogService
    {
        Task<List<EnergyLog>> GetAll();
        Task<EnergyLog> GetEnergyLog(int? id);
        Task<EnergyLog> Create(DateTime ReadingDate, string GeneratedEnergyKWH, string ConsumedEnergyKWH, int EnergyMeterId);
        Task<EnergyLog> Update(int id, DateTime ReadingDate, string GeneratedEnergyKWH, string ConsumedEnergyKWH, int EnergyMeterId);
        Task<EnergyLog> DeleteEnergyLog(int id);
    }
    public class EnergyLogService: IEnergyLogService
    {
        public readonly IEnergyLogRepository _energyLogRepository;

        public EnergyLogService(IEnergyLogRepository energyLogRepository)
        {
            _energyLogRepository = energyLogRepository;
        }

        public async Task<EnergyLog> Create(DateTime ReadingDate, string GeneratedEnergyKWH, string ConsumedEnergyKWH, int EnergyMeterId)
        {
            return await _energyLogRepository.Create(ReadingDate, GeneratedEnergyKWH, ConsumedEnergyKWH, EnergyMeterId);
        }

        public async Task<EnergyLog> DeleteEnergyLog(int id)
        {
            return await _energyLogRepository.DeleteEnergyLog(id);
        }

        public async Task<List<EnergyLog>> GetAll()
        {
            return await _energyLogRepository.GetAll();
        }

        public async Task<EnergyLog> GetEnergyLog(int? id)
        {
            return await _energyLogRepository.GetEnergyLog(id);
        }

        public async Task<EnergyLog> Update(int id, DateTime ReadingDate, string GeneratedEnergyKWH, string ConsumedEnergyKWH, int EnergyMeterId)
        {
            return await _energyLogRepository.Update(id, ReadingDate, GeneratedEnergyKWH, ConsumedEnergyKWH, EnergyMeterId);
            throw new NotImplementedException();
        }
    }
}
