using System;
using System.Reflection;
using System.Text;

class GenerateJSONRepresentation
{
    static void Main()
    {
        Person p = new Person { Name = "Sankalp", Age = 25 };
        string json = ToJson(p);
        Console.WriteLine(json);
    }

    public static string ToJson(object obj)
    {
        Type type = obj.GetType();
        StringBuilder sb = new StringBuilder();
        sb.Append("{ ");

        foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            sb.Append($"\"{prop.Name}\": \"{prop.GetValue(obj)}\", ");
        }

        if (sb.Length > 2)
            sb.Length -= 2; // Remove trailing comma

        sb.Append(" }");
        return sb.ToString();
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
