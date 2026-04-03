using System;

class CallLogManager
{
    private CallLog[] logs;
    private int count;

    public CallLogManager(int size)
    {
        logs = new CallLog[size];
        count = 0;
    }

    public void AddCallLog(string phone, string message, DateTime time)
    {
        if (count < logs.Length)
        {
            logs[count++] = new CallLog(phone, message, time);
        }
        else
        {
            Console.WriteLine("Call log storage is full.");
        }
    }

    public void SearchByKeyword(string keyword)
    {
        Console.WriteLine($"\nSearching for keyword: '{keyword}'\n");

        bool found = false;

        for (int i = 0; i < count; i++)
        {
            if (logs[i].Message.Contains(keyword))
            {
                logs[i].Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No logs found with the given keyword.");
        }
    }

    public void FilterByTime(DateTime start, DateTime end)
    {
        Console.WriteLine($"\nLogs between {start} and {end}\n");

        bool found = false;

        for (int i = 0; i < count; i++)
        {
            if (logs[i].Timestamp >= start && logs[i].Timestamp <= end)
            {
                logs[i].Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No logs found in the given time range.");
        }
    }
}
