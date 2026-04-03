using System;
using System.Text.RegularExpressions;

class EmailExtractor
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        // Regex for email
        string pattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";

        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Emails found:");
        foreach (Match m in matches)
        {
            Console.WriteLine(m.Value);
        }
    }
}
