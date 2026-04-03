using System;

sealed class ParcelMain
{
    public static void Start()
    {
        IParcelTracker tracker = new ParcelTrackerService();

        while (true)
        {
            Console.WriteLine("\n====== Parcel Tracker System ======");
            Console.WriteLine("1. View Tracking");
            Console.WriteLine("2. Add Custom Checkpoint");
            Console.WriteLine("3. Check Parcel Status");
            Console.WriteLine("4. Exit");
            Console.Write("Choose Option: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    tracker.DisplayTracking();
                    break;

                case 2:
                    Console.Write("Insert After Stage: ");
                    string existing = Console.ReadLine();

                    Console.Write("New Checkpoint Name: ");
                    string newStage = Console.ReadLine();

                    tracker.AddCheckpointAfter(existing, newStage);
                    break;

                case 3:
                    if (tracker.IsParcelLost())
                        Console.WriteLine("Parcel LOST ");
                    else
                        Console.WriteLine("Parcel Active");

                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
    }
}
