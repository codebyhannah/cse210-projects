using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        Console.WriteLine();
        int num;
        List<int> numList = new List<int>();
        do
        {
            Console.Write("Enter number: ");
            string numString = Console.ReadLine();
            while (!int.TryParse(numString, out int n))
            {
                Console.Write("Please enter integers only: ");
                numString = Console.ReadLine();
            }
            num = int.Parse(numString);
            if (num != 0)
            {
                numList.Add(num);
            }
        } while (num != 0);
        Console.WriteLine();
        int sum = 0;
        int largest = -999999999;
        int smallest = 999999999;
        foreach (int number in numList)
        {
            sum += number;
            if (number > largest)
            {
                largest = number;
            }
            if (number > 0 && number < smallest)
            {
                smallest = number;
            }
        }
        float average = ((float)sum) / numList.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallest}");
        Console.WriteLine("The sorted list is: ");
        numList.Sort();
        foreach (int number in numList)
        {
            Console.WriteLine(number);
        }
    }
}