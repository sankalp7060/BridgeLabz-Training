// Interface for traffic manager operations
public interface ITrafficManager
{
    void AddCarToQueue(); // Add car to waiting queue
    void MoveCarToRoundabout(); // Move car from queue to roundabout
    Car RemoveCarFromRoundabout(); // Remove car from roundabout
    void DisplayRoundabout(); // Display all cars in roundabout
}
