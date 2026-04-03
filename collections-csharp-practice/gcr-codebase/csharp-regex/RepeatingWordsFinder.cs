using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class RepeatingWordsFinder
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        string pattern = @"\b(\w+)\b\s+\1\b";

        MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

        HashSet<string> repeated = new HashSet<string>();

        foreach (Match m in matches)
        {
            repeated.Add(m.Groups[1].Value);
        }

        Console.WriteLine("Repeating words:");
        foreach (string word in repeated)
        {
            Console.WriteLine(word);
        }
    }
}
