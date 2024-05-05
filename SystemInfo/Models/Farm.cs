namespace SystemInfo.Models
{
    public class Farm
    {
        public int FarmId { get; set; }
        public required string FarmName { get; set; }
        public required string Location { get; set; }
        public required string FarmArea { get; set; }
        public required string Image { get; set; }
        public required int FarmerId { get; set; }
        public required int FarmTypeId { get; set; }
        public bool isDeleted { get; set; } = false;

        public Farmer? Farmer { get; set; }
        public FarmType? FarmType { get; set; }
        public List<Device>? Devices { get; set; }
    }
}
