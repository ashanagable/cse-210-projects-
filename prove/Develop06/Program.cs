using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    enum GoalType
    {
        Simple,
        Eternal,
        Checklist
    }

    class Goal
    {
        public string Name { get; set; }
        public GoalType Type { get; set; }
        public int Points { get; set; }
        public int CompletedCount { get; set; } = 0;
        public int RequiredCount { get; set; } = 0;
        public bool IsCompleted { get; set; } = false;

        public override string ToString()
        {
            return Type switch
            {
                GoalType.Simple => $"{Name} [{(IsCompleted ? "X" : " ")}]",
                GoalType.Eternal => $"{Name} (Completed {CompletedCount} times)",
                GoalType.Checklist => $"{Name} (Completed {CompletedCount}/{RequiredCount} times)",
                _ => Name,
            };
        }
    }

    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int totalScore = 0;

        static void Main(string[] args)
        {
            LoadGoals();
            Menu();
            SaveGoals();
        }

        static void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("\nEternal Quest Menu:");
                Console.WriteLine("1. Add Simple Goal");
                Console.WriteLine("2. Add Eternal Goal");
                Console.WriteLine("3. Add Checklist Goal");
                Console.WriteLine("4. Record Goal Event");
                Console.WriteLine("5. Show Goals");
                Console.WriteLine("6. Show Total Score");
                Console.WriteLine("7. Quit");
                Console.Write("Select an option: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddSimpleGoal(); break;
                    case 2: AddEternalGoal(); break;
                    case 3: AddChecklistGoal(); break;
                    case 4: RecordGoalEvent(); break;
                    case 5: ShowGoals(); break;
                    case 6: ShowTotalScore(); break;
                    case 7: break;
                    default: Console.WriteLine("Invalid choice, please try again."); break;
                }
            } while (choice != 7);
        }

        static void AddSimpleGoal()
        {
            Goal newGoal = new Goal { Type = GoalType.Simple };
            Console.Write("Enter the name of the simple goal: ");
            newGoal.Name = Console.ReadLine();
            Console.Write("Enter the points for this goal: ");
            newGoal.Points = int.Parse(Console.ReadLine());
            goals.Add(newGoal);
        }

        static void AddEternalGoal()
        {
            Goal newGoal = new Goal { Type = GoalType.Eternal };
            Console.Write("Enter the name of the eternal goal: ");
            newGoal.Name = Console.ReadLine();
            Console.Write("Enter the points for each recording: ");
            newGoal.Points = int.Parse(Console.ReadLine());
            goals.Add(newGoal);
        }

        static void AddChecklistGoal()
        {
            Goal newGoal = new Goal { Type = GoalType.Checklist };
            Console.Write("Enter the name of the checklist goal: ");
            newGoal.Name = Console.ReadLine();
            Console.Write("Enter the points for each recording: ");
            newGoal.Points = int.Parse(Console.ReadLine());
            Console.Write("Enter the required number of completions: ");
            newGoal.RequiredCount = int.Parse(Console.ReadLine());
            goals.Add(newGoal);
        }

        static void RecordGoalEvent()
        {
            ShowGoals();
            Console.Write("Enter the number of the goal you want to record: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < goals.Count)
            {
                Goal goal = goals[index];
                switch (goal.Type)
                {
                    case GoalType.Simple:
                        if (!goal.IsCompleted)
                        {
                            goal.IsCompleted = true;
                            totalScore += goal.Points;
                            Console.WriteLine($"Goal '{goal.Name}' completed! You earned {goal.Points} points.");
                        }
                        else
                        {
                            Console.WriteLine($"Goal '{goal.Name}' is already completed.");
                        }
                        break;

                    case GoalType.Eternal:
                        goal.CompletedCount++;
                        totalScore += goal.Points;
                        Console.WriteLine($"Goal '{goal.Name}' recorded! You earned {goal.Points} points.");
                        break;

                    case GoalType.Checklist:
                        if (goal.CompletedCount < goal.RequiredCount)
                        {
                            goal.CompletedCount++;
                            totalScore += goal.Points;
                            Console.WriteLine($"Goal '{goal.Name}' recorded! You earned {goal.Points} points.");
                            if (goal.CompletedCount == goal.RequiredCount)
                            {
                                totalScore += 500; // Bonus for completion
                                Console.WriteLine($"Congratulations! You've completed the goal '{goal.Name}' and earned an additional 500 points.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Goal '{goal.Name}' is already completed.");
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }

        static void ShowGoals()
        {
            Console.WriteLine("Your Goals:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i]}");
            }
        }

        static void ShowTotalScore()
        {
            Console.WriteLine($"Total Score: {totalScore}");
        }

        static void SaveGoals()
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine(goals.Count);
                foreach (var goal in goals)
                {
                    writer.WriteLine($"{goal.Type},{goal.Name},{goal.Points},{goal.CompletedCount},{goal.RequiredCount},{goal.IsCompleted}");
                }
            }
        }

        static void LoadGoals()
        {
            if (!File.Exists("goals.txt")) return;

            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                int goalCount = int.Parse(reader.ReadLine());
                for (int i = 0; i < goalCount; i++)
                {
                    string[] parts = reader.ReadLine().Split(',');
                    GoalType type = (GoalType)Enum.Parse(typeof(GoalType), parts[0]);
                    Goal goal = new Goal
                    {
                        Type = type,
                        Name = parts[1],
                        Points = int.Parse(parts[2]),
                        CompletedCount = int.Parse(parts[3]),
                        RequiredCount = int.Parse(parts[4]),
                        IsCompleted = bool.Parse(parts[5])
                    };
                    goals.Add(goal);
                }
            }
        }
    }
}
