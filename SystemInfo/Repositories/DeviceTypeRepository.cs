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
        Task<DeviceType> Create(DeviceType deviceType);
        Task<DeviceType> Update(DeviceType deviceType);
        Task<DeviceType> DeleteDeviceType(DeviceType deviceType);
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

        public async Task<DeviceType> Create(DeviceType deviceType)
        {
            await _db.DeviceTypes.AddAsync(deviceType);
            _db.SaveChanges();
            return deviceType;
        }

        public Task<DeviceType> DeleteDeviceType(DeviceType deviceType)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DeviceType>> GetAll()
        {
            return await _db.DeviceTypes.ToListAsync();
        }

        public async Task<DeviceType> GetDeviceType(int? id)
        {
            return await _db.DeviceTypes.FirstOrDefaultAsync(u => u.DeviceTypeId == id);
        }

        public async Task<DeviceType> Update(DeviceType deviceType)
        {
            _db.DeviceTypes.Update(deviceType);
            await _db.SaveChangesAsync();
            return deviceType;
        }
    }
}
