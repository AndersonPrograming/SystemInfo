using Microsoft.EntityFrameworkCore;
using System.Net;
using SystemInfo.Context;
using SystemInfo.Models;

namespace SystemInfo.Repositories
{
    public interface IFarmTypeRepository
    {
        Task<List<FarmType>> GetAll();
        Task<FarmType> GetFarmType(int id);
        Task<FarmType> Create(string farmType);
        Task<FarmType> Update(int id, string farmType);
        Task<FarmType> DeleteFarmType(int id);
    }
    public class FarmTypeRepository : IFarmTypeRepository
    {
        private readonly SystemContext _db;

        // we do a dependency injection
        public FarmTypeRepository(SystemContext db)
        {
            _db = db;
        }
        public async Task<FarmType> Create(string farmType)
        {
            FarmType newFarmType = new FarmType
            {
                TypeFarm = farmType,

            };

            await _db.FarmTypes.AddAsync(newFarmType);
            _db.SaveChanges();
            return newFarmType;
        }

        public async Task<FarmType> DeleteFarmType(int id)
        {
            FarmType farmType = await GetFarmType(id);
            if(farmType != null)
            {
                farmType.isDeleted = true;
            }
            return farmType;
        }

        public async Task<List<FarmType>> GetAll()
        {
            return await _db.FarmTypes.ToListAsync();
        }

        public async Task<FarmType> GetFarmType(int id)
        {
            return await _db.FarmTypes.FirstOrDefaultAsync(u => u.FarmTypeId == id);
        }

        public async Task<FarmType> Update(int id, string farmType)
        {
            FarmType reultFarmType = await GetFarmType(id);

            if(reultFarmType != null)
            {
                reultFarmType.TypeFarm = farmType;

                await _db.SaveChangesAsync();
            }

            return reultFarmType;
        }
    }
}
