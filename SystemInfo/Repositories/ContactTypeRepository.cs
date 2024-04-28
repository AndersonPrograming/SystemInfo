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
        Task<ContactType> Create(ContactType contactType);
        Task<ContactType> Update(ContactType contactType);
        Task<ContactType> DeleteContactType(ContactType contactType);
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
        public async Task<ContactType> Create(ContactType contactType)
        {
            await _db.ContactTypes.AddAsync(contactType);
            _db.SaveChanges();
            return contactType;
        }

        public Task<ContactType> DeleteContactType(ContactType contactType)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ContactType>> GetAll()
        {
            return await _db.ContactTypes.ToListAsync();
        }

        public async Task<ContactType> GetContactType(int? id)
        {
            return await _db.ContactTypes.FirstOrDefaultAsync(u => u.ContactTypeId == id);
        }

        public async Task<ContactType> Update(ContactType contactType)
        {
            _db.ContactTypes.Update(contactType);
            await _db.SaveChangesAsync();
            return contactType;
        }
    }
}
