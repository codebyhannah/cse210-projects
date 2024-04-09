using System;

class Program
{
    static void Main(string[] args)
    {
        // This console clearing thing is required to fix that one issue where C# doesn't always like to clear the entire console. 
        Console.Clear(); Console.WriteLine("\x1b[3J"); Console.Clear();
        GameManager games = new GameManager();
        games.Start();
    }
}