using System;
using System.Text.RegularExpressions;

class CurrencyExtractor
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        // Regex for $ and decimal numbers
        string pattern = @"\$?\s?\d+(\.\d{1,2})?";

        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Currency values found:");
        foreach (Match m in matches)
        {
            Console.WriteLine(m.Value.Trim());
        }
    }
}
