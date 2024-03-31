using System;

public class SimpleGoal : Goal
{
    // --- Constructors ---
    public SimpleGoal(string title, string description, int points) : base (title, description, points)
    {
        // Taken care of in base
    }
    public SimpleGoal(string title, string description, int points, bool complete) : base (title, description, points, complete)
    {
        // Taken care of in base
    }

    // --- Methods ---
    public override List<string> GetGoalInfoList()
    {
        List<string> goalInfo = new List<string>{"<~SIMPLEGOAL~>",$"{_title}",$"{_description}",$"{_points}",$"{_complete}"};
        return goalInfo;
    }
}