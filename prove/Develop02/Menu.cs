using System;

public class Menu
{
    // --- Attributes ---
    public List<string> _menu = new List<string>{"Display Journal", "Create New Entry", "Save Journal", "Quit"};

    // --- Behaviors ---
    public void DisplayMenu()
    {
        int i = 1;
        foreach(string option in _menu)
        {
            Console.WriteLine($"{i}. {option}");
            i++;
        }
    }
    public void ChooseMenuOption()
        {
            string menuChoice = "1";
            if (menuChoice == "1")
            {

            }
        }
}