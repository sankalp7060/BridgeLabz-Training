using System;

class ApplianceUtilityImpl
{
    private Appliance[] appliances;

    public void Utility()
    {
        appliances = new Appliance[3];
        appliances[0] = new Light();
        appliances[1] = new Fan();
        appliances[2] = new AC();

        for (int i = 0; i < appliances.Length; i++)
        {
            appliances[i].TurnOn();
            appliances[i].TurnOff();
            Console.WriteLine();
        }
    }
}
