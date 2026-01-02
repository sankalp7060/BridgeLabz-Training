using System;

class Person
{
    private int age;

    public int Age
    {
        get => age;
        set => age = value > 0 ? value : 0;
    }
}

class MinimizePublicFields
{
    static void Main()
    {
        Person p = new Person();
        p.Age = -5;
        Console.WriteLine(p.Age);
    }
}
