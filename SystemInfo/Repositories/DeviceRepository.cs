using Microsoft.EntityFrameworkCore;
using SystemInfo.Context;
using SystemInfo.Models;

namespace SystemInfo.Repositories
{
    // create interface
    public interface IDeviceRepository
    {
        Task<List<Device>> GetAll();
        Task<Device> GetDevice(int? id);
        Task<Device> Create(Device device);
        Task<Device> Update(Device device);
        Task<Device> DeleteDevice(Device device);
    }
    public class DeviceRepository: IDeviceRepository
    {
        // we create a variable for the connection
        private readonly SystemContext _db;

        // we do a dependency injection
        public DeviceRepository(SystemContext db)
        {
            _db = db;
        }

        public async Task<Device> Create(Device device)
        {
            await _db.Devices.AddAsync(device);
            _db.SaveChanges();
            return device;
        }

        public Task<Device> DeleteDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Device>> GetAll()
        {
            return await _db.Devices.ToListAsync();
        }

        public async Task<Device> GetDevice(int? id)
        {
            return await _db.Devices.FirstOrDefaultAsync(u => u.DeviceId == id);
        }

        public async Task<Device> Update(Device device)
        {
            _db.Devices.Update(device);
            await _db.SaveChangesAsync();
            return device;
                    
        }

    }
}
