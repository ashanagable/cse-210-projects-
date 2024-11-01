using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    // Base class for mindfulness activities
    abstract class MindfulnessActivity
    {
        public string Name { get; }
        public string Description { get; }
        protected int Duration { get; private set; }

        public MindfulnessActivity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"Starting {Name} Activity...");
            Console.WriteLine(Description);
            Console.Write("Enter the duration of the activity in seconds: ");
            Duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Prepare to begin...");
            Pause(3); // Pause for 3 seconds
            PerformActivity();
            FinishActivity();
        }

        protected abstract void PerformActivity();

        protected void FinishActivity()
        {
            Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
            Console.WriteLine("Good job!");
            Pause(3); // Pause for 3 seconds
        }

        protected void Pause(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.WriteLine($"{i}...",  "\r");
                Thread.Sleep(1000);
            }
            Console.WriteLine(new string(' ', 10)); // Clear the line
        }
    }

    // Breathing activity class
    class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

        protected override void PerformActivity()
        {
            int endTime = Environment.TickCount + Duration * 1000;
            while (Environment.TickCount < endTime)
            {
                Console.WriteLine("Breathe in...");
                Pause(4);
                Console.WriteLine("Breathe out...");
                Pause(4);
            }
        }
    }

    // Reflection activity class
    class ReflectionActivity : MindfulnessActivity
    {
        private static readonly List<string> Prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private static readonly List<string> Questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.") { }

        protected override void PerformActivity()
        {
            Random rand = new Random();
            string prompt = Prompts[rand.Next(Prompts.Count)];
            Console.WriteLine(prompt);
            Pause(5); // Pause to think about the prompt

            int endTime = Environment.TickCount + Duration * 1000;
            while (Environment.TickCount < endTime)
            {
                string question = Questions[rand.Next(Questions.Count)];
                Console.WriteLine(question);
                Pause(6); // Pause for reflection time
            }
        }
    }

    // Listing activity class
    class ListingActivity : MindfulnessActivity
    {
        private static readonly List<string> Prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

        protected override void PerformActivity()
        {
            Random rand = new Random();
            string prompt = Prompts[rand.Next(Prompts.Count)];
            Console.WriteLine(prompt);
            Pause(5); // Pause to think about the prompt

            List<string> items = new List<string>();
            int endTime = Environment.TickCount + Duration * 1000;
            Console.WriteLine("Start listing your items (type 'done' to finish):");

            while (Environment.TickCount < endTime)
            {
                string item = Console.ReadLine();
                if (item.ToLower() == "done") break;
                items.Add(item);
            }
            Console.WriteLine($"You listed {items.Count} items.");
        }
    }

    // Main program class
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1: Breathing");
                Console.WriteLine("2: Reflection");
                Console.WriteLine("3: Listing");
                Console.WriteLine("4: Quit");
                Console.Write("Enter the number of your choice: ");
                string choice = Console.ReadLine();

                MindfulnessActivity activity;
                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        continue;
                }

                activity.Start();
            }
        }
    }
}
