using System;
using System.Collections.Generic;

// Base class for activities
abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public DateTime Date => _date;
    public int LengthInMinutes => _lengthInMinutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    
    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetType().Name} ({LengthInMinutes} min) - " +
               $"Distance: {GetDistance():F2}, Speed: {GetSpeed():F2}, Pace: {GetPace():F2}";
    }
}

// Derived class for Running
class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int lengthInMinutes, double distance) 
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (GetDistance() / LengthInMinutes) * 60; // mph

    public override double GetPace() => LengthInMinutes / GetDistance(); // min per mile
}

// Derived class for Cycling
class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int lengthInMinutes, double speed) 
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (GetSpeed() * LengthInMinutes) / 60; // miles

    public override double GetSpeed() => _speed; // mph

    public override double GetPace() => 60 / GetSpeed(); // min per mile
}

// Derived class for Swimming
class Swimming : Activity
{
    private int _laps; // number of laps

    public Swimming(DateTime date, int lengthInMinutes, int laps) 
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => (_laps * 50 / 1000.0) * 0.62; // miles

    public override double GetSpeed() => (GetDistance() / LengthInMinutes) * 60; // mph

    public override double GetPace() => LengthInMinutes / GetDistance(); // min per mile
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0), // Running for 30 min, 3 miles
            new Cycling(new DateTime(2022, 11, 4), 45, 15.0), // Cycling for 45 min, 15 mph
            new Swimming(new DateTime(2022, 11, 5), 30, 20)   // Swimming for 30 min, 20 laps
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
