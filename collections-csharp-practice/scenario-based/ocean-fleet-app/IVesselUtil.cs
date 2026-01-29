using System.Collections.Generic;

public interface IVesselUtil
{
    void AddVesselPerformance(Vessel vessel);

    Vessel GetVesselById(string vesselId);

    List<Vessel> GetHighPerformanceVessels();
}
