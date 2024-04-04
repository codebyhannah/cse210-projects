using System;

abstract public class Game // Abstract class? Interface?
{
    // --- Attributes ---
    protected int _numDecks;
    protected string _deckType;
    protected string _rules;

    // --- Constructors ---
    public Game()
    {
        // Empty
    }

    // --- Methods ---
    public abstract void Start();
    public abstract void Round();
}