using MemoryBusiness;

namespace MemoryTesten;

public class GameBoardTesten
{
    [TestCase(4,10)]
    [TestCase(5,10)]
    [TestCase(6,12)]
    [TestCase(-1,10)]
    public void GenerateBoard_CreatesBoardWithCorrectNumberOfCards_CorrectAmountOfCards(int paren,int result) { //test voor het controleren of er genoeg kaarten worden gegenereerd
        //Arrange
        GameBoard gameBoard = new GameBoard();
        int numberOfPairs = paren;

        //Act
        gameBoard.GenerateBoard(numberOfPairs);

        //Assert
        Assert.AreEqual(result, gameBoard.cards.Count); // Verwacht aantal kaarten op het bord
    }

    [TestCase(5)]
    [TestCase(4)]
    [TestCase(6)]
        public void GenerateBoard_ShufflesCards(int pairs) { //test voor het randomize van de kaarten
            //Arrange
            GameBoard gameBoard = new GameBoard();
            int numberOfPairs = pairs;

            //Act
            gameBoard.GenerateBoard(numberOfPairs);
            List<Card> originalOrder = gameBoard.cards.ToList();
            gameBoard.GenerateBoard(numberOfPairs);

            //Assert
            CollectionAssert.AreNotEqual(originalOrder, gameBoard.cards);
        }


        [TestCase(false,false,0,false,1)]
        [TestCase(true,true,0,true,0)]
        public void CheckCards_NonAndMatchingCards_ReturnsFalseOrTrue(bool expectedresult,bool expectedCard1,int card1Identifier,bool expectedCard2,int card2Identifier) { //test van een randomize
            //Arrange
            GameBoard gameBoard = new GameBoard();
            Card card1 = new Card();
            Card card2 = new Card();
            card1.Identifier = card1Identifier;
            card2.Identifier = card2Identifier;

            bool result = gameBoard.CheckCards(card1, card2);

            //Assert
            Assert.That(card1.IsFaceUP, Is.EqualTo(expectedCard1));
            Assert.That(card2.IsFaceUP, Is.EqualTo(expectedCard2));
            Assert.That(result,Is.EqualTo(expectedresult));
        }

        [Test()]
        public void FlipCard_FlipCard_CardGetsFlipped() {
            //Arrange
            GameBoard gameBoard = new GameBoard();
            Card card1 = new Card(1);

            //Act
            gameBoard.FlipCard(card1);

            //Assert
            Assert.AreEqual(true, card1.IsFaceUP);

        }
}