using System;

public class ParcelTrackerService : IParcelTracker
{
    private ParcelStage head;

    // Initialize default delivery chain
    public ParcelTrackerService()
    {
        AddStage("Packed");
        AddStage("Shipped");
        AddStage("In Transit");
        AddStage("Delivered");
    }

    // Add stage at end
    public void AddStage(string stage)
    {
        ParcelStage newNode = new ParcelStage(stage);

        if (head == null)
        {
            head = newNode;
            return;
        }

        ParcelStage temp = head;

        while (temp.Next != null)
        {
            temp = temp.Next;
        }

        temp.Next = newNode;
    }

    // Insert custom checkpoint
    public void AddCheckpointAfter(string existingStage, string newStage)
    {
        ParcelStage temp = head;

        while (temp != null)
        {
            if (temp.StageName == existingStage)
            {
                ParcelStage newNode = new ParcelStage(newStage);
                newNode.Next = temp.Next;
                temp.Next = newNode;

                return;
            }
            temp = temp.Next;
        }

        System.Console.WriteLine("Stage not found!");
    }

    // Traverse forward
    public void DisplayTracking()
    {
        if (head == null)
        {
            System.Console.WriteLine("No parcel data found!");
            return;
        }

        ParcelStage temp = head;

        System.Console.WriteLine("\nParcel Tracking Status:\n");

        while (temp != null)
        {
            System.Console.Write(temp.StageName);

            if (temp.Next != null)
                System.Console.Write("  →  ");

            temp = temp.Next;
        }

        System.Console.WriteLine();
    }

    // Detect lost parcel
    public bool IsParcelLost()
    {
        return head == null;
    }
}
