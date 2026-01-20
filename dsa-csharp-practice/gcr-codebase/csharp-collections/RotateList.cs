using System;
using System.Collections.Generic;

class RotateList
{
    static void Main()
    {
        List<int> list = new List<int>() { 10, 20, 30, 40, 50 };
        int k = 2;

        k = k % list.Count;

        for (int i = 0; i < k; i++)
        {
            int first = list[0];
            list.RemoveAt(0);
            list.Add(first);
        }

        foreach (int x in list)
            Console.Write(x + " ");
    }
}
