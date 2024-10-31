using System;
using System.Data;

namespace prove2{
public class Entry
{
    public string Prompt { get; }
    public string Response { get; }
    public string Date { get; }


    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Date} | {Prompt} | {Response}";
    }
}
}
