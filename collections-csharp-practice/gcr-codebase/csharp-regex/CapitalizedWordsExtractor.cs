using System;
using System.Text.RegularExpressions;

class CapitalizedWordsExtractor
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        // Regex for capitalized words
        string pattern = @"\b[A-Z][a-z]*\b";

        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Capitalized words:");
        foreach (Match m in matches)
        {
            Console.WriteLine(m.Value);
        }
    }
}
