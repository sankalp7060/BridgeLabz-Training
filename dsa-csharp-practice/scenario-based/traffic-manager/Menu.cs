using System;

// Menu class to show console UI
sealed class Menu
{
    public void Show()
    {
        ITrafficManager manager = new TrafficManagerUtility(); // Manager object

        while (true)
        {
            Console.WriteLine("\n--- Smart Traffic Manager ---");
            Console.WriteLine("1. Add Car To Queue");
            Console.WriteLine("2. Move Car To Roundabout");
            Console.WriteLine("3. Remove Car From Roundabout");
            Console.WriteLine("4. Display Roundabout");
            Console.WriteLine("5. Exit");

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    manager.AddCarToQueue();
                    break;
                case 2:
                    manager.MoveCarToRoundabout();
                    break;
                case 3:
                    manager.RemoveCarFromRoundabout();
                    break;
                case 4:
                    manager.DisplayRoundabout();
                    break;
                case 5:
                    return; // Exit program
                default:
                    Console.WriteLine("Invalid Choice ");
                    break;
            }
        }
    }
}
