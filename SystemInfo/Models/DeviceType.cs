namespace SystemInfo.Models
{
    public class DeviceType
    {
        public int DeviceTypeId { get; set; }
        public required string TypeDevice { get; set; }
        public bool isDeleted { get; set; } = false;

        public List<Device>? Devices { get; set; }
    }
}
