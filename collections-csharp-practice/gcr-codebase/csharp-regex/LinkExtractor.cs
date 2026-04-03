using System;
using System.Text.RegularExpressions;

class LinkExtractor
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        // Regex for http or https links
        string pattern = @"https?://[^\s]+";

        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Links found:");
        foreach (Match m in matches)
        {
            Console.WriteLine(m.Value);
        }
    }
}
