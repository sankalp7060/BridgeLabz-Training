// Node class for Roundabout circular linked list
public class CarNode
{
    public Car Data { get; private set; } // Car data
    public CarNode Next { get; set; } // Next node in circular list

    public CarNode(Car car)
    {
        Data = car;
        Next = null;
    }
}
