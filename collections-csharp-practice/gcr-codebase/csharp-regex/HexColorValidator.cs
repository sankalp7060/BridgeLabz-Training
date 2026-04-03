using System;
using System.Text.RegularExpressions;

class HexColorValidator
{
    static void Main()
    {
        Console.Write("Enter a hex color code: ");
        string color = Console.ReadLine();

        // Regex: Starts with # followed by 6 hex characters
        string pattern = @"^#[0-9A-Fa-f]{6}$";

        if (Regex.IsMatch(color, pattern))
        {
            Console.WriteLine($"{color} → Valid");
        }
        else
        {
            Console.WriteLine($"{color} → Invalid");
        }
    }
}
