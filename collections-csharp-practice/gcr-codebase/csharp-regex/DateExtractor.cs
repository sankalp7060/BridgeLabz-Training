using System;
using System.Text.RegularExpressions;

class DateExtractor
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        // Regex for dd/mm/yyyy
        string pattern = @"\b\d{2}/\d{2}/\d{4}\b";

        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Dates found:");
        foreach (Match m in matches)
        {
            Console.WriteLine(m.Value);
        }
    }
}
