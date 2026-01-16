using System;
using System.Collections.Generic;

// Queue class implemented using single stack
public class CarQueue
{
    private Stack<Car> stack = new Stack<Car>(); // Stack to implement queue
    private int capacity = 20; // Maximum capacity of queue

    // Enqueue car into queue
    public void Enqueue(Car car)
    {
        if (stack.Count == capacity) // Check for overflow
        {
            Console.WriteLine("Queue Overflow");
            return;
        }
        stack.Push(car); // Push car into stack
        Console.WriteLine("Car Added To Waiting Queue");
    }

    // Dequeue car from queue
    public Car Dequeue()
    {
        if (stack.Count == 0) // Check for underflow
        {
            Console.WriteLine("Queue Underflow ");
            return null;
        }

        Car top = stack.Pop(); // Pop top car
        if (stack.Count == 0) // Base case for recursion
        {
            return top;
        }

        Car result = Dequeue(); // Recursive call
        stack.Push(top); // Restore stack
        return result;
    }

    // Peek at front of queue without removing
    public Car Peek()
    {
        if (stack.Count == 0)
        {
            Console.WriteLine("Queue Underflow ");
            return null;
        }

        Car top = stack.Pop();
        if (stack.Count == 0)
        {
            stack.Push(top);
            return top;
        }

        Car result = Peek(); // Recursive peek
        stack.Push(top);
        return result;
    }

    public int Count => stack.Count; // Number of cars in queue

    public bool Contains(Car car) => stack.Contains(car); // Check if car exists
}
