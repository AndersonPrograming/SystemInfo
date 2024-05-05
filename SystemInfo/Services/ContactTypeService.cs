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
        Task<ContactType> Create(string TypeContact);
        Task<ContactType> Update(int id, string TypeContact);
        Task<ContactType> DeleteContactType(int? id);
    }
    public class ContactTypeService: IContactTypeService
    {
        public readonly IContactTypeRepository _contactTypeRepository;

        public ContactTypeService(IContactTypeRepository contactTypeRepository)
        {
            _contactTypeRepository = contactTypeRepository;
        }

        public async Task<ContactType> Create(string typeContact)
        {
            return await _contactTypeRepository.Create(typeContact);
        }

        public async Task<ContactType> DeleteContactType(int? id)
        {
            return await _contactTypeRepository.DeleteContactType(id);
        }

        public async Task<List<ContactType>> GetAll()
        {
            return await _contactTypeRepository.GetAll();   
        }

        public async Task<ContactType> GetContactType(int? id)
        {
            return await _contactTypeRepository.GetContactType(id);
        }

        public async Task<ContactType> Update(int id, string typeContact)
        {
            return await _contactTypeRepository.Update(id, typeContact);
        }
    }
}
