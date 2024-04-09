using System;

public class Player
{
    // --- Attributes ---
    private Deck _hand = new Deck("hand");
    private int _points; // Can be used to keep track of number of games won if points are not involved in the game.

    // --- Constructors ---
    public Player()
    {
        string name = this.GetType().Name.ToLower();
        _hand = new Deck(name);
    }

    // --- Getters and Setters ---
    public Deck GetHand()
    {
        return _hand;
    }
    public void SetHand(List<Card> hand)
    {
        _hand.SetDeck(hand);
    }

    // --- Methods ---
    public void Draw(Deck deck)
    {
        // Calls the Deck.Draw() method on deck and adds the returned card to the player's hand.
        _hand.PlusOne(deck.Draw());
    }
    public void UpdatePoints(int points)
    {
        _points += points;
    }
    public string GetHandForDisplay()
    {
        return GetHand().GetDeckForDisplay();
    }
    public string GetHiddenHandForDisplay()
    {
        return GetHand().GetHiddenDeckForDisplay();
    }

    public virtual string Play(string prompt)
    {
        return "";
    }

}