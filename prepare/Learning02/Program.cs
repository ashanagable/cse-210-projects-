using System;

class Program
{
    static void Main(string[] args)
    {
        // Create job instances
        job job1 = new job("Software Engineer", "Microsoft", 2019, 2022);
        job job2 = new job("Manager", "Apple", 2022, 2023);

        // Create a resume instance
        resume myresume = new resume("Allison Rose");
        
        // Add jobs to the resume
        myresume.AddJob(job1);
        myresume.AddJob(job2);

        // Display the resume
        myresume.Display();
    }
}