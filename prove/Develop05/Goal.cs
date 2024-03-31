using System;

public class Goal
{
    // --- Attributes ---
    protected string _title;
    protected string _description;
    protected int _points;
    protected bool _complete;

    // --- Constructors ---
    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _complete = false;
        _points = points;
    }

    public Goal(string title, string description, int points, bool complete)
    {
        _title = title;
        _description = description;
        _complete = complete;
        _points = points;
    }

    // --- Methods ---
    public virtual string DisplayGoal()
    {
        string checkbox;
        if (IsComplete())
        {
            checkbox = "[x]";
        }
        else
        {
            checkbox = "[ ]";
        }
        return $"{checkbox} {_title} :\n\t{_description}\n\tPoints: {_points}";
    }
    public virtual int UpdateGoal()
    {
        _complete = true;
        return _points;
    }
    public bool IsComplete()
    {
        return _complete;
    }
    public virtual List<string> GetGoalInfoList()
    {
        List<string> goalInfo = new List<string>{"<~GOAL~>",$"{_title}",$"{_description}",$"{_points}",$"{_complete}"};
        return goalInfo;
    }

}