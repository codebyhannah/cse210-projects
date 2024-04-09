using System;

abstract public class Game // Abstract class? Interface?
{
    // --- Attributes ---
    protected int _numDecks;
    protected string _deckType;
    protected string _rules;
    protected User _user = new User();
    protected Computer _computer = new Computer();

    // --- Constructors ---
    public Game()
    {
        // Empty
    }

    // --- Methods ---
    public abstract void Start();
    public abstract bool Round(int goesFirst);
}