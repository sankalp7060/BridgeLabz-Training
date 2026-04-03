public class Vessel
{
    public string VesselId { get; set; }
    public string VesselName { get; set; }
    public double AverageSpeed { get; set; }
    public string VesselType { get; set; }

    // No-argument constructor
    public Vessel() { }

    // Four-argument constructor
    public Vessel(string vesselId, string vesselName, double averageSpeed, string vesselType)
    {
        VesselId = vesselId;
        VesselName = vesselName;
        AverageSpeed = averageSpeed;
        VesselType = vesselType;
    }
}
