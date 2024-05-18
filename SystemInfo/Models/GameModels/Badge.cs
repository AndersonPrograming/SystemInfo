namespace SystemInfo.Models.GameModels
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public required int UserId { get; set; }
        public string Image { get; set; }
        public required string NameBadge { get; set; }
        public required string Description { get; set; }
        public bool Completed { get; set; } = false;
        public int Experience { get; set; }

        public User? User { get; set; }
    }
}
