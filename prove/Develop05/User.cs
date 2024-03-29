using System;

public class User
{
    // --- Attributes ---
    private string _username;
    private int _score;
    private int _level;
    private string _rank;
    private List<string> _rankList;
    private int _levelUpThreshold;
    private int _rankUpThreshold;

    // --- Constructors ---
    public User()
    {
        _score = 0;
    }
    public User(string username)
    {
        _username = username;
    }

    // --- Methods ---
    public void DisplayUserInfo()
    {

    }
    public void IncreaseScore(int points)
    {
        _score += points;
    }
    public void LevelUp()
    {

    }

}