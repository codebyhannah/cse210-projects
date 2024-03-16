using System;

class Word
{
    // --- Attributes ---
    private string _text;
    private bool _hidden;

    // --- Constructors ---
    public Word()
    {
        _text = "";
        _hidden = false;
    }
    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    // --- Getters and Setters ---
    public bool IsHidden()
    {
        return _hidden;
    }

    // --- Methods ---
    public void DisplayWord()
    {
        if(_hidden == true)
        {
            foreach (char c in _text)
            {
                if (Char.IsLetter(c))
                {
                    Console.Write("_");
                }
                else
                {
                    Console.Write(c);
                }
            }
            Console.Write(" ");
        }
        else
        {
            Console.Write(_text);
            Console.Write(" ");
        }
    }
    public void Hide()
    {
        _hidden = true;
    }
    public void Show()
    {
        _hidden = false;
    }
}