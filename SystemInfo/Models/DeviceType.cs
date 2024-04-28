namespace SystemInfo.Models
{
    public class DeviceType
    {
        public int DeviceTypeId { get; set; }
        public required string TypeDevice { get; set; }

        public List<Device>? Devices { get; set; }
    }
}
