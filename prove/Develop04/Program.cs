using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("~*~ Mindfulness Activities~*~");
        List<string> menuOptions = new List<string>{"a", "b", "c"};
        Menu menu = new Menu(menuOptions);
        menu.DisplayMenu();
        Console.WriteLine();
    }
}