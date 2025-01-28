using MySql.Data.MySqlClient;
using System;

namespace Jeux.Data
{
    public class DatabaseConnection
    {
        private static readonly string ConnectionString = "Server=127.0.0.1;Database=game_manager;User Id=root;Password=;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public void TestConnection()
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}