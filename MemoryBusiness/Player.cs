namespace MemoryBusiness;

public class Player
{
    public string PlayerName {get; set;}
    public int Playerscore {get; set;}
    public double GameTime { get; set; }
    public int Moves { get; set; }

    public Player(string naam, int score, double gametime)
    {
        PlayerName = naam;
        Playerscore = score;
        GameTime = gametime;
        Moves = 0;
    }
    public Player(string naam)
    {
        PlayerName = naam;
        Moves = 0;
    }

    public Player(string naam,int playerscore,int moves)
    {
        PlayerName = naam;
        Playerscore = playerscore;
        Moves = moves;
    }

    public void MoveDone()
    {
        Moves++;
    }
}