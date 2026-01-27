using System;
using System.Text.RegularExpressions;

class BadWordCensor
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        // List of bad words
        string[] badWords = { "damn", "stupid", "idiot" };

        foreach (string word in badWords)
        {
            text = Regex.Replace(text, $@"\b{word}\b", "****", RegexOptions.IgnoreCase);
        }

        Console.WriteLine("Censored text:");
        Console.WriteLine(text);
    }
}
