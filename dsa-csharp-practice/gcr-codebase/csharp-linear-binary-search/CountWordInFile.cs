using System;
using System.IO;

class CountWordInFile
{
    static void Main()
    {
        string word = "revenue";
        int count = 0;

        using (StreamReader sr = new StreamReader("test.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] words = line.Split(
                    new char[] { ' ', '.', ',', ':', '-' },
                    StringSplitOptions.RemoveEmptyEntries
                );

                foreach (string i in words)
                {
                    if (i.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        count++;
                    }
                }
            }
        }

        Console.WriteLine(count);
    }
}
