using System;

class Program
{
    static void Main(string[] args)
    {
        string again;
        do
        {
            Console.Clear();
            Random randomGenerator = new Random();
            int magicNum = randomGenerator.Next(1, 100);
            int guess;
            int numGuesses = 0;
            do
            {
                Console.Write("What is your guess? ");
                string guessString = Console.ReadLine();
                while (!int.TryParse(guessString, out int n))
                {
                    Console.WriteLine("Please enter integers only.");
                    Console.WriteLine();
                    Console.Write("What is your guess? ");
                    guessString = Console.ReadLine();
                }
                guess = int.Parse(guessString);
                if (guess > magicNum)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNum)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
                Console.WriteLine();
                numGuesses++;
            } while (guess != magicNum);

            Console.WriteLine($"It took you {numGuesses} guesses to figure it out.");
            Console.WriteLine();
            do
            {
                Console.Write("Do you want to play again? ");
                again = Console.ReadLine().ToLower();
                if (again != "yes" && again != "no")
                {
                    Console.WriteLine("Please enter either 'yes' or 'no'.");
                    Console.WriteLine();
                }
            } while (again != "yes" && again != "no");
            
        } while (again == "yes");
        Console.WriteLine();
    }
}