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
    protected string GetRandomPrompt(List<string> prompts = null)
    {
        if (prompts == null)
        {
            prompts = _prompts;
        }
        Random randomGenerator = new Random();
        int promptNum = randomGenerator.Next(0, prompts.Count);
        _promptText = prompts[promptNum];
        return _promptText;
    }
    
    protected void SaveToLog()
    {
        // add _promptText to original Activity.SaveToLog() method, look up override
    }
}