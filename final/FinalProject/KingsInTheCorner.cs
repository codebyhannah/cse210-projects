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
        _drawPile.SetDeck(_drawPile.Shuffle());

        _computer.SetHand(_drawPile.Deal(7));
        _user.SetHand(_drawPile.Deal(7));

        _north.PlusOne(_drawPile.Draw());
        _east.PlusOne(_drawPile.Draw());
        _south.PlusOne(_drawPile.Draw());
        _west.PlusOne(_drawPile.Draw());

        Random randomGenerator = new Random();
        int goesFirst = randomGenerator.Next(1, 2);

        bool over = false;
        do
        {
            Round(goesFirst);
            over = true;
        } while (!over);
    }
    public override bool Round(int goesFirst)
    {
        bool over = false;
        DisplayHandsAndStacks();
        // First player turn
        if (goesFirst == 1)
        {
            Turn(_user);
        }
        else if (goesFirst == 2)
        {
            Turn(_computer);
        }
        // Second player turn
        if (goesFirst == 1)
        {
            Turn(_computer);
        }
        else if (goesFirst == 2)
        {
            Turn(_user);
        }


        over = true;

        return over;
    }
    private void Turn(Player player)
    {
        // Calls the Player.Draw() method, Game.Play() method, and any other methods necessary for a player to take a turn in that game. Returns points earned, or if no points involved, checks if the game is over and who won if so.

        player.Draw(_drawPile);
        Play(player);

        if (player.GetHand().GetDeck().Count == 0)
        {
            int points = 1;
            player.UpdatePoints(points);
        }
    }
    private void Play(Player player)
    {
        // Pick whether to play a card, move a stack, or draw a card

        //do while !validity
        string whatDo = player.Play("Enter 'play' to play a card, 'move' to move a stack, or 'draw' to draw a new card from the deck: ").ToLower();
        do
        {
            if (player.GetType().Name.ToLower() == "computer")
            {
                whatDo = "auto";




            }
            else if (whatDo == "play")
            {
                // Play card
                int i = 0;
                string cardString;
                do
                {
                    string invalid = "";
                    if (i != 0)
                    {
                        invalid = "That is not a valid selection. ";
                    }
                    cardString = player.Play($"{invalid}Please enter the value or letter and first letter of the suit of the card (from your hand) that you wish to play (Ex: 🂾 K ♥ => 'K H', 🂧 7 ♠ => '7 S', 🃊 10 ♦ => '10 D', 🃛 J ♣ => 'J C'): ").ToLower();
                    i++;
                } while (cardString != "thing");

                // foreach card in hand if card.getnumber && card.getsuit are equal to the entered stuff


                Card card = new Card(1,"other"); // placeholder

                i = 0;
                string stack;
                do
                {
                    string invalid = "";
                    if (i != 0)
                    {
                        invalid = "That is not a valid selection. ";
                    }
                    stack = player.Play($"{invalid}Please enter the name/label of the stack you wish to play your card on (Ex: 'E', 'NW'): ").ToLower();
                    i++;
                } while (stack != "n" && stack != "e" && stack != "s" && stack != "w" && stack != "ne" && stack != "se" && stack != "sw" && stack != "nw");

                PlayCard(card, stack);
            }
            else if (whatDo == "move")
            {
                // Move stack
                int i = 0;
                string stack1;
                do
                {
                    string invalid = "";
                    if (i != 0)
                    {
                        invalid = "That is not a valid selection. ";
                    }
                    stack1 = player.Play($"{invalid}Please enter the name/label of the stack you wish to move (Ex: 'N', 'SE'): ").ToLower();
                    i++;
                } while (stack1 != "n" && stack1 != "e" && stack1 != "s" && stack1 != "w" && stack1 != "ne" && stack1 != "se" && stack1 != "sw" && stack1 != "nw");

                i = 0;
                string stack2;
                do
                {
                    string invalid = "";
                    if (i != 0)
                    {
                        invalid = "That is not a valid selection. ";
                    }
                    stack2 = player.Play($"{invalid}Please enter the name/label of the stack you wish to move the contents of the first stack to (Ex: 'NW', 'S'): ").ToLower();
                    i++;
                } while (stack2 != "n" && stack2 != "e" && stack2 != "s" && stack2 != "w" && stack2 != "ne" && stack2 != "se" && stack2 != "sw" && stack2 != "nw");

                MoveStack(stack1, stack2);
            }
            else if (whatDo == "draw")
            {
                // Draw card
                player.Draw(_drawPile);
                DisplayHandsAndStacks();
            }

        } while (whatDo != "play" && whatDo != "move" && whatDo != "draw" && whatDo != "auto");
    }
    private void PlayCard(Card card, string stack)
    {

        // response if invalid move?

        DisplayHandsAndStacks();

        //return validity (bool)
    }
    private void MoveStack(string stack1, string stack2)
    {
        // Automatically places player's highest card unless they have multiple of the highest value, in which case the player chooses which to place?

        // response if invalid move?

        DisplayHandsAndStacks();
        //return validity (bool)
    }
    private void DisplayHandsAndStacks()
    {
        Console.Clear(); Console.WriteLine("\x1b[3J"); Console.Clear();
        _aesthetic.WriteCenterText("~*~ Kings in the Corner ~*~");
        Console.WriteLine();
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