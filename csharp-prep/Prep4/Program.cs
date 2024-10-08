using System;
using System.Collections.Generic;
List<int> numbers = new List<int>();
int input;

Console.WriteLine("Enter a list of numbers, type 0 when finished.");


do
{
    Console.Write("Enter number: ");
    input = int.Parse(Console.ReadLine());

    if (input != 0)
    {
        numbers.Add(input);
    }

} while (input != 0);


int sum = 0;
foreach (int number in numbers)
{
    sum += number;
}


double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;


int maxNumber = numbers.Count > 0 ? numbers[0] : 0;
foreach (int number in numbers)
{
    if (number > maxNumber)
    {
        maxNumber = number;
    }
}


Console.WriteLine($"The sum is: {sum}");
Console.WriteLine($"The average is: {average}");
Console.WriteLine($"The largest number is: {maxNumber}");


int? smallestPositive = null;

foreach (int number in numbers)
{
    if (number > 0 && (smallestPositive == null || number < smallestPositive))
    {
        smallestPositive = number;
    }
}

if (smallestPositive.HasValue)
{
    Console.WriteLine($"The smallest positive number is: {smallestPositive.Value}");
}


numbers.Sort();
Console.WriteLine("The sorted list is:");
foreach (int number in numbers)
{
    Console.WriteLine(number);
}

