using MemoryBusiness;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MemoryDatabase
{
    public class DataBaseManager
    {
        private static string connectionString = "Server=localhost;Database=highscores;User ID=root;";

        public void InsertResult(Player player)
        {
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    using (MySqlCommand command = new MySqlCommand("INSERT INTO highscores (Playername, Score, Moves) VALUES (@PlayerName, @Score, @moves)", cnn))
                    {
                        command.Parameters.AddWithValue("@PlayerName", player.PlayerName);
                        command.Parameters.AddWithValue("@Score", player.Playerscore);
                        command.Parameters.AddWithValue("@moves", player.Moves);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error inserting result: {e.Message}");
                    // You may handle or log the exception here if required.
                    throw; // Rethrowing the exception
                }
            }
        }

        public List<Player> Results()
        {
            List<Player> resultList = new List<Player>();

            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM highscores ORDER BY Score DESC LIMIT 10", cnn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Player player = new Player(reader.GetString("Playername"), reader.GetInt32("Score"), reader.GetInt32("Moves"));
                                resultList.Add(player);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error retrieving results: {e.Message}");
                    // You may handle or log the exception here if required.
                    throw; // Rethrowing the exception
                }
            }

            return resultList;
        }
    }
}
