using System;

public class KingsInTheCorner : Game
{
    // --- Attributes ---
    private Deck _north = new Deck("north");
    private Deck _east = new Deck("east");
    private Deck _south = new Deck("south");
    private Deck _west = new Deck("west");
    private Deck _northEast = new Deck("northeast");
    private Deck _southEast = new Deck("southeast");
    private Deck _southWest = new Deck("southwest");
    private Deck _northWest = new Deck("northwest");
    private List<Deck> _sidesAndCorners = new List<Deck>();

    // --- Constructors ---
    public KingsInTheCorner() : base()
    {
        _rules = "";
        _deckType = "52 standard";
        _numDecks = 1;
    }

    // --- Methods ---
    public override void Start()
    {
        Console.Clear(); Console.WriteLine("\x1b[3J"); Console.Clear();
        Console.WriteLine("~*~ Kings in the Corner ~*~");
        Console.WriteLine();
    }
    public override void Round()
    {
        
    }
    private int Turn(Player player)
    {
        // Calls the Player.Draw() method, Game.Play() method, and any other methods necessary for a player to take a turn in that game. Returns points earned, or if no points involved, checks if the game is over and who won if so.
        int points = 0;
        return points;
    }
    private void Play(Player player)
    {
        // if/else tree that depends on player subclass to decide what it does calls User.Play() method which displays a prompt (provided here) and gets a response from the user which is used to determine what they do. If player cannot play, calls the Player.Draw() method.
    }
    private void moveStack()
    {
        // Automatically places player's highest card unless they have multiple of the highest value, in which case the player chooses which to place?
    }
}