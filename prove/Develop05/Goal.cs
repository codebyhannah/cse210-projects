using System;

public class Goal
{
    // --- Attributes ---
    private string _title;
    private string _description;
    private int _points;
    private bool _complete;

    // --- Constructors ---
    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
    }

    // --- Methods ---
    public virtual void DisplayGoal()
    {

    }
    public virtual void updateGoal()
    {

    }
    public bool isComplete()
    {
        return false; // for now
    }

}