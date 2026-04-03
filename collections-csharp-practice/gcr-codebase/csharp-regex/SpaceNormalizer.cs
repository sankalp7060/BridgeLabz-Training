using System;
using System.Text.RegularExpressions;

class SpaceNormalizer
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        // Replace multiple spaces with one
        string result = Regex.Replace(text, @"\s+", " ");

        Console.WriteLine("Normalized text:");
        Console.WriteLine(result);
    }
}
