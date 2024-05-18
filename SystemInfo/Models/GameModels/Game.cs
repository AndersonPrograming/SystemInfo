namespace SystemInfo.Models.GameModels
{
    public class Game
    {
        public int GameId { get; set; }
        public required int UserId { get; set; }
        public required  DateTime GameDate { get; set; }
        public required string EnergyType { get; set; }
        public required string Score { get; set; }
        public bool isDeleted { get; set; } = false;

        public User? User { get; set; }
    }
}
