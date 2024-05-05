namespace SystemInfo.Models
{
    public class EnergyMeter
    {
        public int EnergyMeterId { get; set; }
        public required string EnergyMeterBrand { get; set; }
        public required  DateTime InstalationDate { get; set; }
        public bool isDeleted { get; set; } = false;

        public List<EnergyLog>? EnergyLog { get; set; }
        public List<Device>? Devices { get; set; }

    }
}
