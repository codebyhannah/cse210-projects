using System;

class BreathingActivity : Activity
{
    // --- Constructors ---
    public BreathingActivity(string activityName = "Breathing Activity", string description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing. The activity may last up to 11 seconds longer than the user input duration, due to breathing length and extra ending exhale if activity would otherwise end on an inhale.") : base(activityName, description)
    {

    }

    // --- Methods ---
    public void Run()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        DateTime currentTime;
        int i = 1;
        do
        {
            if (i == 1)
            {
                Console.Write("Breathe in...   ");
                DisplayPauseAnimation("countdown", 6);
                i++;
            }
            else if (i == 2)
            {
                Console.Write("Breathe out...   ");
                DisplayPauseAnimation("countdown", 6);
                i = 1;
                Console.WriteLine();
                Console.WriteLine();
            }
            currentTime = DateTime.Now;
        } while(currentTime < endTime);
        if (i == 2)
        {
            // Extra exhale if left off on breathe in.
            Console.Write("Breathe out...   ");
            DisplayPauseAnimation("countdown", 6);
            Console.WriteLine();
            Console.WriteLine();
            currentTime = DateTime.Now;
        }
        _trueDuration = (currentTime - startTime).Seconds;
    }
}
