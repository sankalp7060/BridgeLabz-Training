public interface IFlightUtil
{
    bool ValidateFlightNumber(string flightNumber);
    bool ValidateFlightName(string flightName);
    bool ValidatePassengerCount(int passengerCount, string flightName);
    double CalculateFuelToFillTank(string flightName, double currentFuelLevel);
}
