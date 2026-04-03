using System;
using System.Text.RegularExpressions;

public class FlightUtil : IFlightUtil
{
    public bool ValidateFlightNumber(String flightNumber)
    {
        string pattern = @"^FL-(\d{4})$";
        Match match = Regex.Match(flightNumber, pattern);
        if (!match.Success)
        {
            throw new InvalidFlightException($"The flight number {flightNumber} is invalid");
        }
        int number = int.Parse(match.Groups[1].Value);
        if (number < 1000 || number > 9999)
        {
            throw new InvalidFlightException($"The flight number {flightNumber} is invalid");
        }

        return true;
    }

    public bool ValidateFlightName(String flightName)
    {
        string[] names = { "SpiceJet", "Vistara", "IndiGo", "Air Arabia" };
        foreach (string name in names)
        {
            if (string.Equals(flightName, name, StringComparison.Ordinal))
                return true;
        }

        throw new InvalidFlightException($"The flight name {flightName} is invalid");
    }

    public bool ValidatePassengerCount(int passengerCount, String flightName)
    {
        int maxCapacity = flightName switch
        {
            "SpiceJet" => 396,
            "Vistara" => 615,
            "IndiGo" => 230,
            "Air Arabia" => 130,
            _ => 0,
        };
        if (passengerCount <= 0 || passengerCount > maxCapacity)
        {
            throw new InvalidFlightException(
                $"The passenger count {passengerCount} is invalid for {flightName}"
            );
        }

        return true;
    }

    public double CalculateFuelToFillTank(string flightName, double currentFuelLevel)
    {
        double maxFuel = flightName switch
        {
            "SpiceJet" => 200000,
            "Vistara" => 300000,
            "IndiGo" => 250000,
            "Air Arabia" => 150000,
            _ => 0,
        };

        if (currentFuelLevel < 0 || currentFuelLevel > maxFuel)
        {
            throw new InvalidFlightException($"Invalid fuel level for {flightName}");
        }

        return maxFuel - currentFuelLevel;
    }
}
