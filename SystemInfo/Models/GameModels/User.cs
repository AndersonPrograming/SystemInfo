namespace SystemInfo.Models.GameModels
{
    public class User
    {
        public int UserId { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Image { get; set; }
        public bool isDeleted { get; set; } = false;

        public List<Game>? Games { get; set; }
        public List<Badge>? Badges { get; set; }
    }
}
