public class Aadhar
{
    public long Number { get; private set; }
    public string Name { get; private set; }

    public Aadhar(long number, string name)
    {
        Number = number;
        Name = name;
    }

    public override string ToString() => $"Aadhar number of {Name} is {Number}";
}
