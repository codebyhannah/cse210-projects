using System;
class Activity
{
    // --- Attributes ---
    private string _activityName;
    private string _description;
    protected int _duration;   // Duration in seconds
    protected int _trueDuration;

    // --- Constructors ---
    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    // --- Methods ---
    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"~*~ {_activityName} ~*~");
        Console.WriteLine();
        Console.WriteLine($"{_description}");
        Console.WriteLine();
        string durString;
        Console.Write("Please enter the duration (in seconds) of this activity session: ");
        durString = Console.ReadLine();
        do
        {
            if(int.TryParse(durString, out int j))
            {
                _duration = j;
            }
            else if (!int.TryParse(durString, out int k))
            {
                Console.Write("Please enter the duration (in seconds) of this activity session (integers only): ");
                durString = Console.ReadLine();
            }
        } while (!int.TryParse(durString, out int n));
        Console.WriteLine();
        Console.Write("Get ready");
        DisplayPauseAnimation("dots", 5);
        Console.Write("...");
        Console.WriteLine();
        Console.WriteLine();
    }
    public void End()
    {
        Console.WriteLine("Good Job!");
        Console.WriteLine();
        Console.WriteLine($"You have completed {_trueDuration} seconds of the {_activityName}.");
        Console.WriteLine();
    }
    protected void DisplayPauseAnimation(string spinnerType, int timeLength, int includeZero = -1)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(timeLength);
        DateTime currentTime;
        if(spinnerType == "spin")
        {
            int i = 1;
            do
            {            
                if (i == 1)
                {
                    Console.Write("|   ");
                    Thread.Sleep(500);
                    Console.Write("\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 2)
                {
                    Console.Write("/   ");
                    Thread.Sleep(500);
                    Console.Write("\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 3)
                {
                    Console.Write("--  ");
                    Thread.Sleep(500);
                    Console.Write("\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 4)
                {
                    Console.Write(@"\   ");
                    Thread.Sleep(500);
                    Console.Write("\b \b\b \b\b \b\b \b");
                    i = 1;
                }
                currentTime = DateTime.Now;
            } while(currentTime < endTime);
        }
        else if (spinnerType == "dots")
        { 
            int i = 1;
            do
            {            
                if (i == 1)
                {
                    Console.Write(".     ");
                    Thread.Sleep(500);
                    Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 2)
                {
                    Console.Write("..    ");
                    Thread.Sleep(500);
                    Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 3)
                {
                    Console.Write("...   ");
                    Thread.Sleep(500);
                    Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 4)
                {
                    Console.Write("      ");
                    Thread.Sleep(500);
                    Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b");
                    i = 1;
                }
                currentTime = DateTime.Now;
            } while(currentTime < endTime);
        }
        else if (spinnerType == "countdown")
        { 
            int i = timeLength;
            do
            {            
                Console.Write($"{i}   ");
                Thread.Sleep(1000);
                // Remove tab
                Console.Write("\b \b\b \b\b \b");
                // Remove number (any length of characters)
                for (int k = i.ToString().Length; k > 0; k--)
                {
                    Console.Write("\b \b");
                }
                i--;
                currentTime = DateTime.Now;
            } while(currentTime < endTime);
            if (includeZero == 0)
            {
                Console.Write($"0   ");
                Thread.Sleep(1000);
                Console.Write("\b \b\b \b\b \b\b \b");
            }   
        }
    }
    public void SaveToLog() 
    {
        // _activityName, _description, and _durations as well as any user content

    }    
}