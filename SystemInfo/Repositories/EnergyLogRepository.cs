using Microsoft.EntityFrameworkCore;
using SystemInfo.Context;
using SystemInfo.Models;

namespace SystemInfo.Repositories
{

    // create interface
    public interface IEnergyLogRepository
    {
        Task<List<EnergyLog>> GetAll();
        Task<EnergyLog> GetEnergyLog(int? id);
        Task<EnergyLog> Create(DateTime ReadingDate, string GeneratedEnergyKWH, string ConsumedEnergyKWH, int EnergyMeterId);
        Task<EnergyLog> Update(int id, DateTime ReadingDate, string GeneratedEnergyKWH, string ConsumedEnergyKWH, int EnergyMeterId);
        Task<EnergyLog> DeleteEnergyLog(int id);
    }
    public class EnergyLogRepository : IEnergyLogRepository
    {
        // we create a variable for the connection
        private readonly SystemContext _db;

        // we do a dependency injection
        public EnergyLogRepository(SystemContext db)
        {
            _db = db;
        }
        public async Task<EnergyLog> Create(DateTime ReadingDate, string GeneratedEnergyKWH, string ConsumedEnergyKWH, int EnergyMeterId)
        {
            EnergyLog energyLog = new EnergyLog
            {
                ReadingDate = ReadingDate,
                GeneratedEnergyKWH = GeneratedEnergyKWH,
                ConsumedEnergyKWH = ConsumedEnergyKWH,
                EnergyMeterId = EnergyMeterId
            };
            await _db.EnergyLogs.AddAsync(energyLog);
            _db.SaveChanges();
            return energyLog;
        }

        public async  Task<EnergyLog> DeleteEnergyLog(int id)
        {
            EnergyLog energyLog = await GetEnergyLog(id);
            if (energyLog != null)
            {
                energyLog.isDeleted = true;
            }
            return energyLog;
        }

        public async Task<List<EnergyLog>> GetAll()
        {
            return await _db.EnergyLogs.ToListAsync();
        }

        public async Task<EnergyLog> GetEnergyLog(int? id)
        {
            return await _db.EnergyLogs.FirstOrDefaultAsync(u => u.EnergyLogId == id);
        }

        public async Task<EnergyLog> Update(int id, DateTime ReadingDate, string GeneratedEnergyKWH, string ConsumedEnergyKWH, int EnergyMeterId)
        {
            EnergyLog energyLog = await GetEnergyLog(id);
            if(energyLog != null)
            {
                energyLog.ReadingDate = ReadingDate;
                energyLog.GeneratedEnergyKWH = GeneratedEnergyKWH;
                energyLog.ConsumedEnergyKWH = ConsumedEnergyKWH;
                energyLog.EnergyMeterId = EnergyMeterId;

                await _db.SaveChangesAsync();
            }
            return energyLog;
        }
    }
}
