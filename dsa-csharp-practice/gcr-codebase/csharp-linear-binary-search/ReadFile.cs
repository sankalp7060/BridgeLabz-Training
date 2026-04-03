using System;
using System.IO;

class ReadFile
{
    static void Main()
    {
        using StreamReader sr = new StreamReader("test.txt");
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
}
