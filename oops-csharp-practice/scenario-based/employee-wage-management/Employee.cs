public class Employee
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public double WagePerHour { get; private set; }

    public Employee(int id, string name, double wagePerHour)
    {
        Id = id;
        Name = name;
        WagePerHour = wagePerHour;
    }

    public override string ToString()
    {
        return $"Employee ID: {Id}, Name: {Name}, Wage Per Hour: {WagePerHour}";
    }
}
