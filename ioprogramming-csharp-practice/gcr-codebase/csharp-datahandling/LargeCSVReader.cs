using System;
using System.IO;

class LargeCSVReader
{
    static void Main()
    {
        using StreamReader reader = new("employees.csv");

        int count = 0;
        string line;

        while ((line = reader.ReadLine()) != null)
        {
            count++;

            if (count % 100 == 0)
                Console.WriteLine("Processed: " + count);
        }
    }
}
