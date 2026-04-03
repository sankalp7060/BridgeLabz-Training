// Represents a Car with Id and Name
public class Car
{
    public int Id { get; private set; } // Car Id
    public string Name { get; private set; } // Car Name

    public Car(int id, string name)
    {
        Id = id;
        Name = name;
    }

    // Override to display Car info
    public override string ToString()
    {
        return $"[{Id} - {Name}]";
    }
}
