using SystemInfo.Models;
using SystemInfo.Repositories;

namespace SystemInfo.Services
{
    public interface IFarmTypeService
    {
        Task<List<FarmType>> GetAll();
        Task<FarmType> GetFarmType(int? id);
        Task<FarmType> Create(FarmType FarmType);
        Task<FarmType> Update(FarmType FarmType);
        Task<FarmType> DeleteFarmType(int? id);
    }
    public class FarmTypeService: IFarmTypeService
    {
        public readonly FarmTypeRepository _farmTypeRepository;

        public FarmTypeService(FarmTypeRepository farmTypeRepository)
        {
            _farmTypeRepository = farmTypeRepository;
        }

        public async Task<FarmType> Create(FarmType FarmType)
        {
            FarmType newFarmType = new FarmType
            {
                TypeFarm = FarmType.TypeFarm,

            };

            return await _farmTypeRepository.Create(newFarmType);
        }

        public async Task<FarmType> DeleteFarmType(int? id)
        {
            FarmType newFarmType = await GetFarmType(id);
            return await _farmTypeRepository.DeleteFarmType(newFarmType);
        }

        public async Task<List<FarmType>> GetAll()
        {
            return await _farmTypeRepository.GetAll();
        }

        public async Task<FarmType> GetFarmType(int? id)
        {
            return await _farmTypeRepository.GetFarmType(id);
        }

        public async Task<FarmType> Update(FarmType FarmType)
        {
            FarmType newFarmType = await GetFarmType(FarmType.FarmTypeId);
            if (newFarmType != null)
            {
                if (FarmType.TypeFarm != null)
                {
                    newFarmType.TypeFarm = FarmType.TypeFarm;
                }

                return await _farmTypeRepository.Update(newFarmType);
            }
            throw new NotImplementedException();
        }
    }
}
