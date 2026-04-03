using System;

public class AC : Appliance
{
    public AC()
        : base("AC") { }

    public override void TurnOn()
    {
        Console.WriteLine("AC is turn on");
    }

    public override void TurnOff()
    {
        Console.WriteLine("AC is turn off");
    }
}
