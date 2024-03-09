using System;

public class Entry
{
    // --- Attributes ---
    public List<string> _entryText = new List<string>();
    public string _promptText;
    public List<string> _prompts = new List<string>{"Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?", "Did anything unusual happen today?", "What am I grateful for today?"};
    public DateTime _date = DateTime.Now;

    // --- Behaviors ---
    public void DisplayRandomPrompt()
    {
        Random randomGenerator = new Random();
        int promptNum = randomGenerator.Next(0, _prompts.Count-1);
        _promptText = _prompts[promptNum];
        Console.WriteLine($"Prompt: {_promptText}");
    }
    public void DisplayEntry()
    {
        Console.WriteLine($"~*~ {_date.ToLongDateString()} ~*~");
        Console.WriteLine($"Prompt: {_promptText}");
        foreach(string l in _entryText)
        {
            Console.WriteLine(l);
        }
    }
    public void Update()
    {
        bool again = false;
        do
        {
            Console.WriteLine("~*~ NEW ENTRY ~*~");
            Console.WriteLine();
            Console.WriteLine("Enter 'done' on a new line when ready to save, discard, or quit to menu. Enter 'prompt' on a new line to receive a new prompt.");
            Console.WriteLine();
            Console.WriteLine($"~*~ {_date.ToLongDateString()} ~*~");
            Console.WriteLine();
            if (!again)
            {
                DisplayRandomPrompt();
            }
            else if (again)
            {
                Console.WriteLine($"Prompt: {_promptText}");
            }
            Console.WriteLine();
            string line;
            bool done = false;
            do
            {
                line = Console.ReadLine();
                if (line.ToLower() != "done" && line.ToLower() != "prompt")
                {
                    _entryText.Add(line);
                }
                else if (line.ToLower() == "prompt")
                {
                    DisplayRandomPrompt();
                }
                else if (line.ToLower() == "done")
                {
                    Console.WriteLine();
                    Console.Write("Do you want to 1. SAVE this entry, 2. DISCARD and start over, or 3. QUIT to menu without saving? (Please enter the number associated with your choice) ");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Console.WriteLine("Entry Saved To Journal!");
                        done = true;
                    }
                    else if (choice == "2")
                    {
                        _entryText.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Entry Discarded");
                        again = true;
                        done = true;
                    }
                    else if (choice == "3")
                    {
                        _entryText.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Entry Discarded");
                        done = true;
                    }
                }
            }while(!done);
            Console.WriteLine();
        }while(again);
    }
}