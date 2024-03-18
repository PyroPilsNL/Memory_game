using MemoryBusiness;

namespace MemoryTesten;

public class GameTesten
{
    [TestCase(4,5)]
    [TestCase(5,5)]
    [TestCase(6,6)]
    [TestCase(-1,5)]
    public void StartGame_ValidPairs_CorrectGameStart(int paren,int result) { //testen dat je in de if komt van de game, dus correcte werking
        //Arrange
        string name = "test";

        MemoryGame game = new MemoryGame("Test");

        //Act
        game.StartGame(paren,false);

        //Assert
        Assert.AreEqual(result, game.gameBoard.Paren);
    }


    [TestCase(5,10,20)]
    [TestCase(10,25,5)]
    [TestCase(12,50,25)]
    [TestCase(-1,1000000,100000000)]
    [TestCase(100000,1,1)]
    [TestCase(7,5,15)]
    public void Calculate_CalculateCorrect_CalculatePoints(int paren,int time,int moves) { //testen van de berekening voor punten
        //Arrange
        MemoryGame game = new MemoryGame("Test");
        game.StartGame(paren,false);
        game.State.StartTime = DateTime.Now.AddSeconds(-time); // Simuleer seconden verstreken
        game.State.CurrentPlayer.Moves = moves; // Simuleer zetten

        int numCards = paren;
        int timeInSeconds = time;
        int numAttempts = moves;
        // Act
        int calculatedScore = game.CalculateScore();

        // Assert
        int expectedScore = (int)((Math.Pow(numCards, 2) / (timeInSeconds * numAttempts)) * 1000);
        Assert.That(calculatedScore, Is.EqualTo(expectedScore).Within(0.8).Percent);

    }
}