using System;

class PromptedActivity : Activity
{
    // --- Attributes ---
    protected List<string> _prompts = new List<string>();
    protected string _promptText;

    // --- Constructors ---
    public PromptedActivity(string activityName, string description) : base(activityName, description)
    {

    }

    // --- Methods ---
    protected void DisplayRandomPrompt(List<string> prompts)
    {
        // uses default parameter value to allow for additional prompt lists to be used when needed, while not requiring arguments when unnecessary.
    }
    
    protected void SaveToLog()
    {
        // add _promptText to original Activity.SaveToLog() method, look up override
    }
}