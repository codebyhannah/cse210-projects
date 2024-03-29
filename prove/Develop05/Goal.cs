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

}