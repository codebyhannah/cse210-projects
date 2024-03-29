using System;

public class EternalGoal : Goal
{
    // --- Constructors ---
    public EternalGoal(string title, string description, int points) : base (title, description, points)
    {

    }

    // --- Methods ---
    public override string DisplayGoal()
    {
        return $"[N/A] {_title} :\n\t{_description}\n\tPoints: {_points}";
    }
    public override int UpdateGoal()
    {
        return _points;
    }

}