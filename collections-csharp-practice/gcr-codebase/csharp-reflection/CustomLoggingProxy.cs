using System;
using System.Reflection;

class CustomLoggingProxy
{
    static void Main()
    {
        IGreeting greeting = LoggingProxy<IGreeting>.Create(new Greeting());
        greeting.SayHello("Sankalp");
    }
}

public interface IGreeting
{
    void SayHello(string name);
}

public class Greeting : IGreeting
{
    public void SayHello(string name) => Console.WriteLine($"Hello, {name}!");
}

public class LoggingProxy<T> : DispatchProxy
{
    internal T? _decorated;

    protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
    {
        if (targetMethod == null)
            throw new ArgumentNullException(nameof(targetMethod));

        if (_decorated == null)
            throw new InvalidOperationException("Decorated object not set");

        Console.WriteLine($"Calling method: {targetMethod.Name}");

        return targetMethod.Invoke(_decorated, args);
    }

    public static T Create(T decorated)
    {
        var proxy =
            Create<T, LoggingProxy<T>>() as LoggingProxy<T>
            ?? throw new InvalidOperationException("Proxy creation failed");

        proxy._decorated = decorated;

        return (T)(object)proxy;
    }
}
