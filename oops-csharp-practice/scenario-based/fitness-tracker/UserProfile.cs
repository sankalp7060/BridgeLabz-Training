class UserProfile
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public double Weight { get; private set; }

    public UserProfile(string name, int age, double weight)
    {
        Name = name;
        Age = age;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"User: {Name}, Age: {Age}, Weight: {Weight}kg";
    }
}
