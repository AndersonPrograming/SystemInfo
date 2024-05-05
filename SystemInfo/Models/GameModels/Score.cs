namespace SystemInfo.Models.GameModels
{
    public class Score
    {
        public int ScoreId { get; set; }
        public required int GameId { get; set; }
        public required string ScoreValue { get; set; }
        public bool isDeleted { get; set; } = false;

        public Game? Game { get; set; }

    }
}
