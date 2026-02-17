using Interfaces;
using Models;

namespace Services
{
    /// <summary>
    /// Service layer responsible for business logic.
    /// Communicates between UI and Repository.
    /// </summary>
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository repository;

        /// <summary>
        /// Constructor Injection (Dependency Injection)
        /// Reduces coupling and follows OOP principles.
        /// </summary>
        public PatientService(IPatientRepository repo)
        {
            repository = repo;
        }

        public void RegisterPatient(Patient patient)
        {
            repository.Save(patient);
            Console.WriteLine("\nPatient Registered Successfully!\n");
        }

        public void ShowPatient()
        {
            Patient p = repository.Get();

            if (p == null)
            {
                Console.WriteLine("No patient found.");
                return;
            }

            PrintPatient(p);
        }

        public void UpdatePatient()
        {
            Patient p = repository.Get();

            if (p == null)
            {
                Console.WriteLine("No patient exists.");
                return;
            }

            Console.Write("Enter New Phone: ");
            p.Phone = Console.ReadLine();

            Console.Write("Enter New Address: ");
            p.Address = Console.ReadLine();

            repository.Update(p);

            Console.WriteLine("Patient Updated Successfully!");
        }

        public void SearchPatient(int id)
        {
            Patient p = repository.SearchById(id);

            if (p == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            PrintPatient(p);
        }

        /// <summary>
        /// Common method for printing patient details.
        /// Demonstrates code reuse.
        /// </summary>
        private void PrintPatient(Patient p)
        {
            Console.WriteLine("\n---- Patient Details ----");
            Console.WriteLine($"ID: {p.PatientId}");
            Console.WriteLine($"Name: {p.Name}");
            Console.WriteLine($"DOB: {p.DOB}");
            Console.WriteLine($"Phone: {p.Phone}");
            Console.WriteLine($"Address: {p.Address}");
            Console.WriteLine($"Blood Group: {p.BloodGroup}");
        }
    }
}
