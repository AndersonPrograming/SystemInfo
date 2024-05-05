using Microsoft.AspNetCore.Http.HttpResults;
using SystemInfo.Models;
using SystemInfo.Repositories;

namespace SystemInfo.Services
{
    public interface IFarmTypeService
    {
        Task<List<FarmType>> GetAll();
        Task<FarmType> GetFarmType(int id);
        Task<FarmType> Create(string FarmType);
        Task<FarmType> Update(int id, string FarmType);
        Task<FarmType> DeleteFarmType(int id);
    }
    public class FarmTypeService: IFarmTypeService
    {
        public readonly IFarmTypeRepository _farmTypeRepository;

        public FarmTypeService(IFarmTypeRepository farmTypeRepository)
        {
            _farmTypeRepository = farmTypeRepository;
        }

        public async Task<FarmType> Create(string FarmType)
        {
            return await _farmTypeRepository.Create(FarmType);
        }

        public async Task<FarmType> DeleteFarmType(int id)
        {

            return await _farmTypeRepository.DeleteFarmType(id);
        }

        public async Task<List<FarmType>> GetAll()
        {
            return await _farmTypeRepository.GetAll();
        }

        public async Task<FarmType> GetFarmType(int id)
        {
            return await _farmTypeRepository.GetFarmType(id);
        }

        public async Task<FarmType> Update(int id, string FarmType)
        {
            return await _farmTypeRepository.Update(id, FarmType);

            throw new NotImplementedException();
        }
    }
}
