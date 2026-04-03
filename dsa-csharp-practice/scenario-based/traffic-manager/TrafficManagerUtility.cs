using System;

// Implements traffic manager operations
class TrafficManagerUtility : ITrafficManager
{
    private CarQueue queue = new CarQueue(); // Waiting queue
    private RoundAbout list = new RoundAbout(); // Roundabout circular list

    // Add car to queue
    public void AddCarToQueue()
    {
        Console.WriteLine("Enter the car id:- ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the car name:- ");
        string name = Console.ReadLine();

        Car car = new Car(id, name);
        queue.Enqueue(car);
    }

    // Move car from queue to roundabout
    public void MoveCarToRoundabout()
    {
        Car car = queue.Dequeue();
        if (car != null)
        {
            list.AddCar(car);
            Console.WriteLine("Car Entered Roundabout ");
        }
    }

    // Remove car from roundabout
    public Car RemoveCarFromRoundabout()
    {
        Car car = list.RemoveCar();
        if (car != null)
        {
            Console.WriteLine($"Car Exited Roundabout: {car}");
            return car;
        }
        else
        {
            Console.WriteLine("Roundabout Empty");
            return null;
        }
    }

    // Display roundabout state
    public void DisplayRoundabout()
    {
        list.Display();
    }
}
