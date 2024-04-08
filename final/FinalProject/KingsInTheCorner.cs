using System;

public class KingsInTheCorner : Game
{
    // --- Attributes ---
    private Deck _drawPile;
    private Deck _north = new Deck("n");
    private Deck _east = new Deck("e");
    private Deck _south = new Deck("s");
    private Deck _west = new Deck("w");
    private Deck _northEast = new Deck("ne");
    private Deck _southEast = new Deck("se");
    private Deck _southWest = new Deck("sw");
    private Deck _northWest = new Deck("nw");
    private List<Deck> _sidesAndCorners = new List<Deck>();
    private Aesthetic _aesthetic = new Aesthetic();

    // --- Constructors ---
    public KingsInTheCorner() : base()
    {
        _rules = "";
        _deckType = "52 standard";
        _numDecks = 1;
        _drawPile = new Deck("draw", _deckType);
        _sidesAndCorners = new List<Deck>{_north,_northEast,_east,_southEast,_south,_southWest,_west,_northWest};
    }

    // --- Methods ---
    public override void Start()
    {
        Console.Clear(); Console.WriteLine("\x1b[3J"); Console.Clear();
        Console.WriteLine("~*~ Kings in the Corner ~*~");
        Console.WriteLine();

        _drawPile.SetDeck(_drawPile.Shuffle());

        _computer.SetHand(_drawPile.Deal(7));
        _user.SetHand(_drawPile.Deal(7));

        _north.PlusOne(_drawPile.Draw());
        _east.PlusOne(_drawPile.Draw());
        _south.PlusOne(_drawPile.Draw());
        _west.PlusOne(_drawPile.Draw());

        bool over = false;
        do
        {
            Round();
            over = true;
        } while (!over);
    }
    public override void Round()
    {
        _aesthetic.WriteCenterText("Computer Hand");
        _aesthetic.CenteredTextLine("-", _computer.GetHiddenHandForDisplay().Length - _computer.GetHand().GetDeck().Count() +2);
        _aesthetic.WriteCenterText(_computer.GetHiddenHandForDisplay());
        _aesthetic.CenteredTextLine("-", _computer.GetHiddenHandForDisplay().Length - _computer.GetHand().GetDeck().Count() +2);
        
        DisplayStacks();

        _aesthetic.WriteCenterText("User Hand");
        _aesthetic.CenteredTextLine("-", _user.GetHandForDisplay().Length - _user.GetHand().GetDeck().Count() +2);
        _aesthetic.WriteCenterText(_user.GetHandForDisplay());
        _aesthetic.CenteredTextLine("-", _user.GetHandForDisplay().Length - _user.GetHand().GetDeck().Count() +2);
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
    private void DisplayStacks()
    {
        // 8 columns
        _aesthetic.WriteCenterText("Stacks");
        _aesthetic.CenteredTextLine("-",123);
        foreach (Deck stack in _sidesAndCorners)
        {
            string rowString = "";
            rowString += $"{stack.GetName().ToUpper()} ";
            if (stack.GetName().Length == 1)
            {
                rowString += " ";
            }

            int excess = 0;
            if (stack.GetDeck().Count > 0)
            {
                foreach (Card card in stack.GetDeck())
                {
                    rowString += $"| {card.GetCardForDisplay()} ";
                    if (card.GetNumber() != 10)
                    {
                        rowString += " ";
                    }
                    excess += 1;
                }
            }
            else
            {
                rowString += "|        "; // Empty
            }
            rowString += "|";
            int len = rowString.Length - excess;
            _aesthetic.WriteCenterText(rowString);
            _aesthetic.CenteredTextLine("-",len+2);
        }
        _aesthetic.CenteredTextLine("-",123);
    }
}