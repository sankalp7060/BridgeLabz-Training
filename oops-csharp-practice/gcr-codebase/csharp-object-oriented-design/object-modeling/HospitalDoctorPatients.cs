using System;

class Patient
{
    public string Name;

    public Patient(string name)
    {
        Name = name;
    }

    public void ShowPatient()
    {
        Console.WriteLine($"Patient: {Name}");
    }
}

class Doctor
{
    public string Name;
    public Patient[] Patients;
    private int count = 0;

    public Doctor(string name, int patientCapacity)
    {
        Name = name;
        Patients = new Patient[patientCapacity];
    }

    public void Consult(Patient patient)
    {
        if (count < Patients.Length)
        {
            Patients[count++] = patient;
            Console.WriteLine($"{Name} is consulting {patient.Name}");
        }
    }

    public void ShowPatients()
    {
        Console.WriteLine($"Doctor {Name} has patients:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(Patients[i].Name);
        }
    }
}

class Hospital
{
    public string Name;
    public Doctor[] Doctors;
    private int count = 0;

    public Hospital(string name, int doctorCapacity)
    {
        Name = name;
        Doctors = new Doctor[doctorCapacity];
    }

    public void AddDoctor(Doctor doctor)
    {
        if (count < Doctors.Length)
        {
            Doctors[count++] = doctor;
        }
    }
}

// Demo
class HospitalDoctorPatients
{
    static void Main()
    {
        Hospital hospital = new Hospital("City Hospital", 2);

        Doctor d1 = new Doctor("Dr. Alice", 5);
        Doctor d2 = new Doctor("Dr. Bob", 5);

        hospital.AddDoctor(d1);
        hospital.AddDoctor(d2);

        Patient p1 = new Patient("John");
        Patient p2 = new Patient("Mary");

        d1.Consult(p1);
        d1.Consult(p2);
        d2.Consult(p1);

        d1.ShowPatients();
        d2.ShowPatients();
    }
}
