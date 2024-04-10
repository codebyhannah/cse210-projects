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
        _rules = "Each player is dealt seven cards. The remaining cards are placed in the center as the drawpile, and the top four cards are turned over, placing one on each on the four sides of the deck as the beginning stacks.\nPlayers begin each turn by drawing one card from the drawpile. They make as many valid moves as possible during their turn to get rid of as many cards as possible from their hand.\nCards must be played alternating red and black in numerical sequence, lower values on top of the next value up. Aces are the lowest card.\nKings, and only kings, may be played in the corner. Once a king is in a corner, players may build off of it like any other stack.\nPlayers may also move an entire stack onto another stack, providing that the last card of the destination stack and the first card of the moving stack are in valid sequence. Player must then play their highest card on the newly empty stack.\nThe first player to lose all of their cards wins.";
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

        string[] rulesArray = _rules.Split("\n");
        foreach(string line in rulesArray)
        {
            Console.WriteLine(line);
            Console.WriteLine();
        }
        _aesthetic.WriteCenterText("Press 'enter' to start.",false);
        Console.ReadLine();
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
            //over = Round(goesFirst);
            over = true;
        } while (!over);
        if (over)
        {
            Console.Clear(); Console.WriteLine("\x1b[3J"); Console.Clear();
            _aesthetic.WriteCenterText("~*~ Game Over ~*~");
            Console.WriteLine();
            if(_user.GetPoints() > 0)
            {
                _aesthetic.WriteCenterText("User Wins!");
            }
            if(_computer.GetPoints() > 0)
            {
                _aesthetic.WriteCenterText("Computer Wins!");
            }
        }
    }
    protected override bool Round(int goesFirst)
    {
        bool over = false;
        DisplayHandsAndStacks();
        // First player turn
        if (goesFirst == 1)
        {
            over = Turn(_user);
        }
        else if (goesFirst == 2)
        {
            over = Turn(_computer);
        }
        if (!over)
        {
            // Second player turn
            if (goesFirst == 1)
            {
                over = Turn(_computer);
            }
            else if (goesFirst == 2)
            {
                over = Turn(_user);
            }
        }
        return over;
    }
    private bool Turn(Player player)
    {
        bool over = false;
        // Calls the Player.Draw() method and Game.Play() method. Checks if the game is over and updates the winner if so.
        if (_drawPile.GetDeck().Count != 0)
        {
            player.Draw(_drawPile);
        }
        DisplayHandsAndStacks();
        Play(player);

        if (player.GetHand().GetDeck().Count == 0)
        {
            int points = 1;
            player.UpdatePoints(points);
            over = true;
        }
        return over;
    }
    private void Play(Player player)
    {
        // Pick whether to play a card, move a stack, or draw a card
        bool valid = false;
        bool done = false;
        do
        {
            Console.WriteLine();
            string whatDo;
            do
            {
                whatDo = player.Play("Enter 'play' to play a card, 'move' to move a stack, 'draw' to draw a new card from the deck, or 'done' when finished with turn: ").ToLower();
                if (player.GetType().Name.ToLower() == "computer")
                {
                    whatDo = "auto";
                    _aesthetic.WriteCenterText("Computer Turn", false);
                    
                    _aesthetic.DisplayPauseAnimation("dots", 3);
                    // Pause of thread between computer actions, to allow user to see each move the computer makes individually and make it feel more natural

                    valid = AutoPlay(player);
                    if (valid)
                    {
                        done = true;
                        Console.WriteLine("turn over");
                    }

                }
                else if (whatDo == "play")
                {
                    // Play card
                    Console.WriteLine();
                    int i = 0;
                    string cardValueString;
                    do
                    {
                        string invalid = "";
                        if (i != 0)
                        {
                            invalid = "That is not a valid selection. ";
                        }
                        cardValueString = player.Play($"{invalid}Please enter the value or letter of the card (from your hand) that you wish to play (Ex: 🂾 K ♥ => 'K', 🂧 7 ♠ => '7', 🃊 10 ♦ => '10', 🃛 J ♣ => 'J'): ").ToLower();
                        if (cardValueString == "a")
                        {
                            cardValueString = "1";
                        }
                        else if (cardValueString == "j")
                        {
                            cardValueString = "11";
                        }
                        else if (cardValueString == "q")
                        {
                            cardValueString = "12";
                        }
                        else if (cardValueString == "k")
                        {
                            cardValueString = "13";
                        }
                        Console.WriteLine();
                        i++;
                    } while (!(int.TryParse(cardValueString, out int n) && n < 14 && n > 0));
                    int cardValue = int.Parse(cardValueString);
                    i = 0;
                    string cardSuit;
                    do
                    {
                        string invalid = "";
                        if (i != 0)
                        {
                            invalid = "That is not a valid selection. ";
                        }
                        cardSuit = player.Play($"{invalid}Please enter the first letter of the suit of the card (from your hand) that you wish to play (Ex: 🂾 K ♥ => 'H', 🂧 7 ♠ => 'S', 🃊 10 ♦ => 'D', 🃛 J ♣ => 'C'): ").ToLower();
                        Console.WriteLine();
                        if (cardSuit == "h")
                        {
                            cardSuit = "♥";
                        }
                        else if (cardSuit == "s")
                        {
                            cardSuit = "♠";
                        }
                        else if (cardSuit == "d")
                        {
                            cardSuit = "♦";
                        }
                        else if (cardSuit == "c")
                        {
                            cardSuit = "♣";
                        }
                        i++;
                    } while (cardSuit != "♥" && cardSuit != "♠" && cardSuit != "♦" && cardSuit != "♣");
                    bool inHand = false;
                    Deck hand = player.GetHand();
                    Card card = new Card(1, "other");
                    foreach(Card handCard in hand.GetDeck())
                    {
                        if (handCard.GetSuit() == cardSuit)
                        {
                            if (handCard.GetNumber() == cardValue)
                            {
                                inHand = true;
                                card = handCard;
                            }
                        }
                    }
                    if (inHand == false)
                    {
                        _aesthetic.WriteCenterText("This card is not in your hand, please try again.");
                        _aesthetic.DisplayPauseAnimation("dots",3);
                        valid = false;
                    }
                    else
                    {
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
                            Console.WriteLine();
                            i++;
                        } while (stack != "n" && stack != "e" && stack != "s" && stack != "w" && stack != "ne" && stack != "se" && stack != "sw" && stack != "nw");
                        valid = PlayCard(player, card, stack);
                    }
                }
                else if (whatDo == "move")
                {
                    // Move stack
                    Console.WriteLine();
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
                        Console.WriteLine();
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
                        Console.WriteLine();
                        i++;
                    } while (stack2 != "n" && stack2 != "e" && stack2 != "s" && stack2 != "w" && stack2 != "ne" && stack2 != "se" && stack2 != "sw" && stack2 != "nw");

                    valid = MoveStack(player, stack1, stack2);

                    // add necessary play of highest card in hand to newly empty stack



                }
                else if (whatDo == "draw")
                {
                    // Draw card
                    if (_drawPile.GetDeck().Count != 0)
                    {
                        player.Draw(_drawPile);
                        DisplayHandsAndStacks();
                    }
                    else
                    {
                        _aesthetic.WriteCenterText("Drawpile empty");
                    }
                    valid = false;
                }
                else if (whatDo == "done" || player.GetHand().GetDeck().Count == 0)
                {
                    if (!valid)
                    {
                        // Which would mean that neither a card has been succesfully played nor a stack successfully moved.
                        Console.WriteLine();
                        _aesthetic.WriteCenterText("You must play at least one card or move at least one stack before your turn is over. If you cannot do either, draw cards until you can.");
                        Console.ReadLine();
                    }
                    else
                    {
                        done = true;
                    }
                }

            } while (whatDo != "play" && whatDo != "move" && whatDo != "draw" && whatDo != "done" && whatDo != "auto");
        } while (!valid || !done);
    }
    private bool AutoPlay(Player player)
    {
        bool valid = false;
        bool validAtAnyPoint = false;
        do
        {
            // Move stacks
            foreach(Deck stack in _sidesAndCorners)
            {
                List<Deck> minusStack = new List<Deck>();
                minusStack.AddRange(_sidesAndCorners);
                minusStack.RemoveAt(_sidesAndCorners.IndexOf(stack));
                foreach (Deck destination in minusStack)
                {
                    valid = MoveStack(player, stack.GetName(), destination.GetName());
                    if (valid == true)
                    {
                        validAtAnyPoint = true;
                        Console.WriteLine();
                        _aesthetic.WriteCenterText($"Computer moved {stack.GetName().ToUpper()} to {destination.GetName().ToUpper()}", false);
                        _aesthetic.DisplayPauseAnimation("dots",3);
                        // Pause of thread between computer actions, to allow user to see each move the computer makes individually and make it feel more natural
                    }
                }
            }
            // Play cards
            if (player.GetHand().GetDeck().Count != 0)
            {
                List<Card> hand = new List<Card>();
                hand.AddRange(player.GetHand().GetDeck());
                foreach(Card card in hand)
                {
                    foreach(Deck stack in _sidesAndCorners)
                    {
                        if (player.GetHand().GetDeck().Contains(card))
                        {
                            valid = PlayCard(player, card, stack.GetName());
                            if (valid == true)
                            {
                                validAtAnyPoint = true;
                                Console.WriteLine();
                                _aesthetic.WriteCenterText($"Computer played {card.GetCardForDisplay()} on {stack.GetName().ToUpper()}", false);
                                _aesthetic.DisplayPauseAnimation("dots",3);
                                // Pause of thread between computer actions, to allow user to see each move the computer makes individually and make it feel more natural
                            }
                        }
                    }
                }
            }
            else 
            {
                // Hand empty
                valid = true;
                if (valid == true)
                {
                    validAtAnyPoint = true;
                }
            }
            if (validAtAnyPoint == false)
            {
                // Draw card
                if (_drawPile.GetDeck().Count != 0)
                {
                    player.Draw(_drawPile);
                    DisplayHandsAndStacks();
                    valid = false;
                    Console.WriteLine();
                    _aesthetic.WriteCenterText($"Computer drew new card from drawpile", false);
                    _aesthetic.DisplayPauseAnimation("dots",3);
                    // Pause of thread between computer actions, to allow user to see each move the computer makes individually and make it feel more natural
                }
                else
                {
                    // Deck empty
                    if (valid == false)
                    {
                        // No moves were possible but can't draw, so the turn must end if it hasn't already
                        valid = true;
                        validAtAnyPoint = true;
                    }
                    else
                    {
                        valid = false;
                    }
                }
            }
        } while (validAtAnyPoint == false);
        return validAtAnyPoint;
    }
    private bool PlayCard(Player player, Card card, string stackString)
    {
        bool isUser = true;
        if (player.GetType().Name.ToLower() == "computer")
        {
            isUser = false;
        }
        Deck stack = StackFromString(stackString);
        bool valid = CheckMoveValidity(stack, card, isUser);
        if (valid)
        {
            card = player.GetHand().Draw(player.GetHand().GetDeck().IndexOf(card));
            stack.PlusOne(card);
        }
        if (isUser || (!isUser && valid))
        {
            DisplayHandsAndStacks();
        }
        return valid;
    }
    private bool MoveStack(Player player, string stackString1, string stackString2)
    {
        bool isUser = true;
        if (player.GetType().Name.ToLower() == "computer")
        {
            isUser = false;
        }
        Deck stack1 = StackFromString(stackString1); // Moving
        Deck stack2 = StackFromString(stackString2); // Destination
        bool valid =  false;
        if (stack1 == _northWest || stack1 == _northEast || stack1 == _southWest || stack1 == _southEast)
        {
            if (isUser)
            {
                _aesthetic.WriteCenterText("You cannot move stacks out of the corners, please try again.");
                _aesthetic.DisplayPauseAnimation("dots",3);
            }
            valid = false;
        }
        else if (stack1.GetDeck().Count == 0 || (stack2.GetDeck().Count == 0 && stack2 != _northWest && stack2 != _northEast && stack2 != _southWest && stack2 != _southEast))
        {
            if (isUser)
            {
                _aesthetic.WriteCenterText("This is not a valid move, please try again.");
                _aesthetic.DisplayPauseAnimation("dots",3);
            }
            valid = false;
        }
        else
        {
            valid = CheckMoveValidity(stack2, stack1.GetDeck()[0], isUser);
            if (valid)
            {
                stack2.PlusMany(stack1.GetDeck());
                stack1.GetDeck().Clear();
                // Automatically place player's highest card unless they have multiple of the highest value, in which case the player chooses which to place.
                if (player.GetHand().GetDeck().Count != 0)
                {
                    int highestNum = 0;
                    Card highestCard = new Card(2, "other");
                    List<Card> hand = new List<Card>();
                    hand.AddRange(player.GetHand().GetDeck());
                    foreach (Card card in hand)
                    {
                        if (card.GetNumber() > highestNum || (card.GetNumber() == highestNum && player.GetType().Name.ToLower() == "computer"))
                        {
                            highestNum = card.GetNumber();
                            highestCard = card;
                        }
                        else if (card.GetNumber() == highestNum && player.GetType().Name.ToLower() != "computer")
                        {
                            int i = 0;
                            string cardSuit;
                            do
                            {
                                string invalid = "";
                                if (i != 0)
                                {
                                    invalid = "That is not a valid selection. ";
                                }
                                cardSuit = player.Play($"{invalid}Please enter the first letter of the suit of the card ({highestCard.GetCardForDisplay()} or {card.GetCardForDisplay()}) that you wish to play on {stack2.GetName().ToUpper()} as your highest card (Ex: 🂾 K ♥ => 'H', 🂧 7 ♠ => 'S', 🃊 10 ♦ => 'D', 🃛 J ♣ => 'C'): ").ToLower();
                                Console.WriteLine();
                                if (cardSuit == "h")
                                {
                                    cardSuit = "♥";
                                }
                                else if (cardSuit == "s")
                                {
                                    cardSuit = "♠";
                                }
                                else if (cardSuit == "d")
                                {
                                    cardSuit = "♦";
                                }
                                else if (cardSuit == "c")
                                {
                                    cardSuit = "♣";
                                }
                                i++;
                            } while (cardSuit != highestCard.GetSuit() && cardSuit != card.GetSuit());

                            if (cardSuit == highestCard.GetSuit())
                            {
                                //highestCard = highestCard; //Nothing changes
                            }
                            else if (cardSuit == card.GetSuit())
                            {
                                highestCard = card;
                            }
                        }
                    }
                    PlayCard(player, highestCard, stack1.GetName());
                }
            }
        }
        if (isUser || (!isUser && valid))
        {
            DisplayHandsAndStacks();
        }
        return valid;
    }
    private Deck StackFromString(string stackString)
    {
        Deck stack = new Deck("deck");
        if (stackString == "n")
        {
            stack = _north;
        }
        else if (stackString == "e")
        {
            stack = _east;
        }
        else if (stackString == "s")
        {
            stack = _south;
        }
        else if (stackString == "w")
        {
            stack = _west;
        }
        else if (stackString == "ne")
        {
            stack = _northEast;
        }
        else if (stackString == "se")
        {
            stack = _southEast;
        }
        else if (stackString == "sw")
        {
            stack = _southWest;
        }
        else if (stackString == "nw")
        {
            stack = _northWest;
        }
        return stack;
    }
    private bool CheckMoveValidity(Deck stack, Card card, bool isUser = true)
    {
        bool valid = false;
        int len = stack.GetDeck().Count;
        if (len != 0)
        {
            Card last = stack.GetDeck()[len-1];
            if (last.GetNumber() == card.GetNumber()+1)
            {
                // If card numbers are correctly in sequence
                if ((last.GetSuit() == "♠" || last.GetSuit() == "♣") && (card.GetSuit() == "♥" || card.GetSuit() == "♦"))
                {
                    // If last card is black and new card is red
                    valid = true;
                }
                else if ((last.GetSuit() == "♥" || last.GetSuit() == "♦") && (card.GetSuit() == "♠" || card.GetSuit() == "♣"))
                {
                    // If last card is red and new card is black
                    valid = true;
                }
                else
                {
                    if (isUser)
                    {
                        _aesthetic.WriteCenterText("This is not a valid move, please try again.");
                        _aesthetic.DisplayPauseAnimation("dots",3);
                    }
                    valid = false;
                }
            }
            else
            {
                if (isUser)
                {
                    _aesthetic.WriteCenterText("This is not a valid move, please try again.");
                    _aesthetic.DisplayPauseAnimation("dots",3);
                }
                valid = false;
            }
        }
        else
        {
            if (stack == _northEast || stack == _northWest || stack == _southEast || stack == _southWest)
            {
                if (card.GetNumber() == 13)
                {
                    valid = true;
                }
                else
                {
                    if (isUser)
                    {
                        _aesthetic.WriteCenterText("Only kings may start stacks in the corners, please try again.");
                        _aesthetic.DisplayPauseAnimation("dots",3);
                    }
                    valid = false;
                }
            }
            else
            {
                valid = true;
            }
        }
        return valid;
    }
    private void DisplayHandsAndStacks()
    {
        Console.Clear(); Console.WriteLine("\x1b[3J"); Console.Clear();
        _aesthetic.WriteCenterText("~*~ Kings in the Corner ~*~");
        Console.WriteLine();
        _aesthetic.WriteCenterText("Computer Hand");
        _aesthetic.CenteredLineOfCharacters("-", _computer.GetHandForDisplay().Length/*_computer.GetHiddenHandForDisplay().Length*/ - _computer.GetHand().GetDeck().Count() +2);
        _aesthetic.WriteCenterText(_computer.GetHandForDisplay()/*_computer.GetHiddenHandForDisplay()*/);
        _aesthetic.CenteredLineOfCharacters("-", _computer.GetHandForDisplay().Length/*_computer.GetHiddenHandForDisplay().Length*/ - _computer.GetHand().GetDeck().Count() +2);
        
        DisplayStacks();

        _aesthetic.WriteCenterText("User Hand");
        _aesthetic.CenteredLineOfCharacters("-", _user.GetHandForDisplay().Length - _user.GetHand().GetDeck().Count() +2);
        _aesthetic.WriteCenterText(_user.GetHandForDisplay());
        _aesthetic.CenteredLineOfCharacters("-", _user.GetHandForDisplay().Length - _user.GetHand().GetDeck().Count() +2);
    }
    private void DisplayStacks()
    {
        // 8 columns
        _aesthetic.WriteCenterText("Stacks");
        _aesthetic.CenteredLineOfCharacters("-",123);
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
            _aesthetic.CenteredLineOfCharacters("-",len+2);
        }
        _aesthetic.CenteredLineOfCharacters("-",123);
    }
}