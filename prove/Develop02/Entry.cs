using System;

public class Entry
{
    // --- Attributes ---
    public string _entryText;
    public string _promptText;
    public List<string> _prompts = new List<string>{"Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?"};
    public DateTime _date = DateTime.Now;

    // --- Behaviors ---
    public void DisplayRandomPrompt()
    {
        Random randomGenerator = new Random();
        int promptNum = randomGenerator.Next(0, _prompts.Count-1);
        _promptText = _prompts[promptNum];
        Console.WriteLine(_promptText);
    }
    public void DisplayEntry()
    {
        
    }
    public void Update()
    {
        /* Console.Write()"Do you want to 1. SAVE this entry, 2. DISCARD and start over, or 3. QUIT to menu? (Please enter the number associated with your choice) ");
        string choice = Console.ReadLine(); */
    }
}