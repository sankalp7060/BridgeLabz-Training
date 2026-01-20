using System;
using System.Collections.Generic;

class InvertMap
{
    static void Main()
    {
        Dictionary<string, int> map = new Dictionary<string, int>()
        {
            { "A", 1 },
            { "B", 2 },
            { "C", 1 },
        };

        Dictionary<int, List<string>> inverted = new Dictionary<int, List<string>>();

        foreach (var item in map)
        {
            if (!inverted.ContainsKey(item.Value))
                inverted[item.Value] = new List<string>();

            inverted[item.Value].Add(item.Key);
        }

        foreach (var entry in inverted)
        {
            Console.Write(entry.Key + " -> ");
            foreach (var v in entry.Value)
                Console.Write(v + " ");
            Console.WriteLine();
        }
    }
}
