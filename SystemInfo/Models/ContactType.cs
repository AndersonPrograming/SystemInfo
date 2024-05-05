namespace SystemInfo.Models
{
    public class ContactType
    {
        public int? ContactTypeId { get; set; }
        public required string TypeContact { get; set; }
        public bool isDeleted { get; set; } = false;

        public List<Farmer>? Farmers { get; set;}

    }
}
