using System;

interface IMedicalRecord
{
    void AddRecord(string diagnosis);
    void ViewRecords();
}

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

class InPatient : Patient, IMedicalRecord
{
    private int daysAdmitted;
    private double dailyCharge;

    public InPatient(int id, string name, int age, int days, double charge)
        : base(id, name, age)
    {
        daysAdmitted = days;
        dailyCharge = charge;
    }

    public override double CalculateBill()
    {
        return daysAdmitted * dailyCharge + 2000;
    }

    public void AddRecord(string diagnosis)
    {
        medicalHistory += diagnosis + "; ";
    }

    public void ViewRecords()
    {
        Console.WriteLine("Medical History: " + medicalHistory);
    }
}

class OutPatient : Patient, IMedicalRecord
{
    private double consultationFee;

    public OutPatient(int id, string name, int age, double fee)
        : base(id, name, age)
    {
        consultationFee = fee;
    }

    public override double CalculateBill()
    {
        return consultationFee;
    }

    public void AddRecord(string diagnosis)
    {
        medicalHistory += diagnosis + "; ";
    }

    public void ViewRecords()
    {
        Console.WriteLine("Medical History: " + medicalHistory);
    }
}

class HospitalPatientManagementSystem
{
    static void Main()
    {
        Patient[] patients = new Patient[3];

        patients[0] = new InPatient(1, "Rahul", 45, 5, 3000);
        patients[1] = new OutPatient(2, "Anita", 30, 800);
        patients[2] = new InPatient(3, "Aman", 60, 3, 4000);

        Console.WriteLine("Patient Details and Billing:\n");

        for (int i = 0; i < patients.Length; i++)
        {
            patients[i].GetPatientDetails();
            Console.WriteLine("Bill Amount: " + patients[i].CalculateBill());

            if (patients[i] is IMedicalRecord record)
            {
                record.AddRecord("Routine Checkup");
                record.ViewRecords();
            }

            Console.WriteLine();
        }
    }
}
