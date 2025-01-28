using Jeux.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Jeux.Data
{
    public class GameRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public GameRepository()
        {
            _dbConnection = new DatabaseConnection();
        }

        public List<Game> GetAllGames()
        {
            var games = new List<Game>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM games", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        games.Add(new Game
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Description = reader.GetString("description"),
                            PlayerCount = reader.GetInt32("player_count"),
                            CardCount = reader.GetInt32("card_count"),
                            GameType = reader.GetString("game_type"),
                            Publisher = reader.GetString("publisher"),
                            CreatedAt = reader.GetDateTime("created_at")
                        });
                    }
                }
            }

            return games;
        }

        // Ajoutez ici les méthodes pour Add, Update, Delete, etc.
    }
}