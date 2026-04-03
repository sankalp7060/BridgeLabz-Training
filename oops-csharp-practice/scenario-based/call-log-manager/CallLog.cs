using System;

class CallLog
{
    public string Number { get; private set; }
    public string Message { get; private set; }
    public DateTime Timestamp { get; private set; }

    public CallLog(string number, string message, DateTime timestamp)
    {
        Number = number;
        Message = message;
        Timestamp = timestamp;
    }

    public void Display()
    {
        Console.WriteLine($"Phone: {Number}");
        Console.WriteLine($"Message: {Message}");
        Console.WriteLine($"Time: {Timestamp}");
        Console.WriteLine("----------------------------------");
    }
}
