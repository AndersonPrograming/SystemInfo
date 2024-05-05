using Microsoft.EntityFrameworkCore;
using SystemInfo.Context;
using SystemInfo.Models;

namespace SystemInfo.Repositories
{

    // create interface
    public interface IDeviceTypeRepository
    {
        Task<List<DeviceType>> GetAll();
        Task<DeviceType> GetDeviceType(int? id);
        Task<DeviceType> Create(string deviceType);
        Task<DeviceType> Update(int id, string deviceType);
        Task<DeviceType> DeleteDeviceType(int id);
    }
    public class DeviceTypeRepository: IDeviceTypeRepository
    {
        // we create a variable for the connection
        private readonly SystemContext _db;

        // we do a dependency injection
        public DeviceTypeRepository(SystemContext db)
        {
            _db = db;
        }

        public async Task<DeviceType> Create(string deviceType)
        {
            DeviceType resultDeviceType = new DeviceType
            {
                TypeDevice = deviceType,
            };
            await _db.DeviceTypes.AddAsync(resultDeviceType);
            _db.SaveChanges();
            return resultDeviceType;
        }

        public async Task<DeviceType> DeleteDeviceType(int id)
        {
            DeviceType deviceType = await GetDeviceType(id);
            if (deviceType != null)
            {
                deviceType.isDeleted = true;
            }
            return deviceType;
        }

        public async Task<List<DeviceType>> GetAll()
        {
            return await _db.DeviceTypes.ToListAsync();
        }

        public async Task<DeviceType> GetDeviceType(int? id)
        {
            return await _db.DeviceTypes.FirstOrDefaultAsync(u => u.DeviceTypeId == id);
        }

        public async Task<DeviceType> Update(int id, string deviceType)
        {
            DeviceType resultDeviceType = await GetDeviceType(id);
            if (resultDeviceType != null)
            {
                resultDeviceType.TypeDevice = deviceType;

                await _db.SaveChangesAsync();
            }
            
            return resultDeviceType;
        }
    }
}
