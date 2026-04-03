public abstract class Appliance : IControllable
{
    public string Name { get; protected set; }

    public Appliance(string name)
    {
        Name = name;
    }

    public abstract void TurnOn();

    public abstract void TurnOff();
}
