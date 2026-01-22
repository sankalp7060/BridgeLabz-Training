using System;
using System.IO;

class UsingStatementDemo
{
    static void Main()
    {
        try
        {
            using (StreamReader reader = new StreamReader("info.txt"))
            {
                string line = reader.ReadLine();
                Console.WriteLine("First Line:");
                Console.WriteLine(line);
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Error reading file");
        }
    }
}
