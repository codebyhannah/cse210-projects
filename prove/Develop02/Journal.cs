using System;
using System.Net;

public class Journal
{
    // --- Attributes ---
    public List<Entry> _entries = new List<Entry>();
    public string _filename;
    public Menu _menu = new Menu();

    // --- Behaviors ---
    public void OpenMenu()
    {
        _menu._menuOptions = new List<string>{"Display Journal", "Create New Entry", "Save Journal", "Quit"};
        bool quit = false;
        do
        {
            int option = _menu.ChooseMenuOption();
            if (option == 1)
            {
                DisplayJournal();
            }
            else if (option == 2)
            {
                CreateEntry();
            }
            else if (option == 3)
            {
                SaveJournalFile();
            }
            else
            {
                Console.WriteLine("Remember to save changes before quitting.");
                Console.WriteLine();
                string response = "";
                do
                {
                    if (response == "yes")
                    {
                        Console.WriteLine("Goodbye!");
                        quit = true;
                    }
                    else if (response != "yes" && response != "no")
                    {
                        Console.Write("Do you want to end the program (yes/no)? ");
                        response = Console.ReadLine().ToLower();
                        if (response == "yes")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Goodbye!");
                            quit = true;
                        }
                    }
                    Console.WriteLine();
                }while(response != "yes" && response != "no"); 
            }
        }while(!quit);
    }
    public void CreateEntry()
    {
        Entry entry = new Entry();
        entry.Update();
        if (entry._entryText.Count != 0)
        {
            _entries.Add(entry);
        }
    }
    public void DisplayJournal()
    {

    }
    public string[] ReadJournalFile()
    {
        string[] yo = {"yo","yo"};
        return yo;
    }
    public void SaveJournalFile()
    {

    }
}