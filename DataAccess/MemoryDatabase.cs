using System;
using System.Data.SqlClient;
using MemoryBusiness;
using MySqlConnector;

namespace MemoryDatabase;


public class DataBaseManager
{

    private static string connectionString = "Server=localhost;Database=highscores;User ID=root;";
    private MySqlConnection cnn = new MySqlConnection(connectionString);

    public void InsertResult(Player player)
    {
        try
        {
            cnn.Open();

            using (MySqlCommand command = new MySqlCommand("INSERT INTO highscores (Playername,Score,Moves) VALUES (@PlayerName, @Score, @moves)", cnn))
            {
                command.Parameters.AddWithValue("@PlayerName", player.PlayerName);
                command.Parameters.AddWithValue("@Score", player.Playerscore);
                command.Parameters.AddWithValue("@moves", player.Moves);
                command.Prepare();

                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            cnn.Close();
        }
    }

    public List<Player> Results()
    {
        try
        {
            cnn.Open();

            List<Player> lijst = new List<Player>();
            using (MySqlCommand command = new MySqlCommand("SELECT * FROM highscores ORDER BY Score DESC LIMIT 10", cnn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        {
                            Player player = new Player(reader.GetString("Playername"), reader.GetInt32("Score"),reader.GetInt32("Moves"));
                           lijst.Add(player);
                        };

                    }
                }
            }

            return lijst;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            cnn.Close();
        }
    }
}
