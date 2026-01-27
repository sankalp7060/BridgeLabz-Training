using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Field)]
class MaxLengthAttribute : Attribute
{
    public int Length;

    public MaxLengthAttribute(int length)
    {
        Length = length;
    }
}

class User
{
    [MaxLength(5)]
    public string Username;

    public User(string name)
    {
        FieldInfo field = typeof(User).GetField("Username");
        var attr = (MaxLengthAttribute)
            Attribute.GetCustomAttribute(field, typeof(MaxLengthAttribute));

        if (name.Length > attr.Length)
            throw new ArgumentException("Username too long!");

        Username = name;
    }
}

class MaxLengthValidation
{
    static void Main()
    {
        User u = new User("Admin"); // ✅ Works
        Console.WriteLine(u.Username);

        // Uncomment below line to see validation in action
        // User u2 = new User("Administrator"); // throws ArgumentException
    }
}
