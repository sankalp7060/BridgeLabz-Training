using System;

class Logger
{
    // Can be overridden to change logging behavior
    public virtual void Log() => Console.WriteLine("Logging info");
}

class FileLogger : Logger
{
    public override void Log() => Console.WriteLine("Logging to file");
}

class DocumentInheritance
{
    static void Main()
    {
        Logger l = new FileLogger();
        l.Log();
    }
}
