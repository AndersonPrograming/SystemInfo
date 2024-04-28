using System.Security.Cryptography;
using SystemInfo.Models;
using SystemInfo.Repositories;

namespace SystemInfo.Services
{
    // create interface
    public interface IContactTypeService
    {
        Task<List<ContactType>> GetAll();
        Task<ContactType> GetContactType(int? id);
        Task<ContactType> Create(ContactType TypeContact);
        Task<ContactType> Update(ContactType TypeContact);
        Task<ContactType> DeleteContactType(int? id);
    }
    public class ContactTypeService: IContactTypeService
    {
        public readonly ContactTypeRepository _contactTypeRepository;

        public ContactTypeService(ContactTypeRepository contactTypeRepository)
        {
            _contactTypeRepository = contactTypeRepository;
        }

        public async Task<ContactType> Create(ContactType TypeContact)
        {
            ContactType newContactType = new ContactType
            {
                TypeContact = TypeContact.TypeContact,
            };

            return await _contactTypeRepository.Create(newContactType);
        }

        public async Task<ContactType> DeleteContactType(int? id)
        {
            ContactType newContactType = await GetContactType(id);

            return await _contactTypeRepository.DeleteContactType(newContactType);
        }

        public async Task<List<ContactType>> GetAll()
        {
            return await _contactTypeRepository.GetAll();   
        }

        public async Task<ContactType> GetContactType(int? id)
        {
            return await _contactTypeRepository.GetContactType(id);
        }

        public async Task<ContactType> Update(ContactType TypeContact)
        {
            ContactType newContactType = await GetContactType(TypeContact.ContactTypeId);
            if (newContactType != null)
            {
                if (TypeContact != null)
                {
                    newContactType.TypeContact = TypeContact.TypeContact;
                }

                return await _contactTypeRepository.Update(newContactType);
            }
            throw new NotImplementedException();
        }
    }
}
