using System;
using System.Collections.Generic;

class WordFrequency
{
    static void Main()
    {
        string text = "Hello world hello Java";

        string[] words = text.ToLower().Split(' ');

        Dictionary<string, int> map = new Dictionary<string, int>();

        foreach (string w in words)
        {
            if (map.ContainsKey(w))
                map[w]++;
            else
                map[w] = 1;
        }

        foreach (var item in map)
            Console.WriteLine(item.Key + " : " + item.Value);
    }
}
