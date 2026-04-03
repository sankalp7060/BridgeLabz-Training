using System;

// Circular linked list to manage cars in roundabout
public class RoundAbout
{
    private CarNode tail; // Tail node of circular list

    // Add car to roundabout
    public void AddCar(Car car)
    {
        CarNode node = new CarNode(car);

        if (tail == null) // If list empty
        {
            tail = node;
            tail.Next = tail;
        }
        else
        {
            node.Next = tail.Next; // Insert new node
            tail.Next = node;
            tail = node;
        }
    }

    // Remove car from roundabout (front of circular list)
    public Car RemoveCar()
    {
        if (tail == null)
        {
            Console.WriteLine("No Car");
            return null;
        }

        CarNode head = tail.Next;

        if (head == tail) // Only one car
        {
            tail = null;
        }
        else
        {
            tail.Next = head.Next; // Remove head node
        }

        return head.Data;
    }

    // Display all cars in roundabout
    public void Display()
    {
        if (tail == null)
        {
            Console.WriteLine("Roundabout Empty");
            return;
        }

        CarNode t = tail.Next;
        do
        {
            Console.Write(t.Data + " -> "); // Print car
            t = t.Next;
        } while (t != tail.Next);

        Console.WriteLine("(Circular)");
    }
}
