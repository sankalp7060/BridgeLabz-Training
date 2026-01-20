using System;
using System.Collections.Generic;

class FrequencyCounter
{
    static void Main()
    {
        string[] arr = { "apple", "banana", "apple", "orange" };

        Dictionary<string, int> map = new Dictionary<string, int>();

        foreach (string s in arr)
        {
            if (map.ContainsKey(s))
                map[s]++;
            else
                map[s] = 1;
        }

        foreach (var item in map)
            Console.WriteLine(item.Key + " : " + item.Value);
    }
}
