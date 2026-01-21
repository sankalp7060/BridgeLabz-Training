using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class CountWords
{
    static void Main()
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        try
        {
            using (StreamReader sr = new StreamReader("Practice.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(' ', ',', '.', '!', '?');

                    foreach (string word in words)
                    {
                        if (string.IsNullOrWhiteSpace(word))
                            continue;

                        string w = word.ToLower();

                        if (wordCount.ContainsKey(w))
                            wordCount[w]++;
                        else
                            wordCount[w] = 1;
                    }
                }
            }

            var top5 = wordCount.OrderByDescending(x => x.Value).Take(5);

            Console.WriteLine("Top 5 Words:");
            foreach (var item in top5)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
