using System.Data.Common;

namespace MemoryBusiness;


public class MemoryGame
{
    public GameState State { get; protected set; }
    public GameBoard gameBoard {get; protected set; }
    
    public MemoryGame(string naam)
    {
        State = new GameState(naam);
    }
    

    public void StartGame(int paren,bool consolerun)
    {
        gameBoard = new GameBoard();
        gameBoard.GenerateBoard(paren);
        State.StartTimer();

        if (consolerun)
        {
            while (!State.IsGameOver)
            {
                PrintConsoleTable();
                AskForUserInPut();

                if (gameBoard.AllCardsAreFaceUp())
                {
                    double score = CalculateScore();
                    State.EndGame();
                    
                    Console.WriteLine($"{State.CurrentPlayer.PlayerName} heeft gewonnen met een score van {score} en had {State.CurrentPlayer.Moves} moves");
                }
            }
        }
    }

    public void PrintConsoleTable()
    {
        Console.WriteLine("Deze onderdelen bevat het spelbord nog");
        for (int i = 0; i < gameBoard.cards.Count; i++)
        {
            var card = gameBoard.cards[i];
            if (card.IsFaceUP)
            {
                Console.WriteLine($"Index: {i}, Identifier: {card.Identifier}");
            }
            else
            {
                Console.WriteLine($"Index: {i}, x");
            }
        }
    }

    public void AskForUserInPut()
    {
        Console.WriteLine($"Player: {State.CurrentPlayer.PlayerName}'s Turn");
        
        int card1Index, card2Index;

        if (int.TryParse(Console.ReadLine(), out card1Index) && int.TryParse(Console.ReadLine(), out card2Index))
        {
            if (card1Index < 0 || card1Index >= gameBoard.cards.Count ||
                card2Index < 0 || card2Index >= gameBoard.cards.Count)
            {
                Console.WriteLine("Invalid card indices. Please enter valid card indices.");
            }
            else if (gameBoard.cards[card1Index].IsFaceUP || gameBoard.cards[card2Index].IsFaceUP)
            {
                Console.WriteLine("Both cards must be face-up. Please choose two face-up cards.");
            }
            else
            {
                CardCheck(gameBoard.cards[card1Index],gameBoard.cards[card2Index]);
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter valid card indices.");
        }
    }

    public int CalculateScore()
    {
        int numCards = gameBoard.Paren;
        State.Time = (DateTime.Now - State.StartTime).TotalSeconds;
        int numAttempts = State.CurrentPlayer.Moves;

        int score = (int)((Math.Pow(numCards, 2) / (State.Time * numAttempts)) * 1000);
        return score;
    }

    public bool CardCheck(Card card1Index, Card card2Index)
    {
        State.CurrentPlayer.MoveDone();
        if (gameBoard.CheckCards(card1Index, card2Index))
        {
            return true;
        }
        
        return false;
    }
}
