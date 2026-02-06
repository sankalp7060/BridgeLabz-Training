using System;

public class RobotHazardAuditor
{
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        // Validate arm precision
        if (armPrecision < 0.0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
        }

        // Validate worker density
        if (workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        }

        // Determine machine risk factor
        double machineRiskFactor;

        if (machineryState == "Worn")
            machineRiskFactor = 1.3;
        else if (machineryState == "Faulty")
            machineRiskFactor = 2.0;
        else if (machineryState == "Critical")
            machineRiskFactor = 3.0;
        else
            throw new RobotSafetyException("Error: Unsupported machinery state");

        // Hazard Risk Formula
        double hazardRisk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);

        return hazardRisk;
    }
}
