using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class ImportantMethodAttribute : Attribute
{
    public string Level { get; set; } = "HIGH";

    public ImportantMethodAttribute() { }

    public ImportantMethodAttribute(string level)
    {
        Level = level;
    }
}

class Demo
{
    [ImportantMethod]
    public void Save() { }

    [ImportantMethod("LOW")]
    public void Load() { }
}

class ImportantMethods
{
    static void Main()
    {
        foreach (MethodInfo m in typeof(Demo).GetMethods())
        {
            var attr = (ImportantMethodAttribute)
                Attribute.GetCustomAttribute(m, typeof(ImportantMethodAttribute));

            if (attr != null)
            {
                Console.WriteLine($"{m.Name} - {attr.Level}");
            }
        }
    }
}
