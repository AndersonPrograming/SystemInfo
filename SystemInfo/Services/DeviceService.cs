using SystemInfo.Models;
using SystemInfo.Repositories;

namespace SystemInfo.Services
{
    // create interface
    public interface IDeviceService
    {
        Task<List<Device>> GetAll();
        Task<Device> GetDevice(int? id);
        Task<Device> Create(Device device);
        Task<Device> Update(Device device);
        Task<Device> DeleteDevice(int? id);
    }
    public class DeviceService: IDeviceService
    {
        public readonly DeviceRepository _deviceRepository;

        public DeviceService(DeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<Device> Create(Device device)
        {
            Device newDevice = new Device
            {
                DeviceBrand = device.DeviceBrand,
                DeviceType = device.DeviceType,
                GenerationCapacity = device.GenerationCapacity,
                Farm = device.Farm,
                EnergyMeter = device.EnergyMeter,

            };
            return await _deviceRepository.Create(newDevice);
        }

        public async Task<Device> DeleteDevice(int? id)
        {
            Device newDevice = await GetDevice(id);

            return await _deviceRepository.DeleteDevice(newDevice);
        }

        public async Task<List<Device>> GetAll()
        {
            return await _deviceRepository.GetAll();
        }

        public async Task<Device> GetDevice(int? id)
        {
            return await _deviceRepository.GetDevice(id);
        }

        public async Task<Device> Update(Device device)
        {
            Device newDevice = await GetDevice(device.DeviceId);
            if (newDevice != null)
            {
                if (device.DeviceBrand != null)
                {
                    newDevice.DeviceBrand = device.DeviceBrand;
                }
                if (device.DeviceType != null)
                {
                    newDevice.DeviceType = device.DeviceType;
                }
                if (device.GenerationCapacity != null)
                {
                    newDevice.GenerationCapacity = device.GenerationCapacity;
                }
                if (device.Farm != null)
                {
                    newDevice.Farm = device.Farm;
                }
                if (device.EnergyMeter != null)
                {
                    newDevice.EnergyMeter = device.EnergyMeter;
                }

                return await _deviceRepository.Update(newDevice);
            }
            throw new NotImplementedException();

           
        }
    }
}
