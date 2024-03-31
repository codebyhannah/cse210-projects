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
        _current = 0;
    }
    public ChecklistGoal(string title, string description, int points, bool complete, int target, int bonus, int current) : base (title, description, points, complete)
    {
        _target = target;
        _bonus = bonus;
        _current = current;
    }

    // --- Methods ---
    public override string DisplayGoal()
    {
        string checkbox = $"[{_current}/{_target}]";
        return $"{checkbox} {_title} :\n\t{_description}\n\tPoints: {_points}\n\tBonus Points upon Full Completion: {_bonus}";
    }
    public override int UpdateGoal()
    {
        _current++;
        if (_current == _target)
        {
            _complete = true;
            return _bonus;
        }
        else
        {
            return _points;
        }
    }
    public override List<string> GetGoalInfoList()
    {
        List<string> goalInfo = new List<string>{"<~CHECKLISTGOAL~>",$"{_title}",$"{_description}",$"{_points}",$"{_complete}",$"{_current}",$"{_target}",$"{_bonus}"};
        return goalInfo;
    }

}