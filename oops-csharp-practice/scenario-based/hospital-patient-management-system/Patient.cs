using System;

abstract class Patient
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    protected string medicalHistory;

    public Patient(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
        medicalHistory = "";
    }

    public abstract double CalculateBill();

    public void GetPatientDetails()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}");
    }
}
