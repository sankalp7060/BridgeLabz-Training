using System;

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
