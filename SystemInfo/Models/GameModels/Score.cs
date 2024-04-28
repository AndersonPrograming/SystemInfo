namespace SystemInfo.Models.GameModels
{
    public class Score
    {
        public int ScoreId { get; set; }
        public required string Time { get; set; }

        public required List<Game> Games { get; set; }

    }
}
