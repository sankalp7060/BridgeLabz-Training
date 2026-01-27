using System;
using System.Text.RegularExpressions;

class ValideUserName
{
    static void Main()
    {
        Console.Write("Enter a username: ");
        string username = Console.ReadLine();

        // Regex: Start with a letter, followed by letters, numbers, or _, length 5-15
        string pattern = @"^[a-zA-Z][a-zA-Z0-9_]{4,14}$";

        if (Regex.IsMatch(username, pattern))
        {
            Console.WriteLine($"{username} → Valid");
        }
        else
        {
            Console.WriteLine($"{username} → Invalid");
        }
    }
}
