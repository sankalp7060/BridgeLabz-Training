using System;

public class Fan : Appliance
{
    public Fan()
        : base("Fan") { }

    public override void TurnOn()
    {
        Console.WriteLine("Fan is turn on");
    }

    public override void TurnOff()
    {
        Console.WriteLine("Fan is turn off");
    }
}
