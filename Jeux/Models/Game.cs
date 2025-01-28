namespace Jeux.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PlayerCount { get; set; }
        public int CardCount { get; set; }
        public string GameType { get; set; }
        public string Publisher { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}