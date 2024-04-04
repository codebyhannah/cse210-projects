using System;

public class GameManager
{
    // --- Attributes ---
    private List<string> _GameOptions = new List<string>{"Kings in the Corner","Quit"};

    // --- Constructors ---
    public GameManager()
    {
        // Empty
    }

    // --- Methods ---
    public void Start()
    {
        Console.Clear(); Console.WriteLine("\x1b[3J"); Console.Clear();
        Console.WriteLine("~*~ Card Games ~*~");
        Console.WriteLine();
        Menu gameMenu = new Menu(_GameOptions);
        int choice = gameMenu.ChooseMenuOption();
        if (choice == 1)
        {
            KingsInTheCorner kings = new KingsInTheCorner();
            kings.Start();
        }
        else
        {
            Console.WriteLine("Goodbye!");
            Console.WriteLine();
            Thread.Sleep(500);
        }
    }
}