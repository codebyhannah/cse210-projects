using System;

public class Deck
{
    // --- Attributes ---
    private string _name; // This is what the _deck attribute in the Card class will be set to. 
    private List<Card> _deck = new List<Card>();
    private int _numJokers; // Might be set anywhere from 0 to however many the game with the most jokers needs.
    private string _type; // Standard 52 vs. other variations such as the pinochle deck. Can also be set to "empty" in the constructor to generate an empty deck that will be added to as the game is played.
    private Aesthetic _aesthetic = new Aesthetic();

    // --- Constructors ---
    public Deck(string name, string type = "empty", int numJokers = 0) 
    {
        // Defaults to set up an empty deck that will be added to as the game is played. The first option to be added here is the standard 52 deck as that deck is most commonly used in card games, but more options can be added in the future.
        _numJokers = numJokers;
        _type = type.ToLower();
        _name = name;
        int serial = 1;
        if (_type == "empty")
        {
            _deck = new List<Card>();
        }
        else if (_type == "52 standard")
        {
            for (int j = 1; j <= 4; j++)
            {
                string suit;
                Card card;
                if (j == 1)
                {
                    suit = "spades";
                }
                else if (j == 2)
                {
                    suit = "hearts";
                }
                else if (j == 3)
                {
                    suit = "clubs";
                }
                else
                {
                    suit = "diamonds";
                }
                for (int i = 1; i <= 13; i++)
                {
                    card = new Card(i, suit, serial, _name);
                    _deck.Add(card);
                    serial++;
                }
            }
        }
        
        for (int i = 1; i <= _numJokers; i++)
        {
            Card card = new Card(1, "other", serial, _name);
            _deck.Add(card);
            serial++;
        }
    }

    // Getters and Setters
    public List<Card> GetDeck()
    {
        return _deck;
    }
    public void SetDeck(List<Card> deck)
    {
        _deck = deck;
    }
    public string GetName()
    {
        return _name;
    }

    // --- Methods ---
    public string GetDeckForDisplay()
    {
        string deckString = "";
        if (_deck.Count > 0)
        {
            foreach (Card card in _deck)
            {
                deckString += $"| {card.GetCardForDisplay()} ";
            }
            deckString += "|";
        }
        return deckString;
    }
    public string GetHiddenDeckForDisplay()
    {
        string deckString = "";
        Card back = new Card(2,"other");
        if (_deck.Count > 0)
        {
            foreach (Card card in _deck)
            {
                deckString += $"| {back.GetCardSymbolOnly()} ";
            }
            deckString += "|";
        }
        return deckString;
    }
    public List<Card> Shuffle()
    {
        List<Card> shuffled = new List<Card>();
        for(int i = 1; i <= _deck.Count; i++)
        {
            Card card;
            do
            {
                Random randomGenerator = new Random();
                int cardIndex = randomGenerator.Next(0, _deck.Count);
                card = _deck[cardIndex];
            } while (shuffled.Contains(card));
            shuffled.Add(card);
        }
        return shuffled;
    }
    public List<List<Card>> SplitByDeck()
    {
        List<List<Card>> decks = new List<List<Card>>();
        List<string> deckNames = new List<string>();
        foreach(Card card in _deck)
        {
            string deckName = card.GetDeck();
            if (!deckNames.Contains(deckName))
            {
                deckNames.Add(deckName);
                decks.Add(new List<Card>());
            }
            int index = deckNames.IndexOf(deckName);
            decks[index].Add(card);
        }
        return decks;
    }
    public List<List<Card>> Split(int numDecks)
    {
        List<Card> modifiedDeck = _deck;
        List<List<Card>> decks = new List<List<Card>>();
        int mod = _deck.Count % numDecks;
        int numCardsPerDeck = (_deck.Count - mod) / numDecks;
        for(int i = 1; i <= numDecks; i++)
        {
            decks.Add(new List<Card>());
        }
        int deckIndex = 0;
        for(int k = 0; k < mod; k++)
        {
            if (deckIndex >= decks.Count)
            {
                deckIndex = 0;
            }
            decks[deckIndex].Add(modifiedDeck[0]);
            modifiedDeck.RemoveAt(0);
            deckIndex++;
        }
        deckIndex = 0;
        int j = 1;
        foreach(Card card in modifiedDeck)
        {
            if(j <= numCardsPerDeck)
            {
                decks[deckIndex].Add(card);
                j++;
            }
            else if (j > numCardsPerDeck)
            {
                j = 1;
                deckIndex++;
                decks[deckIndex].Add(card);
                j++;
            }
        }
        return decks;
    }
    public List<Card> Deal(int numToDeal)
    {
        // The resulting list of Cards becomes the specified player's hand. Could use an if/else and iterate from 1 to 2 and back to deal cards one at a time back and forth between players with a timer to pause minutely between Cards, for effect?
        List<Card> dealt = new List<Card>();
        for (int i = 0; i < numToDeal; i++)
        {
            dealt.Add(_deck[0]);
            _deck.RemoveAt(0);
        }
        return dealt;
    }
    public Card Draw(int index = 0)
    {
        // The Card is removed from the _deck and is then returned to be added to the player's hand or otherwise used/distributed.
        Card card;
        if (_deck.Count == 0)
        {
            _aesthetic.WriteCenterText("Deck empty");
            card = new Card(2, "other");
        }
        else
        {
            card = _deck[index];
            _deck.RemoveAt(index);
        }
        return card;
    }
    public void PlusOne(Card card)
    {
        // Used to add a card that has been drawn.
        _deck.Add(card);
    }
    public void PlusMany(List<Card> cards)
    {
        // Used to add cards that have been dealt.
        _deck.AddRange(cards);
    }

}