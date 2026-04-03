using System;
using System.Collections.Generic;

class CircularTour
{
    static int FindStartingPump(int[] petrol, int[] distance)
    {
        int n = petrol.Length;
        Queue<int> queue = new Queue<int>();
        int petrolSurplus = 0;

        for (int i = 0; i < n; i++)
        {
            queue.Enqueue(i);
            petrolSurplus += petrol[i] - distance[i];

            while (petrolSurplus < 0 && queue.Count > 0)
            {
                int removed = queue.Dequeue();
                petrolSurplus -= (petrol[removed] - distance[removed]);
            }
        }

        if (queue.Count == n)
            return queue.Peek();
        else
            return -1;
    }

    static void Main()
    {
        int[] petrol = { 6, 3, 7 };
        int[] distance = { 4, 6, 3 };

        int startPump = FindStartingPump(petrol, distance);
        if (startPump != -1)
            Console.WriteLine("Start at pump: " + startPump);
        else
            Console.WriteLine("No solution exists");
    }
}
