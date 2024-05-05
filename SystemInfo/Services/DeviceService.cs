using SystemInfo.Models;
using SystemInfo.Repositories;

namespace SystemInfo.Services
{
    // create interface
    public interface IDeviceService
    {
        Task<List<Device>> GetAll();
        Task<Device> GetDevice(int? id);
        Task<Device> Create(string DeviceBrand, string GenerationCapacity, int FarmId, int EnergyMeterId, int DeviceTypeId);
        Task<Device> Update(int id, string DeviceBrand, string GenerationCapacity, int FarmId, int EnergyMeterId, int DeviceTypeId);
        Task<Device> DeleteDevice(int id);
    }
    public class DeviceService: IDeviceService
    {
        public readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<Device> Create(string DeviceBrand, string GenerationCapacity, int FarmId, int EnergyMeterId, int DeviceTypeId)
        {
            return await _deviceRepository.Create(DeviceBrand, GenerationCapacity, FarmId, EnergyMeterId, DeviceTypeId);
        }

        public async Task<Device> DeleteDevice(int id)
        {
            return await _deviceRepository.DeleteDevice(id);
        }

        public async Task<List<Device>> GetAll()
        {
            return await _deviceRepository.GetAll();
        }

        public async Task<Device> GetDevice(int? id)
        {
            return await _deviceRepository.GetDevice(id);
        }

        public async Task<Device> Update(int id, string DeviceBrand, string GenerationCapacity, int FarmId, int EnergyMeterId, int DeviceTypeId)
        {
            
            return await _deviceRepository.Update(id, DeviceBrand, GenerationCapacity, FarmId, EnergyMeterId, DeviceTypeId);
            throw new NotImplementedException();
        }
    }
}
