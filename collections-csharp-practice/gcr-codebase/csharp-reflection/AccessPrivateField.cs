using System;
using System.Reflection;

class AccessPrivateField
{
    static void Main()
    {
        Person p = new Person();
        Type type = typeof(Person);

        // Access private field 'age'
        FieldInfo field = type.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);

        // Set value
        field.SetValue(p, 25);

        // Get value
        int ageValue = (int)field.GetValue(p);
        Console.WriteLine("Person's age: " + ageValue);
    }
}

public class Person
{
    private int age;
}
