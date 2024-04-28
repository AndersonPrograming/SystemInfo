namespace SystemInfo.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public required string DeviceBrand { get; set; }
        public required string GenerationCapacity { get; set;}
        public Farm? Farm { get; set; }
        public EnergyMeter? EnergyMeter { get; set; }
        public DeviceType? DeviceType { get; set; }
    }
}
