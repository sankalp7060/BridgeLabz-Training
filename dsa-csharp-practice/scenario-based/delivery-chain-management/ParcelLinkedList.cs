using System;

public class ParcelLinkedList
{
    private StageNode head;

    public void InitializeDefaultStages()
    {
        AddStage("Packed");
        AddStage("Shipped");
        AddStage("In Transit");
        AddStage("Delivered");
    }

    public void AddStage(string stage)
    {
        StageNode node = new StageNode(stage);

        if (head == null)
        {
            head = node;
            return;
        }

        StageNode temp = head;

        while (temp.Next != null)
        {
            temp = temp.Next;
        }

        temp.Next = node;
    }

    public void AddCheckpointAfter(string existingStage, string newStage)
    {
        StageNode temp = head;

        while (temp != null)
        {
            if (temp.Stage.Equals(existingStage))
            {
                StageNode node = new StageNode(newStage);
                node.Next = temp.Next;
                temp.Next = node;
                return;
            }

            temp = temp.Next;
        }

        Console.WriteLine("Stage not found");
    }

    public void DisplayTracking()
    {
        if (head == null)
        {
            Console.WriteLine("No parcel tracking available");
            return;
        }

        StageNode temp = head;

        Console.Write("Parcel Route: ");

        while (temp != null)
        {
            Console.Write(temp.Stage);

            if (temp.Next != null)
                Console.Write(" -> ");

            temp = temp.Next;
        }

        Console.WriteLine();
    }

    public void SimulateLostParcel(string stage)
    {
        StageNode temp = head;

        while (temp != null && temp.Next != null)
        {
            if (temp.Stage.Equals(stage))
            {
                temp.Next = null;
                Console.WriteLine("Delivery chain broken after: " + stage);
                return;
            }

            temp = temp.Next;
        }

        Console.WriteLine("Stage not found");
    }

    public void CheckBrokenChain()
    {
        StageNode temp = head;

        if (temp == null)
        {
            Console.WriteLine("No tracking data");
            return;
        }

        while (temp != null)
        {
            if (temp.Next == null && !temp.Stage.Equals("Delivered"))
            {
                Console.WriteLine("WARNING: Parcel lost after " + temp.Stage);
                return;
            }

            temp = temp.Next;
        }

        Console.WriteLine("Parcel delivered successfully");
    }
}
