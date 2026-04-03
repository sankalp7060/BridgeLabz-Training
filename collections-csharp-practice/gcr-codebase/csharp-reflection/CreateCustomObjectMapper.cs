using System;
using System.Collections.Generic;
using System.Reflection;

class CreateCustomObjectMapper
{
    static void Main()
    {
        var props = new Dictionary<string, object> { { "Name", "Sankalp" }, { "Age", 25 } };

        Person p = ToObject<Person>(typeof(Person), props);
        Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
    }

    public static T ToObject<T>(Type clazz, Dictionary<string, object> properties)
        where T : new()
    {
        T obj = new T();
        foreach (var prop in properties)
        {
            PropertyInfo property = clazz.GetProperty(prop.Key);
            if (property != null && property.CanWrite)
            {
                property.SetValue(obj, prop.Value);
            }
        }
        return obj;
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
