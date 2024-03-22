using System;

class ListingActivity : PromptedActivity
{
    // --- Attributes ---
    private List<string> _userResponse = new List<string>();

    // --- Constructors ---
    public ListingActivity(string activityName = "Listing Activity", string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area. The activity may last longer than the user input duration, due to given reflection time and time taken while entering an item.") : base(activityName, description)
    {
        _prompts = new List<string>{"Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"};
    }

    // --- Methods ---
    public void Run()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        DateTime currentTime;
        Console.WriteLine($"Prompt: {GetRandomPrompt()}");
        Console.WriteLine();
        DisplayPauseAnimation("countdown", 10);
        Console.WriteLine("List as many items as you can in the time given!");
        Console.WriteLine();
        do
        {
            Console.Write("  *  ");
            _userResponse.Add(Console.ReadLine());
            Console.WriteLine();
            currentTime = DateTime.Now;
        } while(currentTime < endTime);
        _trueDuration = (currentTime - startTime).Seconds;
        string s;
        if (_userResponse.Count == 1)
        {
            s = "";
        }
        else
        {
            s = "s";
        }
        Console.WriteLine($"You listed {_userResponse.Count} item{s}!");
    }
}