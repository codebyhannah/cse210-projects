using System;

class ReflectionActivity : PromptedActivity
{
    // --- Attributes ---
    private List<string> _reflectQuestions = new List<string> {"Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?"};
    private List<string> _usedQuestions = new List<string>();
    private string _originalPrompt;

    // --- Constructors ---
    public ReflectionActivity(string activityName = "Reflection Activity", string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life. The activity may last up to 9 seconds longer than the user input duration, due to given reflection time.") : base(activityName, description)
    {
        _prompts = new List<string> {"Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."};
    }

    // --- Methods ---
    public void Run()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        DateTime currentTime;
        GetRandomPrompt();
        Console.Write($"Prompt: {_promptText}   ");
        _originalPrompt = _promptText;
        DisplayPauseAnimation("spin", 10);
        Console.WriteLine();
        Console.WriteLine();
        currentTime = DateTime.Now;
        if (currentTime < endTime)
        {
            Console.WriteLine("Please reflect on these questions as they relate to this experience.");
            Console.WriteLine();
            do
            {
                do
                {
                    // Exceeds requirements by using all questions once before reusing any in the session.
                    List<string> compare = _reflectQuestions.Except(_usedQuestions).ToList();
                    if (compare.Count <= 0)
                    {
                        Console.WriteLine("All questions used, recycling.");
                        Console.WriteLine();
                        _usedQuestions.Clear();
                    }
                    else
                    {
                        GetRandomPrompt(_reflectQuestions);
                    }
                } while (_usedQuestions.Contains(_promptText));
                Console.Write($"*   {_promptText}   ");
                DisplayPauseAnimation("spin", 5);
                Console.WriteLine();
                Console.WriteLine();
                _usedQuestions.Add(_promptText);
                currentTime = DateTime.Now;
            } while(currentTime < endTime);
        }
        // The activity may last up to 9 seconds longer than the user input duration, due to given reflection time.
        _trueDuration = (currentTime - startTime).Seconds;
    }
}