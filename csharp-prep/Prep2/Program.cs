using System;

class Program
{
    static void Main(string[] args)
    {   
       
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());

        
        string letter = "";

        
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        
        Console.WriteLine($"Your letter grade is: {letter}");

        
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't be discouraged! Keep trying for next time.");
        }

        
        string sign = "";

        if (letter == "A")
        {
           
            sign = gradePercentage == 100 ? "" : (gradePercentage % 10 >= 7 ? "+" : "-");
        }
        else if (letter == "B")
        {
            sign = gradePercentage % 10 >= 7 ? "+" : (gradePercentage % 10 < 3 ? "-" : "");
        }
        else if (letter == "C")
        {
            sign = gradePercentage % 10 >= 7 ? "+" : (gradePercentage % 10 < 3 ? "-" : "");
        }
        else if (letter == "D")
        {
            sign = gradePercentage % 10 >= 7 ? "+" : (gradePercentage % 10 < 3 ? "-" : "");
        }
       
        
        
        Console.WriteLine($"Your final grade is: {letter}{sign}");
    }
}