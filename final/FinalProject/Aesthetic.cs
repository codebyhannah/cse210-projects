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
    public void CenteredLineOfCharacters(string textToRepeat, int len)
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
    public void DisplayPauseAnimation(string spinnerType, int timeLength, int includeZero = -1)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(timeLength);
        DateTime currentTime;
        int len;
        if(spinnerType == "spin")
        {
            int i = 1;
            do
            {         
                len = 250;
                if (i == 1)
                {
                    Console.Write("|   ");
                    Thread.Sleep(len);
                    Console.Write("\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 2)
                {
                    Console.Write("/   ");
                    Thread.Sleep(len);
                    Console.Write("\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 3)
                {
                    Console.Write("--  ");
                    Thread.Sleep(len);
                    Console.Write("\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 4)
                {
                    Console.Write(@"\   ");
                    Thread.Sleep(len);
                    Console.Write("\b \b\b \b\b \b\b \b");
                    i = 1;
                }
                currentTime = DateTime.Now;
            } while(currentTime < endTime);
        }
        else if (spinnerType == "dots")
        { 
            len = 500;
            int i = 1;
            do
            {            
                if (i == 1)
                {
                    Console.Write(".     ");
                    Thread.Sleep(len);
                    Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 2)
                {
                    Console.Write("..    ");
                    Thread.Sleep(len);
                    Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 3)
                {
                    Console.Write("...   ");
                    Thread.Sleep(len);
                    Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b");
                    i++;
                }
                else if (i == 4)
                {
                    Console.Write("      ");
                    Thread.Sleep(len);
                    Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b");
                    i = 1;
                }
                currentTime = DateTime.Now;
            } while(currentTime < endTime);
        }
        else if (spinnerType == "countdown")
        { 
            len = 1000;
            int i = timeLength;
            do
            {            
                Console.Write($"{i}   ");
                Thread.Sleep(len);
                // Remove tab
                Console.Write("\b \b\b \b\b \b");
                // Remove number (any length of characters)
                for (int k = i.ToString().Length; k > 0; k--)
                {
                    Console.Write("\b \b");
                }
                i--;
                currentTime = DateTime.Now;
            } while(currentTime < endTime);
            if (includeZero == 0)
            {
                Console.Write($"0   ");
                Thread.Sleep(len);
                Console.Write("\b \b\b \b\b \b\b \b");
            }   
        }
    }

}