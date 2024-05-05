using SystemInfo.Models;
using SystemInfo.Repositories;

namespace SystemInfo.Services
{
    // create interface
    public interface IFarmerService
    {
        Task<List<Farmer>> GetAll();
        Task<Farmer> GetFarmer(int? id);
        Task<Farmer> Create(string name, string lastname, int contactType, string contact, string address);
        Task<Farmer> Update(int id, string name, string lastname, int contactType, string contact, string address);
        Task<Farmer> DeleteFarmer(int? id);
    }
    public class FarmerService : IFarmerService
    {
        public readonly IFarmerRepository _farmerRepository;

        public FarmerService(IFarmerRepository farmerRepository)
        {
            _farmerRepository = farmerRepository;
        }

        public async Task<Farmer> Create(string name, string lastname, int contactType, string contact, string address)
        {
           
            return await _farmerRepository.Create(name, lastname, contactType, contact, address);   
        }

        public async Task<Farmer> DeleteFarmer(int? id)
        {
            Farmer newFarmer = await GetFarmer(id);
            return await _farmerRepository.DeleteFarmer(newFarmer);
        }

        public async Task<List<Farmer>> GetAll()
        {
            return await _farmerRepository.GetAll();
        }

        public async Task<Farmer> GetFarmer(int? id)
        {
            return await _farmerRepository.GetFarmer(id);
        }

        public async Task<Farmer> Update(int id, string name, string lastname, int contactType, string contact, string address)
        {
          
            return await _farmerRepository.Update(id, name, lastname, contactType, contact, address);
            throw new NotImplementedException();
        }
    }
}
