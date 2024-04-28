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
        Task<EnergyLog> Create(EnergyLog energyLog);
        Task<EnergyLog> Update(EnergyLog energyLog);
        Task<EnergyLog> DeleteEnergyLog(EnergyLog energyLog);
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
        public async Task<EnergyLog> Create(EnergyLog energyLog)
        {
            await _db.EnergyLogs.AddAsync(energyLog);
            _db.SaveChanges();
            return energyLog;
        }

        public Task<EnergyLog> DeleteEnergyLog(EnergyLog energyLog)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EnergyLog>> GetAll()
        {
            return await _db.EnergyLogs.ToListAsync();
        }

        public async Task<EnergyLog> GetEnergyLog(int? id)
        {
            return await _db.EnergyLogs.FirstOrDefaultAsync(u => u.EnergyLogId == id);
        }

        public async Task<EnergyLog> Update(EnergyLog energyLog)
        {
           _db.EnergyLogs.Update(energyLog);
            await _db.SaveChangesAsync();
            return energyLog;
        }
    }
}
