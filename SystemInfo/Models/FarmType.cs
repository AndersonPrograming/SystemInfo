namespace SystemInfo.Models
{
    public class FarmType
    {
        public int FarmTypeId { get; set; }
        public required string TypeFarm { get; set;}
        public bool isDeleted { get; set; } = false;

        public List<Farm>? Farms { get; set; }
    }
}
