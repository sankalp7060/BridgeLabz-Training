using System.Collections.Generic;

public class VesselUtil : IVesselUtil
{
    private List<Vessel> vesselList = new List<Vessel>();

    // Getter and Setter
    public List<Vessel> VesselList
    {
        get { return vesselList; }
        set { vesselList = value; }
    }

    // Requirement 1
    public void AddVesselPerformance(Vessel vessel)
    {
        vesselList.Add(vessel);
    }

    // Requirement 2
    public Vessel GetVesselById(string vesselId)
    {
        for (int i = 0; i < vesselList.Count; i++)
        {
            if (vesselList[i].VesselId == vesselId)
            {
                return vesselList[i];
            }
        }

        return null;
    }

    // Requirement 3
    public List<Vessel> GetHighPerformanceVessels()
    {
        List<Vessel> result = new List<Vessel>();

        if (vesselList.Count == 0)
            return result;

        double maxSpeed = vesselList[0].AverageSpeed;

        // Find highest speed
        for (int i = 1; i < vesselList.Count; i++)
        {
            if (vesselList[i].AverageSpeed > maxSpeed)
            {
                maxSpeed = vesselList[i].AverageSpeed;
            }
        }

        // Collect vessels with highest speed
        for (int i = 0; i < vesselList.Count; i++)
        {
            if (vesselList[i].AverageSpeed == maxSpeed)
            {
                result.Add(vesselList[i]);
            }
        }

        return result;
    }
}
