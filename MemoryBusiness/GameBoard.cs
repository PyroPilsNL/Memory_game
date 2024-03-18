namespace MemoryBusiness;

public class GameBoard
{
    public List<Card> cards { get; set; }
    public int Paren { get; set; }

    public void GenerateBoard(int NumPairs)
    {

        if (NumPairs <= 4)
        {
            NumPairs = 5;
        }

        Paren = NumPairs;
        cards = new List<Card>();

        for (int i = 0; i < NumPairs; i++)
        {
            Card card1 = new Card(i);
            Card card2 = new Card(i);


            cards.Add(card1);
            cards.Add(card2);
        }


        ShuffleCards();
    }

    public bool CheckCards(Card card1, Card card2)
    {
        FlipCard(card1);
        FlipCard(card2);

        if (card1.Identifier == card2.Identifier)
        {
            return true;
        }

        card1.IsFaceUP = false;
        card2.IsFaceUP = false;
        return false;
    }

    public void FlipCard(Card card)
    {
        card.IsFaceUP = true;
    }

    public bool AllCardsAreFaceUp()
    {
        return cards.All(card => card.IsFaceUP);
    }


    private void ShuffleCards()
    {
        var random = new Random();
        var n = cards.Count;

        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            (cards[k], cards[n]) = (cards[n], cards[k]);
        }
    }

}