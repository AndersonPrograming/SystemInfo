namespace SystemInfo.Models.GameModels
{
    public class Game
    {
        public int GameId { get; set; }
        public required Score Score { get; set; }

        public required List<User> Users { get; set; }

    }
}
