using SystemInfo.Models;
using SystemInfo.Repositories;

namespace SystemInfo.Services
{
    // create interface
    public interface IDeviceTypeService
    {
        Task<List<DeviceType>> GetAll();
        Task<DeviceType> GetDeviceType(int? id);
        Task<DeviceType> Create(DeviceType deviceType);
        Task<DeviceType> Update(DeviceType deviceType);
        Task<DeviceType> DeleteDeviceType(int? id);
    }
    public class DeviceTypeService: IDeviceTypeService
    {
        public readonly DeviceTypeRepository _deviceTypeRepository;

        public DeviceTypeService(DeviceTypeRepository deviceTypeRepository)
        {
            _deviceTypeRepository = deviceTypeRepository;
        }

        public async Task<DeviceType> Create(DeviceType deviceType)
        {
            DeviceType newDeviceType = new DeviceType
            {
                TypeDevice = deviceType.TypeDevice,
            };

            return await _deviceTypeRepository.Create(newDeviceType);
        }

        public async Task<DeviceType> DeleteDeviceType(int? id)
        {
            DeviceType newDeviceType = await GetDeviceType(id);

            return await _deviceTypeRepository.DeleteDeviceType(newDeviceType);
        }

        public Task<List<DeviceType>> GetAll()
        {
            return _deviceTypeRepository.GetAll();
        }

        public async Task<DeviceType> GetDeviceType(int? id)
        {
            return await _deviceTypeRepository.GetDeviceType(id);
        }

        public async Task<DeviceType> Update(DeviceType deviceType)
        {
            DeviceType newDeviceType = await GetDeviceType(deviceType.DeviceTypeId);

            if (newDeviceType != null)
            {
                if (deviceType.TypeDevice != null)
                {
                    newDeviceType.TypeDevice = deviceType.TypeDevice;
                }

                return await _deviceTypeRepository.Update(newDeviceType);
            }
            throw new NotImplementedException();
   
        }
    }
}
