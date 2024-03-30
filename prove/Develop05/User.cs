using System;

public class User
{
    // --- Attributes ---
    private string _username;
    private int _score;
    private int _totalScore;
    private int _level;
    private int _rankIndex;
    private List<string> _rankList = new List<string>{"Buzzy Bee", "Honey Bee", "Bumble Bee", "Queen Bee"};
    private int _levelUpThreshold = 5;
    private int _rankUpThreshold = 2;

    // --- Constructors ---
    public User()
    {
        _score = 0;
        _totalScore = 0;
        _level = 1;
        _rankIndex = 0;
        Console.Write("Username: ");
        _username = Console.ReadLine();
        Console.WriteLine();
    }
    public User(string username, int score, int totalScore, int level, int rank)
    {
        _username = username;
        _score = score;
        _totalScore = totalScore;
        _level = level;
        _rankIndex = rank;
    }

    // --- Methods ---
    public void DisplayUserInfo()
    {
        Console.WriteLine($"{_username}\nLevel {_level} {GetRank()}\nProgress towards next level: {_score}/{_levelUpThreshold} Points\nScore: {_totalScore}");
    }
    private string GetRank()
    {
        return _rankList[_rankIndex];
    }
    public void IncreaseScore(int points)
    {
        _score += points;
        _totalScore += points;
        if (_score >= _levelUpThreshold)
        {
            int extra = _score - _levelUpThreshold;;
            do {
                LevelUp();
                if (extra >= _levelUpThreshold)
                {
                    extra -= _levelUpThreshold;
                }
                _score = extra;
            } while (extra >= _levelUpThreshold);
        }
    }
    public void LevelUp()
    {
        // Exceeds expectations by including a level-up system.
        if (_level < _rankUpThreshold || _rankIndex + 1 == _rankList.Count)
        {
            _level += 1;
        }
        else if (_level == _rankUpThreshold)
        {
            if (_rankIndex + 1 < _rankList.Count)
            {
                _rankIndex += 1;
                _level = 1;
            }
        }
    }

}