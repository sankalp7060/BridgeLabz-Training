using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Models;

namespace Services
{
    /// <summary>
    /// Business layer implementing patient operations.
    /// Uses repository to persist and retrieve patients.
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
        /// Register a new patient
        /// </summary>
        public void RegisterPatient(Patient patient)
        {
            repository.Save(patient);
            Console.WriteLine("Patient Registered Successfully!");
        }

        /// <summary>
        /// Display all patients
        /// </summary>
        public void ShowAllPatients()
        {
            List<Patient> all = repository.GetAll();

            if (!all.Any())
            {
                Console.WriteLine("No patients found.");
                return;
            }

            foreach (var p in all)
            {
                PrintPatient(p);
            }
        }

        /// <summary>
        /// Update patient by ID
        /// </summary>
        public void UpdatePatient(int id)
        {
            Patient p = repository.SearchById(id);
            if (p == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            Console.Write("Enter New Name: ");
            p.Name = Console.ReadLine();

            Console.Write("Enter New DOB: ");
            p.DOB = Console.ReadLine();

            Console.Write("Enter New Phone: ");
            p.Phone = Console.ReadLine();

            Console.Write("Enter New Address: ");
            p.Address = Console.ReadLine();

            Console.Write("Enter New Blood Group: ");
            p.BloodGroup = Console.ReadLine();

            repository.Update(p);
            Console.WriteLine("Patient Updated Successfully!");
        }

        /// <summary>
        /// Search patient by ID
        /// </summary>
        public void SearchPatientById(int id)
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
        /// Search patients by Name
        /// </summary>
        public void SearchPatientByName(string name)
        {
            List<Patient> results = repository.SearchByName(name);

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
        /// Display patients sorted alphabetically by Name
        /// </summary>
        public void ShowPatientsSortedByName()
        {
            List<Patient> all = repository.GetAll().OrderBy(p => p.Name).ToList();

            if (!all.Any())
            {
                Console.WriteLine("No patients found.");
                return;
            }

            foreach (var p in all)
            {
                PrintPatient(p);
            }
        }

        /// <summary>
        /// Count total number of patients
        /// </summary>
        public void CountPatients()
        {
            int count = repository.GetAll().Count;
            Console.WriteLine($"Total Patients: {count}");
        }

        /// <summary>
        /// Prints patient details (reusable method)
        /// </summary>
        private void PrintPatient(Patient p)
        {
            Console.WriteLine("\n--- Patient Details ---");
            Console.WriteLine($"ID: {p.PatientId}");
            Console.WriteLine($"Name: {p.Name}");
            Console.WriteLine($"DOB: {p.DOB}");
            Console.WriteLine($"Phone: {p.Phone}");
            Console.WriteLine($"Address: {p.Address}");
            Console.WriteLine($"Blood Group: {p.BloodGroup}");
        }
    }
}
