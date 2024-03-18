using System;

class Assignment
{
    // --- Attributes ---
    private string _studentName = "";
    private string _topic = "";

    // --- Constructors ---
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // --- Getters and Setters ---
    public string GetStudentName()
    {
        return _studentName;
    }
    public string GetTopic()
    {
        return _topic;
    }

    // --- Methods ---
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}