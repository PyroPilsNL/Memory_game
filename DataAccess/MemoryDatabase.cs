using System;
using System.Data.SqlClient;
using MemoryBusiness;
using MySqlConnector;

namespace MemoryDatabase;


public class DataBaseManager
{

    private static string connectionString = "Server=127.0.0.1;Port=3306;Database=test;Uid=root;"; //Home pc
    // private static string connectionString = "Server=127.0.0.1;Port=3306;Database=test;Uid=root;";
    private MySqlConnection cnn = new MySqlConnection(connectionString);

    public void CreateDBIfNotExcisted()
    {
        try
        {
            cnn.Open();

            // Create the table if it doesn't exist
            using (MySqlCommand createCommand = new MySqlCommand("CREATE TABLE IF NOT EXISTS `highscores` (`Playername` varchar(45) NOT NULL, `Score` int(11) DEFAULT NULL, `Moves` int(11) DEFAULT NULL, PRIMARY KEY (`Playername`)) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;", cnn))
            {
                createCommand.ExecuteNonQuery();
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
