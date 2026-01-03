using System;

interface Worker
{
    void PerformDuties();
}

class Person
{
    public string Name { get; set; }
    public int Id { get; set; }
}

class Chef : Person, Worker
{
    public void PerformDuties()
    {
        Console.WriteLine("Chef cooks food");
    }
}

class Waiter : Person, Worker
{
    public void PerformDuties()
    {
        Console.WriteLine("Waiter serves food");
    }
}

class RestaurantSystem
{
    static void Main()
    {
        Worker chef = new Chef { Name = "Ram", Id = 1 };
        Worker waiter = new Waiter { Name = "Shyam", Id = 2 };

        chef.PerformDuties();
        waiter.PerformDuties();
    }
}
