using System;

public class UserInterface
{
    public static void Start()
    {
        IFlightUtil flightUtil = new FlightUtil();

        Console.WriteLine("Enter flight details");
        string input = Console.ReadLine(); // Format: FL-1234:SpiceJet:250:50000

        try
        {
            string[] details = input.Split(':');

            if (details.Length != 4)
            {
                Console.WriteLine(
                    "Invalid input format. Please use <FlightNumber>:<FlightName>:<PassengerCount>:<CurrentFuelLevel>"
                );
                return;
            }

            string flightNumber = details[0];
            string flightName = details[1];
            int passengerCount = int.Parse(details[2]);
            double currentFuel = double.Parse(details[3]);

            flightUtil.ValidateFlightNumber(flightNumber);
            flightUtil.ValidateFlightName(flightName);
            flightUtil.ValidatePassengerCount(passengerCount, flightName);

            double fuelNeeded = flightUtil.CalculateFuelToFillTank(flightName, currentFuel);

            Console.WriteLine($"Fuel required to fill the tank: {fuelNeeded} liters");
        }
        catch (InvalidFlightException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input: Passenger count and Fuel level must be numeric");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
