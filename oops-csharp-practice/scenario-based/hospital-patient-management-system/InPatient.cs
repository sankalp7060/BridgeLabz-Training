using System;

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
