using System;
using System.Runtime.Versioning;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();
        Console.Write("What is your last name? ");
        string last = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine($"Your name is {last}, {first} {last}.");
    }
}