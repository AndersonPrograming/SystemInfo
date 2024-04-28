namespace SystemInfo.Models
{
    public class EnergyLog
    {
        public int EnergyLogId { get; set; }
        public DateTime ReadingDate { get; set; }
        public required string GeneratedEnergyKWH { get; set; }
        public required string ConsumedEnergyKWH { get; set; }
        public EnergyMeter? EnergyMeter { get; set; }

    }
}
