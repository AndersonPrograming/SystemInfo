namespace SystemInfo.Models
{
    public class Farm
    {
        public int FarmId { get; set; }
        public required string FarmName { get; set; }
        public required string Location { get; set; }
        public required string FarmArea { get; set; }
        public required string Image { get; set; }

        public Farmer? Farmer { get; set; }
        public FarmType? FarmType { get; set; }
        public List<Device>? Devices { get; set; }
    }
}
