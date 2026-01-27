using System;
using System.Text.RegularExpressions;

class CreditCardValidator
{
    static void Main()
    {
        Console.Write("Enter credit card number: ");
        string card = Console.ReadLine();

        string visaPattern = @"^4\d{15}$";
        string masterPattern = @"^5\d{15}$";

        if (Regex.IsMatch(card, visaPattern))
            Console.WriteLine($"{card} → Valid Visa Card");
        else if (Regex.IsMatch(card, masterPattern))
            Console.WriteLine($"{card} → Valid MasterCard");
        else
            Console.WriteLine($"{card} → Invalid Card");
    }
}
