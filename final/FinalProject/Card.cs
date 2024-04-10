using System;

public class Card
{
    // --- Attributes ---
    private int _number;
    private string _suit;
    private string _card;
    private string _deck; // For games with multiple decks involved, so that it can be kept track of if needed.
    private int _serial; // Most useful for decks containing multiple of the same card, so it doesn't conflate them in methods such as Deck.Shuffle().
    private List<List<string>> _cardSymbols = new List<List<string>>{new List<string>{"🂡","🂢","🂣","🂤","🂥","🂦","🂧","🂨","🂩","🂪","🂫","🂭","🂮"}, new List<string>{"🂱","🂲","🂳","🂴","🂵","🂶","🂷","🂸","🂹","🂺","🂻","🂽","🂾"}, new List<string>{"🃑","🃒","🃓","🃔","🃕","🃖","🃗","🃘","🃙","🃚","🃛","🃝","🃞"}, new List<string>{"🃁","🃂","🃃","🃄","🃅","🃆","🃇","🃈","🃉","🃊","🃋","🃍","🃎"},new List<string>{"🃟","🂠"}};
    private List<string> _suitSymbols = new List<string>{"♠","♥","♣","♦"};

    // --- Constructors ---
    public Card(int number, string suit,  int serial = 0, string deck = "deck")
    {
        // Deck and serial set to defaults for cases in which they are not in use.
        _number = number;
        _deck = deck;
        _serial = serial;
        if (suit.ToLower() == "spades")
        {
            _suit = _suitSymbols[0];
            _card = _cardSymbols[0][_number-1];
        }
        else if (suit.ToLower() == "hearts")
        {
            _suit = _suitSymbols[1];
            _card = _cardSymbols[1][_number-1];
        }
        else if (suit.ToLower() == "clubs")
        {
            _suit = _suitSymbols[2];
            _card = _cardSymbols[2][_number-1];
        }
        else if (suit.ToLower() == "diamonds")
        {
            _suit = _suitSymbols[3];
            _card = _cardSymbols[3][_number-1];
        }
        else if (suit == "other")
        {
            _suit = suit;
            _card = _cardSymbols[4][_number-1];
        }
    }

    // --- Getters and Setters ---
    public int GetNumber()
    {
        return _number;
    }
    public string GetSuit()
    {
        return _suit;
    }
    public string GetDeck()
    {
        return _deck;
    }
    public void SetDeck(string deck)
    {
        _deck = deck;
    }

    // --- Methods ---
    public string GetCardSymbolOnly()
    {
        return $"{_card}";
    }
    public string GetCardForDisplay()
    {
        if (_suit == "other" && _number == 1)
        {
            return $"{_card} Joker";
        }
        else if (_suit == "other" && _number == 2)
        {
            return $"{_card} Back";
        }
        else if (_number == 1)
        {
            return $"{_card} A {_suit}";
        }
        else if (_number == 11)
        {
            return $"{_card} J {_suit}";
        }
        else if (_number == 12)
        {
            return $"{_card} Q {_suit}";
        }
        else if (_number == 13)
        {
            return $"{_card} K {_suit}";
        }
        else
        {
            return $"{_card} {_number} {_suit}";
        }
    }
}