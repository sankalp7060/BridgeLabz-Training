using System;

class Program
{
    static void Main()
    {
        Patient[] patients = new Patient[3];

        patients[0] = new InPatient(1, "Rahul", 45, 5, 3000);
        patients[1] = new OutPatient(2, "Anita", 30, 800);
        patients[2] = new InPatient(3, "Aman", 60, 3, 4000);

        Console.WriteLine("Patient Details and Billing:\n");

        foreach (var patient in patients)
        {
            patient.GetPatientDetails();
            Console.WriteLine("Bill Amount: " + patient.CalculateBill());

            if (patient is IMedicalRecord record)
            {
                record.AddRecord("Routine Checkup");
                record.ViewRecords();
            }

            Console.WriteLine();
        }
    }
}
