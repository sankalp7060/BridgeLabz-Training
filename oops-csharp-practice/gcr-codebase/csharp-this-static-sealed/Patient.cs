using System;

class Patient
{
    public static string HospitalName = "City Hospital";
    private static int totalPatients = 0;

    public string Name;
    public int Age;
    public string Ailment;
    public readonly int PatientID;

    public Patient(string name, int age, string ailment, int patientID)
    {
        this.Name = name;
        this.Age = age;
        this.Ailment = ailment;
        this.PatientID = patientID;
        totalPatients++;
    }

    public static void GetTotalPatients()
    {
        Console.WriteLine("Total Patients: " + totalPatients);
    }

    public void Display(object obj)
    {
        if (obj is Patient)
        {
            Console.WriteLine($"{Name}, Age: {Age}, Ailment: {Ailment}, ID: {PatientID}");
        }
    }

    static void Main()
    {
        Patient p = new Patient("Neha", 25, "Fever", 301);
        p.Display(p);
        GetTotalPatients();
    }
}
