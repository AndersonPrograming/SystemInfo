using Microsoft.EntityFrameworkCore;
using System.Net;
using SystemInfo.Context;
using SystemInfo.Models;

namespace SystemInfo.Repositories
{
    // create interface
    public interface IFarmRepository
    {
        Task<List<Farm>> GetAll();
        Task<Farm> GetFarm(int? id);
        Task<Farm> Create(Farm farm);
        Task<Farm> Update(Farm farm);
        Task<Farm> DeleteFarm(Farm farm);
    }
    public class FarmRepository : IFarmRepository
    {
        // we create a variable for the connection
        private readonly SystemContext _db;

        // we do a dependency injection
        public FarmRepository(SystemContext db)
        {
            _db = db;
        }
        public async Task<Farm> Create(Farm farm)
        {
            await _db.Farms.AddAsync(farm);
            _db.SaveChanges();
            return farm;
        }

        public Task<Farm> DeleteFarm(Farm farm)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Farm>> GetAll()
        {
            return await _db.Farms.ToListAsync();
        }

        public async Task<Farm> GetFarm(int? id)
        {
            return await _db.Farms.FirstOrDefaultAsync(u => u.FarmId == id);
        }

        public async Task<Farm> Update(Farm farm)
        {
           _db.Farms.Update(farm);
            await _db.SaveChangesAsync();
            return farm;
        }
    }
}
