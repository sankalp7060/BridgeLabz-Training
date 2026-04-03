public class User
{
    public string Name { get; private set; }
    public int Id { get; private set; }
    public int Steps { get; set; }

    public User(int id, string name, int steps)
    {
        Name = name;
        Id = id;
        Steps = steps;
    }

    public override string ToString()
    {
        return $"{Name}, {Id}, {Steps}";
    }
}
