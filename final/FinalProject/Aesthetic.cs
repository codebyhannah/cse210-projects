using System;

public class Aesthetic
{
    // --- Attributes ---
    private List<string> _doubledCharacters = new List<string>{"🂡","🂢","🂣","🂤","🂥","🂦","🂧","🂨","🂩","🂪","🂫","🂭","🂮","🂱","🂲","🂳","🂴","🂵","🂶","🂷","🂸","🂹","🂺","🂻","🂽","🂾","🃑","🃒","🃓","🃔","🃕","🃖","🃗","🃘","🃙","🃚","🃛","🃝","🃞","🃁","🃂","🃃","🃄","🃅","🃆","🃇","🃈","🃉","🃊","🃋","🃍","🃎","🃟","🂠",}; // A list of string characters I have discovered to be counted as two char characters, including in string length, for some reason.
    // --- Constructors ---
    public Aesthetic()
    {
        // Empty
    }

    // --- Getters and Setters ---

    // --- Methods ---
    public void WriteCenterText(string text, bool newLine = true)
    {
        if (text.Length <= Console.WindowWidth)
        {
            string text2 = text;
            foreach (string character in _doubledCharacters)
            {
                text2 = text2.Replace(character,"@");
            }
            int indent = (Console.WindowWidth - text2.Length) / 2;
            Console.SetCursorPosition(indent,Console.CursorTop);  
        }
        Console.Write(text);
        if (newLine)
        {
            Console.WriteLine();
        }
    }
    public void Center()
    {
        int indent = Console.WindowWidth / 2;
        Console.SetCursorPosition(indent,Console.CursorTop);  
    }
    public void FullWindowTextLine(string textToRepeat)
    {
        for (int i = 0; i < Console.WindowWidth-1; i++)
        {
            Console.Write(textToRepeat);
        }
        Console.WriteLine();
    }
    public void CenteredTextLine(string textToRepeat, int len)
    {
        string textLine = "";
        for (int i = 0; i < len; i++)
        {
            textLine += textToRepeat;
        }
        WriteCenterText(textLine);
    }
    public void Indent(int len)
    {
        int indent = Console.WindowWidth - len;
        Console.SetCursorPosition(indent,Console.CursorTop);
    }
}