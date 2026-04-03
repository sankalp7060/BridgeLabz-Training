using System;
using System.IO;

class ReadLargeFile
{
    static void Main()
    {
        try
        {
            using (StreamReader sr = new StreamReader("Practice.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.ToLower().Contains("error"))
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
