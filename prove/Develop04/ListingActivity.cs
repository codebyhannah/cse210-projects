using System;

class ListingActivity : PromptedActivity
{
    // --- Attributes ---
   private int  _count;
    private List<string> _userResponse;

    // --- Constructors ---
    public ListingActivity(string activityName = "Listing Activity", string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") : base(activityName, description)
    {

    }

    // --- Methods ---
    public void Run()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        DateTime currentTime;
        do
        {
            // a thing     
            currentTime = DateTime.Now;
        } while(currentTime < endTime);
        _trueDuration = (currentTime - startTime).Seconds;
    }
    public List<string> GetUserList()
    {
        return _userResponse;
    }
    public void SaveToLog()
    {
        // add _usedQuestions and _userResponse to PromptedActivity.SaveToLog() method
    }    
}