using System;

class Program
{
    static void Main()
    {
        CallLogManager manager = new CallLogManager(10);

        manager.AddCallLog("9876543210", "Internet not working", DateTime.Now.AddMinutes(-60));
        manager.AddCallLog("9123456789", "Call drop issue", DateTime.Now.AddMinutes(-30));
        manager.AddCallLog("9988776655", "Billing related query", DateTime.Now.AddMinutes(-10));

        manager.SearchByKeyword("issue");

        manager.FilterByTime(DateTime.Now.AddMinutes(-40), DateTime.Now);
    }
}
