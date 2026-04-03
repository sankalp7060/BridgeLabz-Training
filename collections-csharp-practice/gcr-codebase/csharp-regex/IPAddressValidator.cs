using System;
using System.Text.RegularExpressions;

class IPAddressValidator
{
    static void Main()
    {
        Console.Write("Enter IP address: ");
        string ip = Console.ReadLine();

        // Regex for IPv4
        string pattern =
            @"^((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)\.){3}(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)$";

        if (Regex.IsMatch(ip, pattern))
            Console.WriteLine($"{ip} → Valid");
        else
            Console.WriteLine($"{ip} → Invalid");
    }
}
