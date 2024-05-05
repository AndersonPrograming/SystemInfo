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
        Task<EnergyMeter> GetEnergyMeter(int? id);
        Task<EnergyMeter> Create(string energyMeterBrand, DateTime instalationDate);
        Task<EnergyMeter> Update(int id, string energyMeterBrand, DateTime instalationDate);
        Task<EnergyMeter> DeleteEnergyMeter(int id);
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
        public async Task<EnergyMeter> Create(string energyMeterBrand, DateTime instalationDate)
        {
            EnergyMeter energyMeter = new EnergyMeter
            {
                EnergyMeterBrand = energyMeterBrand,
                InstalationDate = instalationDate
            };
            await _db.EnergyMeters.AddAsync(energyMeter);
            _db.SaveChanges();
            return energyMeter;
        }

        public async Task<EnergyMeter> DeleteEnergyMeter(int id)
        {
            EnergyMeter energyMeter = await GetEnergyMeter(id);
            if (energyMeter != null)
            {
                energyMeter.isDeleted = true;
            }
            return energyMeter;
        }

        public async Task<List<EnergyMeter>> GetAll()
        {
            return await _db.EnergyMeters.ToListAsync();
        }

        public async Task<EnergyMeter> GetEnergyMeter(int? id)
        {
            return await _db.EnergyMeters.FirstOrDefaultAsync(u => u.EnergyMeterId == id);
        }

        public async Task<EnergyMeter> Update(int id, string energyMeterBrand, DateTime instalationDate)
        {
            EnergyMeter resultEnergyMeter = await GetEnergyMeter(id);
            if(resultEnergyMeter != null)
            {
                resultEnergyMeter.EnergyMeterBrand = energyMeterBrand;
                resultEnergyMeter.InstalationDate = instalationDate;

                await _db.SaveChangesAsync();
            }
            
            return resultEnergyMeter;
        }
    }
}
