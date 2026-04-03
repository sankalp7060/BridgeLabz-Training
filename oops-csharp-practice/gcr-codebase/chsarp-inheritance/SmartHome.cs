using System;

class Device
{
    public int DeviceId { get; set; }
    public string Status { get; set; }
}

class Thermostat : Device
{
    public int TemperatureSetting { get; set; }

    public void DisplayStatus()
    {
        Console.WriteLine($"Device {DeviceId} | Status: {Status} | Temp: {TemperatureSetting}");
    }
}

class SmartHome
{
    static void Main()
    {
        Thermostat t = new Thermostat
        {
            DeviceId = 101,
            Status = "On",
            TemperatureSetting = 24,
        };

        t.DisplayStatus();
    }
}
