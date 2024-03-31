using System;

public class EternalGoal : Goal
{
    // --- Constructors ---
    public EternalGoal(string title, string description, int points) : base (title, description, points)
    {
        // Taken care of in base
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
    public override List<string> GetGoalInfoList()
    {
        List<string> goalInfo = new List<string>{"<~ETERNALGOAL~>",$"{_title}",$"{_description}",$"{_points}"};
        return goalInfo;
    }

}