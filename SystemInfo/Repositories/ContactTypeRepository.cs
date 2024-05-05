using Microsoft.EntityFrameworkCore;
using SystemInfo.Context;
using SystemInfo.Models;

namespace SystemInfo.Repositories
{

    // create interface
    public interface IContactTypeRepository
    {
        Task<List<ContactType>> GetAll();
        Task<ContactType> GetContactType(int? id);
        Task<ContactType> Create(string contactType);
        Task<ContactType> Update(int id, string contactType);
        Task<ContactType> DeleteContactType(int? id);
    }
    public class ContactTypeRepository : IContactTypeRepository
    {
        // we create a variable for the connection 
        private readonly SystemContext _db;

        // we do a dependency injection
        public ContactTypeRepository(SystemContext db)
        {
            _db = db;
        }
        public async Task<ContactType> Create(string contactType)
        {
            ContactType resultContactType = new ContactType
            {
                TypeContact = contactType,
            };
            await _db.ContactTypes.AddAsync(resultContactType);
            _db.SaveChanges();
            return resultContactType;
        }

        public async Task<ContactType> DeleteContactType(int? id)
        {
            ContactType contactType = await GetContactType(id);
            if (contactType != null)
            {
                contactType.isDeleted = true;
            }
            return contactType;
        }

        public async Task<List<ContactType>> GetAll()
        {
            return await _db.ContactTypes.ToListAsync();
        }

        public async Task<ContactType> GetContactType(int? id)
        {
            return await _db.ContactTypes.FirstOrDefaultAsync(u => u.ContactTypeId == id);
        }

        public async Task<ContactType> Update(int id, string contactType)
        {
            ContactType resultContactType = await GetContactType(id);
            if (resultContactType != null)
            {
                resultContactType.TypeContact = contactType;
                await _db.SaveChangesAsync();
            }
            return resultContactType;
        }
    }
}
