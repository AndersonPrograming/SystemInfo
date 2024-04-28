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
        Task<EnergyLog> Create(EnergyLog energyLog);
        Task<EnergyLog> Update(EnergyLog energyLog);
        Task<EnergyLog> DeleteEnergyLog(int? id);
    }
    public class EnergyLogService: IEnergyLogService
    {
        public readonly EnergyLogRepository _energyLogRepository;

        public EnergyLogService(EnergyLogRepository energyLogRepository)
        {
            _energyLogRepository = energyLogRepository;
        }

        public async Task<EnergyLog> Create(EnergyLog energyLog)
        {
            EnergyLog newEnergyLog = new EnergyLog
            {
                ReadingDate = (DateTime)energyLog.ReadingDate,
                GeneratedEnergyKWH = energyLog.GeneratedEnergyKWH,
                ConsumedEnergyKWH = energyLog.ConsumedEnergyKWH,
                EnergyMeter = energyLog.EnergyMeter,

            };
            return await _energyLogRepository.Create(newEnergyLog);
        }

        public async Task<EnergyLog> DeleteEnergyLog(int? id)
        {
            EnergyLog newEnergyLog = await GetEnergyLog(id);  
            return await _energyLogRepository.DeleteEnergyLog(newEnergyLog);
        }

        public async Task<List<EnergyLog>> GetAll()
        {
            return await _energyLogRepository.GetAll();
        }

        public async Task<EnergyLog> GetEnergyLog(int? id)
        {
            return await _energyLogRepository.GetEnergyLog(id);
        }

        public async Task<EnergyLog> Update(EnergyLog energyLog)
        {
            EnergyLog newEnergyLog = await GetEnergyLog(energyLog.EnergyLogId);
            if (newEnergyLog != null)
            {
                if (energyLog.ReadingDate != null)
                {
                    newEnergyLog.ReadingDate = (DateTime)energyLog.ReadingDate;
                }
                if (energyLog.GeneratedEnergyKWH != null)
                {
                    newEnergyLog.GeneratedEnergyKWH = energyLog.GeneratedEnergyKWH;
                }
                if (energyLog.ConsumedEnergyKWH != null)
                {
                    newEnergyLog.ConsumedEnergyKWH = energyLog.ConsumedEnergyKWH;
                }

                return await _energyLogRepository.Update(newEnergyLog);
            }
            throw new NotImplementedException();
           
        }
    }
}
