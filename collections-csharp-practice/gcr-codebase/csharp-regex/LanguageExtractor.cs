using System;
using System.Text.RegularExpressions;

class LanguageExtractor
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        // Regex for some common programming languages
        string pattern = @"\b(Java|Python|JavaScript|Go|C#|C\+\+|Ruby|PHP)\b";

        MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

        Console.WriteLine("Languages found:");
        foreach (Match m in matches)
        {
            Console.WriteLine(m.Value);
        }
    }
}
