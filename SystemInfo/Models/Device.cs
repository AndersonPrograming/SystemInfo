namespace SystemInfo.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public required string DeviceBrand { get; set; }
        public required string GenerationCapacity { get; set;}
        public required int FarmId { get; set; }
        public required int EnergyMeterId { get; set; }
        public required int DeviceTypeId { get; set; }
        public bool isDeleted { get; set; } = false;

        public Farm? Farm { get; set; }
        public EnergyMeter? EnergyMeter { get; set; }
        public DeviceType? DeviceType { get; set; }
    }
}
