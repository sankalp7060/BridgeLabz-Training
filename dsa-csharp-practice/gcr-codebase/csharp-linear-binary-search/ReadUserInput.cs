using System;
using System.IO;

class ReadUserInput
{
    static void Main()
    {
        using StreamWriter sw = new StreamWriter("output.txt");
        Console.WriteLine("Enter text (type END to stop):");

        string input;
        while ((input = Console.ReadLine()) != "END")
            sw.WriteLine(input);
    }
}
