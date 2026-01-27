using System;
using System.Linq;
using System.Reflection;

class GetClassInfo
{
    static void Main()
    {
        Console.Write("Enter class name: ");
        string className = Console.ReadLine() ?? "";

        Type? type = AppDomain
            .CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.FullName == className || t.Name == className);

        if (type == null)
        {
            Console.WriteLine("Class not found!");
            return;
        }

        Console.WriteLine("\n--- Methods ---");
        foreach (
            var method in type.GetMethods(
                BindingFlags.Public
                    | BindingFlags.NonPublic
                    | BindingFlags.Instance
                    | BindingFlags.Static
            )
        )
        {
            Console.WriteLine(method.Name);
        }

        Console.WriteLine("\n--- Fields ---");
        foreach (
            var field in type.GetFields(
                BindingFlags.Public
                    | BindingFlags.NonPublic
                    | BindingFlags.Instance
                    | BindingFlags.Static
            )
        )
        {
            Console.WriteLine(field.Name);
        }

        Console.WriteLine("\n--- Constructors ---");
        foreach (
            var ctor in type.GetConstructors(
                BindingFlags.Public
                    | BindingFlags.NonPublic
                    | BindingFlags.Instance
                    | BindingFlags.Static
            )
        )
        {
            Console.WriteLine(ctor);
        }
    }
}

// Test class
public class SampleClass
{
    private int secret;
    public string Name = "";

    public SampleClass() { }

    public SampleClass(int x)
    {
        secret = x;
    }

    private void HiddenMethod() { }

    public void Show() { }
}
