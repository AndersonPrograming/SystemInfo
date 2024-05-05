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
        Task<Farm> GetFarm(int id);
        Task<Farm> Create(string farmName, string location, string farmArea, string image, int farmerId, int farmTypeId);
        Task<Farm> Update(int id, string farmName, string location, string farmArea, string image, int farmerId, int farmTypeId);
        Task<Farm> DeleteFarm(int id);
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
        public async Task<Farm> Create(string farmName, string location, string farmArea, string image, int farmerId, int farmTypeId)
        {
            Farm resultFarm = new Farm
            {
                FarmName = farmName,
                Location = location,
                FarmArea = farmArea,
                Image = image,
                FarmerId = farmerId,
                FarmTypeId = farmTypeId

            };
            await _db.Farms.AddAsync(resultFarm);
            _db.SaveChanges();
            return resultFarm;
        }

        public async Task<Farm> DeleteFarm(int id)
        {
            Farm farm = await GetFarm(id);
            if (farm != null)
            {
                farm.isDeleted = true;
            }
            return farm;
        }

        public async Task<List<Farm>> GetAll()
        {
            return await _db.Farms.ToListAsync();
        }

        public async Task<Farm> GetFarm(int id)
        {
            return await _db.Farms.FirstOrDefaultAsync(u => u.FarmId == id);
        }

        public async Task<Farm> Update(int id, string farmName, string location, string farmArea, string image, int farmerId, int farmTypeId)
        {
            Farm resultFarm = await GetFarm(id);
            if(resultFarm != null)
            {
                resultFarm.FarmName = farmName;
                resultFarm.Location = location;
                resultFarm.FarmArea = farmArea;
                resultFarm.Image = image;
                resultFarm.FarmerId = farmerId;
                resultFarm.FarmTypeId = farmTypeId;

                await _db.SaveChangesAsync();

            }
            
            return resultFarm;
        }
    }
}
