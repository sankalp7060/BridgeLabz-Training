using System;
using System.Collections.Generic;

class SetToSortedList
{
    static void Main()
    {
        HashSet<int> set = new HashSet<int>() { 5, 3, 9, 1 };

        List<int> list = new List<int>(set);
        list.Sort();

        foreach (int x in list)
            Console.Write(x + " ");
    }
}
