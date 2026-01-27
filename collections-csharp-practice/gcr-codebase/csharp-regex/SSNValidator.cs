using System;
using System.Text.RegularExpressions;

class SSNValidator
{
    static void Main()
    {
        Console.Write("Enter SSN: ");
        string ssn = Console.ReadLine();

        string pattern = @"^\d{3}-\d{2}-\d{4}$";

        if (Regex.IsMatch(ssn, pattern))
            Console.WriteLine($"{ssn} → Valid SSN");
        else
            Console.WriteLine($"{ssn} → Invalid SSN");
    }
}
