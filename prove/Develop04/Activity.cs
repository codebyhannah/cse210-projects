using System;
class Activity
{
    // --- Attributes ---
    private string _activityName;
    private string _description;
    private int _duration;   // Duration in seconds

    // --- Constructors ---
    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    // --- Methods ---
    public void Start()
    {
        Console.WriteLine($"~*~{_activityName}~*~");
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
        Console.WriteLine("Please prepare to begin the activity.");
        Console.WriteLine();
        DisplayPauseAnimation("spin", 5);
        Console.WriteLine("yolo");
    }
    public void End()
    {
        
    }
    protected void DisplayPauseAnimation(string spinnerType, int timeLength)
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
                    Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 2)
                {
                    Console.Write("..    ");
                    Thread.Sleep(500);
                    Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 3)
                {
                    Console.Write("...   ");
                    Thread.Sleep(500);
                    Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 4)
                {
                    Console.Write("      ");
                    Thread.Sleep(500);
                    Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b \b");
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
                Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b \b");
                i--;
                currentTime = DateTime.Now;
            } while(currentTime < endTime);
            Console.Write($"0   ");
            Thread.Sleep(1000);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b \b");
        }
    }
    public void SaveToLog() 
    {
        // _activityName, _description, and _durations as well as any user content

    }    
}