using System;

class MathAssignment : Assignment
{
    // --- Attributes ---
    private string _textbookSection = "";
    private string _problems = "";

    // --- Constructors ---
    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // --- Methods ---
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}