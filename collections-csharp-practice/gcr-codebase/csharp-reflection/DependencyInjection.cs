using System;
using System.Reflection;

class DependencyInjection
{
    static void Main()
    {
        ServiceConsumer consumer = DIContainer.Resolve<ServiceConsumer>();
        consumer.Run();
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class InjectAttribute : Attribute { }

public class DIContainer
{
    public static T Resolve<T>()
        where T : new()
    {
        T obj = new T();
        foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (Attribute.IsDefined(prop, typeof(InjectAttribute)))
            {
                object service = Activator.CreateInstance(prop.PropertyType);
                prop.SetValue(obj, service);
            }
        }
        return obj;
    }
}

public class Service
{
    public void DoWork() => Console.WriteLine("Service is working!");
}

public class ServiceConsumer
{
    [Inject]
    public Service MyService { get; set; }

    public void Run() => MyService.DoWork();
}
