namespace MemoryBusiness;

public class Card
{
    public bool IsFaceUP {get; set;}

    public int Identifier { get; set; }


    public Card(int identifier)
    {
        Identifier = identifier;
        IsFaceUP = false;
    }

    public Card()
    {

        IsFaceUP = false;
    }


}