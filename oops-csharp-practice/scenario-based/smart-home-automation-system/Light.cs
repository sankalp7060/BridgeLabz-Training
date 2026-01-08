using System;

public class Light : Appliance
{
    public Light()
        : base("Light") { }

    public override void TurnOn()
    {
        Console.WriteLine("Light is turn on");
    }

    public override void TurnOff()
    {
        Console.WriteLine("Light is turn off");
    }
}
