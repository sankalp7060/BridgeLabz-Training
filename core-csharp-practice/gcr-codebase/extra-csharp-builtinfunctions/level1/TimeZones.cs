using System;

class TimeZones{
    // Main method: Entry point of program
    static void Main(){
        // Get current UTC time
        DateTimeOffset utcTime = DateTimeOffset.UtcNow;

        // Display GMT time (same as UTC)
        Console.WriteLine("GMT Time: " + utcTime);

        // Get Indian Standard Time zone
        TimeZoneInfo istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTimeOffset istTime = TimeZoneInfo.ConvertTime(utcTime, istZone);
        Console.WriteLine("IST Time: " + istTime);

        // Get Pacific Standard Time zone
        TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        DateTimeOffset pstTime = TimeZoneInfo.ConvertTime(utcTime, pstZone);
        Console.WriteLine("PST Time: " + pstTime);
    }
}
