using System;

sealed class ParcelMenu
{
    public void Show()
    {
        ParcelService service = new ParcelService();

        while (true)
        {
            Console.WriteLine("\n==== PARCEL TRACKER MENU ====");
            Console.WriteLine("1. Show Parcel Tracking");
            Console.WriteLine("2. Add Custom Checkpoint");
            Console.WriteLine("3. Simulate Lost Parcel");
            Console.WriteLine("4. Check Delivery Status");
            Console.WriteLine("5. Exit");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    service.ShowTracking();
                    break;

                case 2:
                    service.AddCheckpoint();
                    break;

                case 3:
                    service.SimulateLoss();
                    break;

                case 4:
                    service.VerifyStatus();
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
    }
}
