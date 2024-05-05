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
        Task<Farmer> GetFarmer(int id);
        Task<Farmer> Create(string name, string lastname, int contactType, string contact, string address);
        Task<Farmer> Update(int id, string name, string lastname, int contactType, string contact, string address);
        Task<Farmer> DeleteFarmer(int id);
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
        public async Task<Farmer> Create(string name, string lastname, int contactType, string contact, string address)
        {
            Farmer farmer = new Farmer
            {
                Name = name,
                LastName = lastname,
                ContactTypeId = contactType,
                Contact = contact,
                Address = address
            };

            await _db.Farmers.AddAsync(farmer);
            _db.SaveChanges();
            return farmer;
        }

        public async Task<List<Farmer>> GetAll()
        {
            return await _db.Farmers.ToListAsync();
        }

        public async Task<Farmer> GetFarmer(int id)
        {
            return await _db.Farmers.FirstOrDefaultAsync(u => u.FarmerId == id );
        }


        public async Task<Farmer> DeleteFarmer(int id)
        {
            Farmer farmer = await GetFarmer(id);
            if (farmer != null)
            {
                farmer.isDeleted = true;
            }
            return farmer;
        }

        public async Task<Farmer> Update(int id, string name, string lastname, int contactType, string contact, string address)
        {
            Farmer resultFarmer = await GetFarmer(id);
            if(resultFarmer != null)
            {
                resultFarmer.Name = name;
                resultFarmer.LastName = lastname;
                resultFarmer.ContactTypeId = contactType;
                resultFarmer.Contact = contact;
                resultFarmer.Address = address;

                await _db.SaveChangesAsync();
            }
            return resultFarmer;
        }
    }
}
