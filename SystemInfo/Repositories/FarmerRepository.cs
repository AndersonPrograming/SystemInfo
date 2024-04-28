using Microsoft.EntityFrameworkCore;
using System.Numerics;
using SystemInfo.Context;
using SystemInfo.Models;

namespace SystemInfo.Repositories
{
    // create interface
    public interface IFarmerRepository
    {
        Task<List<Farmer>> GetAll();
        Task<Farmer> GetFarmer(int? id);
        Task<Farmer> Create(Farmer farmer);
        Task<Farmer> Update(Farmer farmer);
        Task<Farmer> DeleteFarmer(Farmer farmer);
    }
    public class FarmerRepository : IFarmerRepository
    {
        // we create a variable for the connection
        private readonly SystemContext _db;

        // we do a dependency injection
        public FarmerRepository(SystemContext db)
        {
            _db = db;
        }
        public async Task<Farmer> Create(Farmer farmer)
        {
            await _db.Farmers.AddAsync(farmer);
            _db.SaveChanges();
            return farmer;
        }

        public async Task<List<Farmer>> GetAll()
        {
            return await _db.Farmers.ToListAsync();
        }

        public async Task<Farmer> GetFarmer(int? id)
        {
            return await _db.Farmers.FirstOrDefaultAsync(u => u.FarmerId == id );
        }


        public Task<Farmer> DeleteFarmer(Farmer farmer)
        {
            throw new NotImplementedException();
        }

        public async Task<Farmer> Update(Farmer farmer)
        {
            _db.Farmers.Update(farmer);
            await _db.SaveChangesAsync();
            return farmer;
        }
    }
}
