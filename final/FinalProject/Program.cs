using System;

class Program
{
    static void Main(string[] args)
    {
        // This console clearing thing is required to fix that one issue where C# doesn't always like to clear the entire console. 
        Console.Clear(); Console.WriteLine("\x1b[3J"); Console.Clear();

        GameManager games = new GameManager();
        games.Start();

        /*
        Deck cards = new Deck("test","52 standard",1);
        cards.PlusOne(new Card(2, "other"));
        Deck secondDeck = new Deck("second", "52 standard");
        */
        //cards.GetDeck().AddRange(secondDeck.GetDeck());
        //cards.SetDeck(cards.Shuffle());
        //cards.ShowDeck();
        /*
        List<List<Card>> decks = cards.Split(4);
        foreach(List<Card> deck in decks)
        {
            foreach (Card card in deck)
            {
                Console.WriteLine(card.GetCardForDisplay());
            }
            Console.WriteLine();
        }
        */
        /*
        Deck hand = new Deck("hand");
        hand.SetDeck(cards.Deal(7));
        hand.ShowDeck();
        */

    }
}