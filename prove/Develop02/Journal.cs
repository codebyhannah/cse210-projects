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
        _menu._menuOptions = new List<string>{"Open Journal File", "Display Journal", "Create New Entry", "Save Journal", "Quit"};
        bool quit = false;
        do
        {
            int option = _menu.ChooseMenuOption();
            if (option == 1)
            {
                OpenJournalFile();
            }
            else if (option == 2)
            {
                DisplayJournal();
                // add "return to menu (yes/no)? " thing and a select entry option for editing. Also add an edit function to entry.cs. select entry funtion skeleton below under create entry
                //Console.WriteLine("Enter 'done' to return to menu, or enter an entry number (integers only) to select an entry for editing.");
                //Console.WriteLine();
            }
            else if (option == 3)
            {
                CreateEntry();
            }
            else if (option == 4)
            {
                SaveJournalFile();
            }
            else if (option == 5)
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
    public void SelectEntry()
    {
        // select entry option for editing. Also add an edit function to entry.cs, like entry.Edit();
    }
    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Journal empty, or no Journal file open. Please create a new entry or open a Journal file before displaying Journal.");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("~*~ JOURNAL ~*~");
            Console.WriteLine();
            int num = 1;
            foreach (Entry entry in _entries)
            {
                Console.Write($"Entry {num} ");
                entry.DisplayEntry();
                num++;
            }
        }
    }
    public void OpenJournalFile()
    {
        Document journal =  new Document();
        Console.Write("Enter filename to open Journal from: ");
        journal._filename = Console.ReadLine();
        Console.WriteLine();
        journal.ReadFile();
        foreach (List<string> item in journal._contents)
        {
            Entry entry = new Entry();
            foreach (string line in item)
            {
                if (line == item[0])
                {
                    entry._date = DateTime.Parse(line);
                }
                else if (line == item[1])
                {
                    entry._promptText = line;
                }
                else
                {
                    entry._entryText.Add(line);
                }
            }
            _entries.Add(entry);
            Console.WriteLine("Journal Loaded.");
            Console.WriteLine();
            DisplayJournal();
        }
    }
    public void SaveJournalFile()
    {
        Document journal =  new Document();
        Console.Write("Save as: ");
        journal._filename = Console.ReadLine();
        foreach (Entry entry in _entries)
        {
            List<string> entryContents = new List<string>{$"{entry._date.ToLongDateString()}", $"{entry._promptText}"};
            foreach (string line in entry._entryText)
            {
                entryContents.Add(line);
            }
            journal._transcript.Add(entryContents);
        }
        journal.SaveFile();
    }
}