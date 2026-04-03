using System;
using System.Collections.Generic;

class SortStackUsingRecursion
{
    static void SortStack(Stack<int> stack)
    {
        if (stack.Count == 0)
            return;

        int temp = stack.Pop();
        SortStack(stack);
        InsertSorted(stack, temp);
    }

    static void InsertSorted(Stack<int> stack, int element)
    {
        if (stack.Count == 0 || stack.Peek() <= element)
        {
            stack.Push(element);
            return;
        }

        int temp = stack.Pop();
        InsertSorted(stack, element);
        stack.Push(temp);
    }

    static void Main()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(30);
        stack.Push(10);
        stack.Push(20);

        SortStack(stack);

        while (stack.Count > 0)
            Console.WriteLine(stack.Pop());
    }
}
