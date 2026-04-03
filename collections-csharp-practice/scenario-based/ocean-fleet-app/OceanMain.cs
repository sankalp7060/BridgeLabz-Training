using System;
using System.Collections.Generic;

public class OceanMain
{
    public static void Start()
    {
        IVesselUtil vesselUtil = new VesselUtil();

        Console.WriteLine("Enter the number of vessels to be added");
        int count = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter vessel details");

        for (int i = 0; i < count; i++)
        {
            string input = Console.ReadLine();

            string[] data = input.Split(':');

            string id = data[0];
            string name = data[1];
            double speed = Convert.ToDouble(data[2]);
            string type = data[3];

            Vessel vessel = new Vessel(id, name, speed, type);

            vesselUtil.AddVesselPerformance(vessel);
        }

        Console.WriteLine("Enter the Vessel Id to check speed");
        string searchId = Console.ReadLine();

        Vessel foundVessel = vesselUtil.GetVesselById(searchId);

        if (foundVessel != null)
        {
            Console.WriteLine(
                foundVessel.VesselId
                    + " | "
                    + foundVessel.VesselName
                    + " | "
                    + foundVessel.VesselType
                    + " | "
                    + foundVessel.AverageSpeed
                    + " knots"
            );
        }
        else
        {
            Console.WriteLine("Vessel Id " + searchId + " not found");
        }

        Console.WriteLine("High performance vessels are");

        List<Vessel> highSpeedList = vesselUtil.GetHighPerformanceVessels();

        for (int i = 0; i < highSpeedList.Count; i++)
        {
            Vessel v = highSpeedList[i];

            Console.WriteLine(
                v.VesselId
                    + " | "
                    + v.VesselName
                    + " | "
                    + v.VesselType
                    + " | "
                    + v.AverageSpeed
                    + " knots"
            );
        }
    }
}
