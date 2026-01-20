using System;
using System.Collections;
using System.Collections.Generic;

class ReverseList
{
    static void Main()
    {
        ArrayList arr = new ArrayList() { 1, 2, 3, 4, 5 };

        int i = 0,
            j = arr.Count - 1;
        while (i < j)
        {
            object temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            i++;
            j--;
        }

        Console.WriteLine("Reversed ArrayList:");
        foreach (var x in arr)
            Console.Write(x + " ");

        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(4);
        list.AddLast(5);

        Stack<int> stack = new Stack<int>();
        foreach (var x in list)
            stack.Push(x);

        list.Clear();

        while (stack.Count > 0)
            list.AddLast(stack.Pop());

        Console.WriteLine("\nReversed LinkedList:");
        foreach (var x in list)
            Console.Write(x + " ");
    }
}
