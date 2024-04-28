using SystemInfo.Models;
using SystemInfo.Repositories;

namespace SystemInfo.Services
{
    // create interface
    public interface IFarmerService
    {
        Task<List<Farmer>> GetAll();
        Task<Farmer> GetFarmer(int? id);
        Task<Farmer> Create(Farmer farmer);
        Task<Farmer> Update(Farmer farmer);
        Task<Farmer> DeleteFarmer(int? id);
    }
    public class FarmerService : IFarmerService
    {
        public readonly FarmerRepository _farmerRepository;

        public FarmerService(FarmerRepository farmerRepository)
        {
            _farmerRepository = farmerRepository;
        }

        public async Task<Farmer> Create(Farmer farmer)
        {
            Farmer newFarmer = new Farmer
            {
                Name = farmer.Name,
                LastName = farmer.LastName,
                ContactType = farmer.ContactType,
                Contact = farmer.Contact,
                Address = farmer.Address,
            };
            return await _farmerRepository.Create(newFarmer);   
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

        public async Task<Farmer> Update(Farmer farmer)
        {
            Farmer newFarmer = await GetFarmer(farmer.FarmerId);
            if (newFarmer != null)
            {
                if (farmer.Name != null)
                {
                    newFarmer.Name = farmer.Name;
                }
                if (farmer.LastName != null)
                {
                    newFarmer.LastName = farmer.LastName;
                }
                if (farmer.ContactType != null)
                {
                    newFarmer.ContactType = farmer.ContactType;
                }
                if (farmer.Contact != null)
                {
                    newFarmer.Contact = farmer.Contact;
                }
                if (farmer.Address != null)
                {
                    newFarmer.Address = farmer.Address;
                }

                return await _farmerRepository.Update(newFarmer);
            }
            throw new NotImplementedException();
        }
    }
}
