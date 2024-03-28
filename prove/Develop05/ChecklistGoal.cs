using System;

public class ChecklistGoal : Goal
{
    // --- Attributes ---
    private int _target;
    private int _current;
    private int _bonus;

    // --- Constructors ---
    public ChecklistGoal(string title, string description, int points, int target, int bonus) : base (title, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    // --- Methods ---
    public override void DisplayGoal()
    {

    }
    public override void updateGoal()
    {
        
    }

}