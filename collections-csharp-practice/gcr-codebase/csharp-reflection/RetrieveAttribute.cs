using System;
using System.Reflection;

class RetrieveAttribute
{
    static void Main()
    {
        Type type = typeof(Book);
        var attr = (AuthorAttribute)Attribute.GetCustomAttribute(type, typeof(AuthorAttribute));
        if (attr != null)
        {
            Console.WriteLine("Author: " + attr.Name);
        }
    }
}

[AttributeUsage(AttributeTargets.Class)]
public class AuthorAttribute : Attribute
{
    public string Name { get; }

    public AuthorAttribute(string name)
    {
        Name = name;
    }
}

[Author("Sankalp Agarwal")]
public class Book { }
