using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; private set; }
    public string Text { get; private set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public override string ToString()
    {
        return $"{CommenterName}: {Text}";
    }
}

public class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int LengthInSeconds { get; private set; }
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }

    public override string ToString()
    {
        return $"Title: {Title}\nAuthor: {Author}\nLength: {LengthInSeconds} seconds\nNumber of Comments: {GetCommentCount()}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("How to Make Pancakes", "Chef John", 300);
        Video video2 = new Video("Top 10 Python Tips", "Programming with Mosh", 600);
        Video video3 = new Video("Travel Vlog: Exploring Japan", "TravelBuddy", 1200);
        Video video4 = new Video("Understanding Machine Learning", "Data Scientist", 900);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Great recipe! Can't wait to try it."));
        video1.AddComment(new Comment("Bob", "I love pancakes!"));
        video1.AddComment(new Comment("Charlie", "This looks delicious!"));

        // Add comments to video2
        video2.AddComment(new Comment("David", "Thanks for the tips!"));
        video2.AddComment(new Comment("Eva", "Very helpful, learned a lot."));
        video2.AddComment(new Comment("Frank", "I wish I knew this earlier."));

        // Add comments to video3
        video3.AddComment(new Comment("Grace", "Japan looks amazing!"));
        video3.AddComment(new Comment("Hannah", "I want to go there!"));
        video3.AddComment(new Comment("Ian", "The food looks delicious!"));

        // Add comments to video4
        video4.AddComment(new Comment("Jack", "This is very insightful."));
        video4.AddComment(new Comment("Karen", "I never understood this until now."));
        video4.AddComment(new Comment("Leo", "Great breakdown of the topic!"));

        // List of videos
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display all video details
        foreach (var video in videos)
        {
            Console.WriteLine(video);
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine(comment);
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
 