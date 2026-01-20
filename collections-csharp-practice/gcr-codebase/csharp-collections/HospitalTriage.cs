using System;
using System.Collections.Generic;

class HospitalTriage
{
    static void Main()
    {
        PriorityQueue<string, int> pq = new PriorityQueue<string, int>();

        pq.Enqueue("John", -3);
        pq.Enqueue("Alice", -5);
        pq.Enqueue("Bob", -2);

        while (pq.Count > 0)
            Console.WriteLine(pq.Dequeue());
    }
}
