namespace MemoryBusiness;

public class GameState
{
    public bool IsGameOver {get; set;}
    public Player CurrentPlayer { get; set; }
    public DateTime StartTime {get; set;}
    public double Time { get; set; }

    public GameState(string naam)
    {
        CurrentPlayer = new Player(naam);
    }

    public void StartTimer()
    {
        StartTime = DateTime.Now;
    }

    public void EndGame()
    {
        IsGameOver = true;
    }

}