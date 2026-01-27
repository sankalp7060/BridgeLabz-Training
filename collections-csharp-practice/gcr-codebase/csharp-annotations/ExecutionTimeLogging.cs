using System;
using System.Diagnostics;

[AttributeUsage(AttributeTargets.Method)]
class LogExecutionTimeAttribute : Attribute { }

class Service
{
    [LogExecutionTime]
    public void HeavyTask()
    {
        System.Threading.Thread.Sleep(1000);
    }
}

class ExecutionTimeLogging
{
    static void Main()
    {
        Service s = new Service();

        Stopwatch sw = Stopwatch.StartNew();
        s.HeavyTask();
        sw.Stop();

        Console.WriteLine("Time: " + sw.ElapsedMilliseconds + " ms");
    }
}
