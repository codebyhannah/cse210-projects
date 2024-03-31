using System;

public class User
{
    // --- Attributes ---
    private string _username;
    private int _progress;
    private int _score;
    private int _level;
    private int _rankIndex;
    private List<string> _rankList = new List<string>{"Buzzy Bee", "Honey Bee", "Bumble Bee", "Queen Bee"};
    private int _levelUpThreshold = 100;
    private int _rankUpThreshold = 5;

    // --- Constructors ---
    public User()
    {
        _progress = 0;
        _score = 0;
        _level = 1;
        _rankIndex = 0;
        Console.Write("Username: ");
        _username = Console.ReadLine();
        Console.WriteLine();
    }
    public User(string username, int progress, int score, int level, int rank)
    {
        _username = username;
        _progress = progress;
        _score = score;
        _level = level;
        _rankIndex = rank;
    }

    // --- Methods ---
    public void DisplayUserInfo()
    {
        Console.WriteLine($"{_username}\nLevel {_level} {GetRank()}\nProgress towards next level: {_progress}/{_levelUpThreshold} Points\nScore: {_score}");
    }
    private string GetRank()
    {
        return _rankList[_rankIndex];
    }
    public List<string> GetUserInfoList()
    {
        List<string> userInfo = new List<string>{"<~USER~>",$"{_username}",$"{_progress}",$"{_score}",$"{_level}",$"{_rankIndex}"};

        return userInfo;
    }
    public void IncreaseScore(int points)
    {
        _progress += points;
        _score += points;
        if (_progress >= _levelUpThreshold)
        {
            int extra = _progress - _levelUpThreshold;;
            do {
                LevelUp();
                if (extra >= _levelUpThreshold)
                {
                    extra -= _levelUpThreshold;
                }
                _progress = extra;
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