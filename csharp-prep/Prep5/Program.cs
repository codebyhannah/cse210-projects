using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        DisplayWelcome();
        Console.WriteLine();
        DisplayResult(PromptUserName(),SquareNumber(PromptUserNumber()));
        Console.WriteLine();
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        int favNum;
        Console.Write("Please enter your favorite number: ");
        string numString = Console.ReadLine();
        while (!int.TryParse(numString, out int n))
        {
            Console.Write("Integers only. Please enter your favorite number: ");
            numString = Console.ReadLine();
        }
        favNum = int.Parse(numString);
        return favNum;
    }
    static int SquareNumber(int num)
    {
        return num * num;
    }
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine();
        Console.WriteLine($"{name}, the square of your number is {square}.");
    }
}