using SystemInfo.Models;
using SystemInfo.Repositories;

namespace SystemInfo.Services
{
    // create interface
    public interface IDeviceTypeService
    {
        Task<List<DeviceType>> GetAll();
        Task<DeviceType> GetDeviceType(int? id);
        Task<DeviceType> Create(string deviceType);
        Task<DeviceType> Update(int id, string deviceType);
        Task<DeviceType> DeleteDeviceType(int id);
    }
    public class DeviceTypeService: IDeviceTypeService
    {
        public readonly IDeviceTypeRepository _deviceTypeRepository;

        public DeviceTypeService(IDeviceTypeRepository deviceTypeRepository)
        {
            _deviceTypeRepository = deviceTypeRepository;
        }

        public async Task<DeviceType> Create(string deviceType)
        {
            return await _deviceTypeRepository.Create(deviceType);
        }

        public async Task<DeviceType> DeleteDeviceType(int id)
        {
            return await _deviceTypeRepository.DeleteDeviceType(id);
        }

        public Task<List<DeviceType>> GetAll()
        {
            return _deviceTypeRepository.GetAll();
        }

        public async Task<DeviceType> GetDeviceType(int? id)
        {
            return await _deviceTypeRepository.GetDeviceType(id);
        }

        public async Task<DeviceType> Update(int id, string deviceType)
        {
            return await _deviceTypeRepository.Update(id, deviceType);
            throw new NotImplementedException();
        }
    }
}
