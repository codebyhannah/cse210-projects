using System;

class Reference
{
    // --- Attributes ---
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // --- Constructors ---
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = 0;
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
    
    // --- Methods ---
    public void DisplayReference()
    {
        if (_endVerse == 0)
        {
            Console.WriteLine($"{_book} {_chapter}:{_startVerse}");
        }
        else
        {
            Console.WriteLine($"{_book} {_chapter}:{_startVerse}-{_endVerse}");
        }
    }
}