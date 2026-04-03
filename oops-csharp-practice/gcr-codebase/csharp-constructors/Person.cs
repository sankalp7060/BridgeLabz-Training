using System;

class Person
{
    string name;
    int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public Person(Person p)
    {
        name = p.name;
        age = p.age;
    }

    public void Display()
    {
        Console.WriteLine($"{name}, {age}");
    }

    static void Main()
    {
        Person p1 = new Person("Rahul", 25);
        Person p2 = new Person(p1);

        p2.Display();
    }
}
