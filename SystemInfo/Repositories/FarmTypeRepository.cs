using Microsoft.EntityFrameworkCore;
using System.Net;
using SystemInfo.Context;
using SystemInfo.Models;

namespace SystemInfo.Repositories
{
    public interface IFarmTypeRepository
    {
        Task<List<FarmType>> GetAll();
        Task<FarmType> GetFarmType(int? id);
        Task<FarmType> Create(FarmType farmType);
        Task<FarmType> Update(FarmType farmType);
        Task<FarmType> DeleteFarmType(FarmType farmType);
    }
    public class FarmTypeRepository : IFarmTypeRepository
    {
        private readonly SystemContext _db;

        // we do a dependency injection
        public FarmTypeRepository(SystemContext db)
        {
            _db = db;
        }
        public async Task<FarmType> Create(FarmType farmType)
        {
            await _db.FarmTypes.AddAsync(farmType);
            _db.SaveChanges();
            return farmType;
        }

        public Task<FarmType> DeleteFarmType(FarmType farmType)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FarmType>> GetAll()
        {
            return await _db.FarmTypes.ToListAsync();
        }

        public async Task<FarmType> GetFarmType(int? id)
        {
            return await _db.FarmTypes.FirstOrDefaultAsync(u => u.FarmTypeId == id);
        }

        public async Task<FarmType> Update(FarmType farmType)
        {
           _db.FarmTypes.Update(farmType);
            await _db.SaveChangesAsync();
            return farmType;
        }
    }
}
