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
        int promptNum = randomGenerator.Next(0, _prompts.Count);
        _promptText = _prompts[promptNum];
        Console.WriteLine($"Prompt: {_promptText}");
    }
    public void DisplayEntry()
    {
        Console.WriteLine($"~*~ {_date.ToLongDateString()} ~*~");
        Console.WriteLine();
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine();
        foreach(string l in _entryText)
        {
            Console.WriteLine(l);
        }
        Console.WriteLine();
    }
    public void Update()
    {
        bool again = false;
        do // While again is true
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
            do // While done is false
            {
                line = Console.ReadLine();
                if (line.ToLower() != "done" && line.ToLower() != "prompt")
                {
                    _entryText.Add(line);
                }
                else if (line.ToLower() == "prompt")
                {
                    // If the user inpupts "prompt", the prompt is randomized and replaced by a new prompt, which is then displayed for the user to see.
                    DisplayRandomPrompt();
                }
                else if (line.ToLower() == "done")
                {
                    // This exceeds requirements by adding a way to undo mistakes made while making an entry and an option for changing one's mind about making an entry without having to end the program and start over, and without adding the undesired material to the journal.
                    Console.WriteLine();
                    Console.Write("Do you want to 1. SAVE this entry, 2. DISCARD and start over, or 3. QUIT to menu without saving? (Please enter the number associated with your choice) ");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        // Entry is kept as entered, and will be added to the Journal _entries list, as _entryText has content.
                        Console.WriteLine();
                        Console.WriteLine("Entry Saved To Journal!");
                        again = false;
                        done = true;
                    }
                    else if (choice == "2")
                    {
                        // _entryText is emptied and the entry will not be added to the Journal _entries list, as it is set not to add empty entries. The Update function is repeated without changing the original prompt.
                        _entryText.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Entry Discarded");
                        again = true;
                        done = true;
                    }
                    else if (choice == "3")
                    {
                        // _entryText is emptied and the entry will not be added to the Journal _entries list, as it is set not to add empty entries. The Update funtion ends.
                        _entryText.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Entry Discarded");
                        again = false;
                        done = true;
                    }
                }
            }while(!done);
            Console.WriteLine();
        }while(again);
    }
}