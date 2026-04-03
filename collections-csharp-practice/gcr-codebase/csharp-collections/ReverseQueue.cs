using System;
using System.Collections.Generic;

class ReverseQueue
{
    static void Main()
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(10);
        q.Enqueue(20);
        q.Enqueue(30);

        Stack<int> stack = new Stack<int>();

        while (q.Count > 0)
            stack.Push(q.Dequeue());

        while (stack.Count > 0)
            q.Enqueue(stack.Pop());

        foreach (int x in q)
            Console.Write(x + " ");
    }
}
