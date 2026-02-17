using Interfaces;
using Models;

namespace Services
{
    public class PatientService : IPatientService
    {
        private Patient patient;

        public void RegisterPatient(Patient p)
        {
            patient = p;
            Console.WriteLine("\nPatient Registered Successfully!\n");
        }

        public void ShowPatient()
        {
            if (patient == null)
            {
                Console.WriteLine("No patient found.");
                return;
            }

            Console.WriteLine("\n---- Patient Details ----");
            Console.WriteLine($"ID: {patient.PatientId}");
            Console.WriteLine($"Name: {patient.Name}");
            Console.WriteLine($"DOB: {patient.DOB}");
            Console.WriteLine($"Phone: {patient.Phone}");
            Console.WriteLine($"Address: {patient.Address}");
            Console.WriteLine($"Blood Group: {patient.BloodGroup}");
        }

        public void UpdatePatient()
        {
            if (patient == null)
            {
                Console.WriteLine("No patient available to update.");
                return;
            }

            Console.Write("Enter New Phone: ");
            patient.Phone = Console.ReadLine();

            Console.Write("Enter New Address: ");
            patient.Address = Console.ReadLine();

            Console.WriteLine("Patient Updated Successfully!");
        }

        public void SearchPatient()
        {
            if (patient == null)
            {
                Console.WriteLine("No patient exists.");
                return;
            }

            Console.Write("Enter Patient ID: ");
            int id = int.Parse(Console.ReadLine());

            if (patient.PatientId == id)
                ShowPatient();
            else
                Console.WriteLine("Patient not found.");
        }
    }
}
