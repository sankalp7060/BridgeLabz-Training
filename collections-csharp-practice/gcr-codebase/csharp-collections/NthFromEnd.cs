using System;
using System.Collections.Generic;

class NthFromEnd
{
    static void Main()
    {
        LinkedList<string> list = new LinkedList<string>();
        list.AddLast("A");
        list.AddLast("B");
        list.AddLast("C");
        list.AddLast("D");
        list.AddLast("E");

        int n = 2;

        var fast = list.First;
        var slow = list.First;

        for (int i = 0; i < n; i++)
            fast = fast.Next;

        while (fast != null)
        {
            slow = slow.Next;
            fast = fast.Next;
        }

        Console.WriteLine("Nth from end: " + slow.Value);
    }
}
