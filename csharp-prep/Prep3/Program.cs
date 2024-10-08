using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        bool playAgain;

        do
        {
            
            int magicNumber = random.Next(1, 101);
            int guess = 0;
            int numberOfGuesses = 0;

            Console.WriteLine("Welcome to the Guess My Number game!");
            Console.WriteLine("I've picked a magic number between 1 and 100. Try to guess it!");

            
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                numberOfGuesses++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            
            Console.WriteLine($"It took you {numberOfGuesses} guesses.");

            
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            playAgain = response == "yes";

        } while (playAgain);

        Console.WriteLine("Thank you for playing!!");
    }
}