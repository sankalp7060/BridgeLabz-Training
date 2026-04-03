using System;

namespace BusRouteTracker
{
    class RouteTracker
    {
        private Bus bus;
        private int totalDistance = 0;

        public RouteTracker(Bus bus)
        {
            this.bus = bus;
        }

        public void StartJourney()
        {
            bool isTravelling = true;
            int stopNumber = 1;

            while (isTravelling)
            {
                totalDistance += bus.DistancePerStop;

                Console.WriteLine($"Stop {stopNumber} reached.");
                Console.WriteLine($"Total Distance Travelled: {totalDistance} km");

                Console.Write("Do you want to get off? (yes/no): ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "yes")
                {
                    Console.WriteLine("Passenger got off the bus.");
                    Console.WriteLine($"Final Distance Travelled: {totalDistance} km");
                    isTravelling = false;
                }
                else
                {
                    stopNumber++;
                    Console.Clear();
                }
            }
        }
    }
}
