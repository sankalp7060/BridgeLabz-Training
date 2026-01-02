using System;

namespace BusRouteTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus bus = new Bus();
            RouteTracker tracker = new RouteTracker(bus);

            tracker.StartJourney();
        }
    }
}
