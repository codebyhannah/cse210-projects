using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Scripture scripture = new Scripture("test.txt");
        scripture.DisplayScripture(0);
    }
}