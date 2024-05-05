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
        Task<Device> Create(string DeviceBrand, string GenerationCapacity, int FarmId, int EnergyMeterId, int DeviceTypeId);
        Task<Device> Update(int id, string DeviceBrand, string GenerationCapacity, int FarmId, int EnergyMeterId, int DeviceTypeId);
        Task<Device> DeleteDevice(int id);
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

        public async Task<Device> Create(string DeviceBrand, string GenerationCapacity, int FarmId, int EnergyMeterId, int DeviceTypeId)
        {
            Device device = new Device
            {
                DeviceBrand = DeviceBrand,
                GenerationCapacity = GenerationCapacity,
                FarmId = FarmId,
                EnergyMeterId = EnergyMeterId,
                DeviceTypeId = DeviceTypeId
            };
            await _db.Devices.AddAsync(device);
            _db.SaveChanges();
            return device;
        }

        public async Task<Device> DeleteDevice(int id)
        {
            Device device = await GetDevice(id);
            if (device != null)
            {
                device.isDeleted = true;
            }
            return device;
        }

        public async Task<List<Device>> GetAll()
        {
            return await _db.Devices.ToListAsync();
        }

        public async Task<Device> GetDevice(int? id)
        {
            return await _db.Devices.FirstOrDefaultAsync(u => u.DeviceId == id);
        }

        public async Task<Device> Update(int id, string DeviceBrand, string GenerationCapacity, int FarmId, int EnergyMeterId, int DeviceTypeId)
        {
            Device resultDevice = await GetDevice(id);
            if(resultDevice != null)
            {
                resultDevice.DeviceBrand = DeviceBrand;
                resultDevice.GenerationCapacity = GenerationCapacity;
                resultDevice.FarmId = FarmId;
                resultDevice.EnergyMeterId = EnergyMeterId;
                resultDevice.DeviceTypeId = DeviceTypeId;

                await _db.SaveChangesAsync();
            }
            return resultDevice;
                    
        }

    }
}
