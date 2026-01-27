using System;
using System.Reflection;
using System.Text;

[AttributeUsage(AttributeTargets.Field)]
class JsonFieldAttribute : Attribute
{
    public string Name { get; set; }
}

class User
{
    [JsonField(Name = "user_name")]
    public string Name = "Sankalp";

    [JsonField(Name = "user_age")]
    public int Age = 22;
}

class CustomJSONSerializationProgram
{
    static void Main()
    {
        User u = new User();

        StringBuilder json = new StringBuilder("{");

        foreach (FieldInfo f in typeof(User).GetFields())
        {
            var attr = (JsonFieldAttribute)
                Attribute.GetCustomAttribute(f, typeof(JsonFieldAttribute));

            if (attr != null)
            {
                json.Append($"\"{attr.Name}\":\"{f.GetValue(u)}\",");
            }
        }

        // Remove trailing comma
        if (json[json.Length - 1] == ',')
            json.Remove(json.Length - 1, 1);

        json.Append("}");

        Console.WriteLine(json.ToString());
    }
}
