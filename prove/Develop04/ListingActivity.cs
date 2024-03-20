using System;

class ListingActivity : PromptedActivity
{
    // --- Attributes ---
    private List<string> _userResponse;

    // --- Constructors ---
    public ListingActivity(string activityName = "Listing Activity", string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") : base(activityName, description)
    {

    }

    // --- Methods ---
    public void List()
    {
        
    }
    public void SaveToLog()
    {
        // add _usedQuestions and _userResponse to PromptedActivity.SaveToLog() method
    }    
}