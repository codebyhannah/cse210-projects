using System;

public class Menu
{
    // --- Attributes ---
    private List<string> _menuOptions = new List<string>();

    // --- Constructors ---

    public Menu(List<string> menuOptions)
    {
        _menuOptions = menuOptions;
    }

    // --- Methods ---
    public void DisplayMenu()
    {
        Console.WriteLine("~*~ Menu ~*~");
        int i = 1;
        foreach(string option in _menuOptions)
        {
            Console.WriteLine($"{i}. {option}");
            i++;
        }
        Console.WriteLine();
    }
    public int ChooseMenuOption()
        {
            DisplayMenu();
            string menuChoice = "0";
            do
            {
                if (!int.TryParse(menuChoice, out int j))
                {
                    Console.Write("Please enter the number associated with your choice (integers only): ");
                }
                else if (int.Parse(menuChoice) > _menuOptions.Count || int.Parse(menuChoice) < 0)
                {
                    Console.Write("Please enter the number (from the menu) associated with your choice: ");
                }
                else
                {
                    Console.Write("Please enter the number associated with your choice: ");
                }
                menuChoice = Console.ReadLine();
                Console.WriteLine();
            }while (!int.TryParse(menuChoice, out int n) || int.Parse(menuChoice) > _menuOptions.Count || int.Parse(menuChoice) <= 0);
            return int.Parse(menuChoice);
        }
}