namespace SystemInfo.Models
{
    public class Farmer
    {
        public int FarmerId { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Contact { get; set; }
        public required string Address { get; set; }
        public ContactType? ContactType { get; set; }
    }

}
