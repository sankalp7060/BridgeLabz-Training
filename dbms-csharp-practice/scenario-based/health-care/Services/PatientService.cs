using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Models;

namespace Services
{
    /// <summary>
    /// Business layer implementing patient operations.
    /// Uses repository to persist and retrieve patient data from SQL Server.
    /// </summary>
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository repository;

        /// <summary>
        /// Constructor injection of repository
        /// </summary>
        public PatientService(IPatientRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Registers a patient
        /// </summary>
        public void RegisterPatient(Patient patient)
        {
            repository.InsertPatient(patient);
            Console.WriteLine("Patient Registered Successfully!");
        }

        /// <summary>
        /// Updates patient details
        /// </summary>
        public void UpdatePatient(int patientId)
        {
            Patient p = repository.GetPatientById(patientId);
            if (p == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            Console.Write("Full Name: ");
            p.FullName = Console.ReadLine();

            Console.Write("DOB (yyyy-mm-dd): ");
            p.DOB = Console.ReadLine();

            Console.Write("Gender (M/F): ");
            p.Gender = Console.ReadLine();

            Console.Write("Phone: ");
            p.Phone = Console.ReadLine();

            Console.Write("Email: ");
            p.Email = Console.ReadLine();

            Console.Write("Address: ");
            p.Address = Console.ReadLine();

            Console.Write("Blood Group: ");
            p.BloodGroup = Console.ReadLine();

            repository.UpdatePatient(p);
            Console.WriteLine("Patient Updated Successfully!");
        }

        /// <summary>
        /// Show patient by ID
        /// </summary>
        public void ShowPatientById(int patientId)
        {
            Patient p = repository.GetPatientById(patientId);
            if (p == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            PrintPatient(p);
        }

        /// <summary>
        /// Show all patients
        /// </summary>
        public void ShowAllPatients()
        {
            List<Patient> patients = repository.GetAllPatients();

            if (!patients.Any())
            {
                Console.WriteLine("No patients found.");
                return;
            }

            foreach (var p in patients)
            {
                PrintPatient(p);
            }
        }

        /// <summary>
        /// Search patient by name (partial match)
        /// </summary>
        public void SearchPatientByName(string name)
        {
            List<Patient> results = repository.SearchPatientsByName(name);

            if (!results.Any())
            {
                Console.WriteLine("No matching patients found.");
                return;
            }

            foreach (var p in results)
            {
                PrintPatient(p);
            }
        }

        /// <summary>
        /// Helper method to print patient details
        /// </summary>
        private void PrintPatient(Patient p)
        {
            Console.WriteLine("\n--- Patient Details ---");
            Console.WriteLine($"ID: {p.PatientId}");
            Console.WriteLine($"Name: {p.FullName}");
            Console.WriteLine($"DOB: {p.DOB}");
            Console.WriteLine($"Gender: {p.Gender}");
            Console.WriteLine($"Phone: {p.Phone}");
            Console.WriteLine($"Email: {p.Email}");
            Console.WriteLine($"Address: {p.Address}");
            Console.WriteLine($"Blood Group: {p.BloodGroup}");
        }
    }
}
