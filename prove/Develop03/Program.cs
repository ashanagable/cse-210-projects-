using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
    public string Text { get; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }
}

public class Reference
{
    public string Verse { get; }

    public Reference(string verse)
    {
        Verse = verse;
    }
}

public class Scripture
{
    public Reference Reference { get; }
    private List<Word> Words { get; }

    public Scripture(string reference, string text)
    {
        Reference = new Reference(reference);
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        int hidden = 0;
        while (hidden < count)
        {
            int index = rand.Next(Words.Count);
            if (!Words[index].IsHidden)
            {
                Words[index].IsHidden = true;
                hidden++;
            }
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(Reference.Verse);
        foreach (var word in Words)
        {
            if (word.IsHidden)
                Console.Write("_____ ");
            else
                Console.Write(word.Text + " ");
        }
        Console.WriteLine();
    }

    public bool AllWordsHidden()
    {
        return Words.All(word => word.IsHidden);
    }

    // Method to get the count of total words
    public int TotalWords => Words.Count;

    // Method to get the count of hidden words
    public int HiddenWordCount => Words.Count(word => word.IsHidden);
}

public class Program
{
    public static void Main(string[] args)
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        
        while (true)
        {
            scripture.Display();
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            if (!scripture.AllWordsHidden())
            {
                int wordsToHide = Math.Min(3, scripture.TotalWords - scripture.HiddenWordCount);
                scripture.HideRandomWords(wordsToHide);
            }

            if (scripture.AllWordsHidden())
                break;
        }
    }
}
