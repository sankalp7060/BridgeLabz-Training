using System;
using System.Reflection;

class AccessModifyStaticFields
{
    static void Main()
    {
        Type type = typeof(Configuration);

        FieldInfo field = type.GetField("API_KEY", BindingFlags.NonPublic | BindingFlags.Static);

        // Set value
        field.SetValue(null, "NEW_API_KEY_123");

        // Get value
        string apiKey = (string)field.GetValue(null);
        Console.WriteLine("API_KEY: " + apiKey);
    }
}

public class Configuration
{
    private static string API_KEY = "OLD_API_KEY";
}
