using System;

public class ParcelService : IParcel
{
    private ParcelLinkedList list;

    public ParcelService()
    {
        list = new ParcelLinkedList();
        list.InitializeDefaultStages();
    }

    public void ShowTracking()
    {
        list.DisplayTracking();
    }

    public void AddCheckpoint()
    {
        Console.Write("Enter existing stage: ");
        string oldStage = Console.ReadLine();

        Console.Write("Enter new checkpoint name: ");
        string newStage = Console.ReadLine();

        list.AddCheckpointAfter(oldStage, newStage);
    }

    public void SimulateLoss()
    {
        Console.Write("Break chain after stage: ");
        string stage = Console.ReadLine();

        list.SimulateLostParcel(stage);
    }

    public void VerifyStatus()
    {
        list.CheckBrokenChain();
    }
}
