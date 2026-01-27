using System;
using System.Text.RegularExpressions;

class LicensePlateValidator
{
    static void Main()
    {
        Console.Write("Enter a license plate number: ");
        string plate = Console.ReadLine();

        // Regex: Two uppercase letters followed by 4 digits
        string pattern = @"^[A-Z]{2}\d{4}$";

        if (Regex.IsMatch(plate, pattern))
        {
            Console.WriteLine($"{plate} → Valid");
        }
        else
        {
            Console.WriteLine($"{plate} → Invalid");
        }
    }
}
