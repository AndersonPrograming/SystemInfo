using SystemInfo.Context;
using SystemInfo.Models;
using SystemInfo.Repositories;

namespace SystemInfo.Services
{
    // create interface
    public interface IFarmService
    {
        Task<List<Farm>> GetAll();
        Task<Farm> GetFarm(int? id);
        Task<Farm> Create(string farmName, string location, string farmArea, string image, int farmerId, int farmTypeId);
        Task<Farm> Update(int id, string farmName, string location, string farmArea, string image, int farmerId, int farmTypeId);
        Task<Farm> DeleteFarm(int? id);
    }
    public class FarmService: IFarmService
    {
        public readonly IFarmRepository _farmRepository;

        public FarmService(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }

        public async Task<Farm> Create(string farmName, string location, string farmArea, string image, int farmerId, int farmTypeId)
        {
            return await _farmRepository.Create( farmName, location, farmArea, image, farmerId, farmTypeId);
        }

        public async Task<Farm> DeleteFarm(int? id)
        {
            Farm newFarm = await GetFarm(id);
            return await _farmRepository.DeleteFarm(id);
        }

        public async Task<List<Farm>> GetAll()
        {
            return await _farmRepository.GetAll();
        }

        public async Task<Farm> GetFarm(int? id)
        {
            return await _farmRepository.GetFarm(id);
        }

        public async Task<Farm> Update(int id, string farmName, string location, string farmArea, string image, int farmerId, int farmTypeId)
        {
 
            return await _farmRepository.Update(id, farmName, location, farmArea, image, farmerId, farmTypeId);
            throw new NotImplementedException();
    
        }
    }
}
