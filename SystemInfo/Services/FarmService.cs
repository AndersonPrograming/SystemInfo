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
        Task<Farm> Create(Farm farm);
        Task<Farm> Update(Farm farm);
        Task<Farm> DeleteFarm(int? id);
    }
    public class FarmService: IFarmService
    {
        public readonly FarmRepository _farmRepository;

        public FarmService(FarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }

        public async Task<Farm> Create(Farm farm)
        {

            Farm newFarm = new Farm
            {
                FarmName = farm.FarmName,
                Location = farm.Location,
                FarmArea = farm.FarmArea,
                FarmType = farm.FarmType,
                Image = farm.Image,
                Farmer = farm.Farmer
            };
            return await _farmRepository.Create(newFarm);
        }

        public async Task<Farm> DeleteFarm(int? id)
        {
            Farm newFarm = await GetFarm(id);
            return await _farmRepository.DeleteFarm(newFarm);
        }

        public async Task<List<Farm>> GetAll()
        {
            return await _farmRepository.GetAll();
        }

        public async Task<Farm> GetFarm(int? id)
        {
            return await _farmRepository.GetFarm(id);
        }

        public async Task<Farm> Update(Farm farm)
        {
            Farm newFarm = await GetFarm(farm.FarmId);
            if (newFarm != null)
            {
                if (farm.FarmName != null)
                {
                    newFarm.FarmName = farm.FarmName;
                }
                if (farm.Location != null)
                {
                    newFarm.Location = farm.Location;
                }
                if (farm.FarmArea != null)
                {
                    newFarm.FarmArea = farm.FarmArea;
                }
                if (farm.FarmType != null)
                {
                    newFarm.FarmType = farm.FarmType;
                }
                if (farm.Image != null)
                {
                    newFarm.Image = farm.Image;
                }
                if (farm.Farmer != null)
                {
                    newFarm.Farmer = farm.Farmer;
                }

                return await _farmRepository.Update(newFarm);
            }
            throw new NotImplementedException();
    
        }
    }
}
