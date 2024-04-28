using Microsoft.EntityFrameworkCore;
using System.Net;
using SystemInfo.Context;
using SystemInfo.Models;

namespace SystemInfo.Repositories
{
    // create interface
    public interface IEnergyMeterRepository
    {
        Task<List<EnergyMeter>> GetAll();
        Task<EnergyMeter> GetEnergyMeter(int id);
        Task<EnergyMeter> Create(EnergyMeter energyMeter);
        Task<EnergyMeter> Update(EnergyMeter energyMeter);
        Task<EnergyMeter> DeleteEnergyMeter(EnergyMeter energyMeter);
    }
    public class EnergyMeterRepository : IEnergyMeterRepository
    {
        // we create a variable for the connection
        private readonly SystemContext _db;

        // we do a dependency injection
        public EnergyMeterRepository(SystemContext db)
        {
            _db = db;
        }
        public async Task<EnergyMeter> Create(EnergyMeter energyMeter)
        {
            await _db.EnergyMeters.AddAsync(energyMeter);
            _db.SaveChanges();
            return energyMeter;
        }

        public Task<EnergyMeter> DeleteEnergyMeter(EnergyMeter energyMeter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EnergyMeter>> GetAll()
        {
            return await _db.EnergyMeters.ToListAsync();
        }

        public async Task<EnergyMeter> GetEnergyMeter(int id)
        {
            return await _db.EnergyMeters.FirstOrDefaultAsync(u => u.EnergyMeterId == id);
        }

        public async Task<EnergyMeter> Update(EnergyMeter energyMeter)
        {
            _db.EnergyMeters.Update(energyMeter);
            await _db.SaveChangesAsync();
            return energyMeter;
        }
    }
}
