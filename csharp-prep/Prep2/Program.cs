using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("Enter grade percentage: ");
        string userGradeString = Console.ReadLine();
        int userGradeNum = int.Parse(userGradeString);

        string letterGrade;
        string article = "a";

        if (userGradeNum >= 90)
        {
            letterGrade = "A";
            article = "an";
        }
        else if (userGradeNum >= 80)
        {
            letterGrade = "B";
        }
        else if (userGradeNum >= 70)
        {
            letterGrade = "C";
        }
        else if (userGradeNum >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
            article = "an";
        }
        string sign;

        if (letterGrade == "F")
        {
            sign = "";
        }
        else if ((userGradeNum%10) >= 7 && letterGrade != "A")
        {
            sign = "+";
        }
        else if ((userGradeNum%10) < 3 && userGradeNum != 100)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is {article} {letterGrade}{sign}.");

        if (userGradeNum >= 70)
        {
            Console.WriteLine("Congratulations! You pass.");
        }
        else
        {
            Console.WriteLine("You do not pass, better luck next time.");
        }

        Console.WriteLine();
    }
}