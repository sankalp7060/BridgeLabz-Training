using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Models;

namespace DataAccess
{
    /// <summary>
    /// Repository implementation using List<T> for storing multiple patients.
    /// </summary>
    public class PatientRepository : IPatientRepository
    {
        // In-memory storage of patients
        private readonly List<Patient> patients = new List<Patient>();

        /// <summary>
        /// Save a patient if ID or phone/email does not exist (no duplicates).
        /// </summary>
        public void Save(Patient patient)
        {
            // Check for duplicate PatientId or Phone
            if (patients.Any(p => p.PatientId == patient.PatientId || p.Phone == patient.Phone))
            {
                System.Console.WriteLine("Duplicate Patient ID or Phone. Cannot register.");
                return;
            }

            patients.Add(patient);
        }

        /// <summary>
        /// Returns all patients
        /// </summary>
        public List<Patient> GetAll()
        {
            return patients;
        }

        /// <summary>
        /// Update patient details by matching ID
        /// </summary>
        public void Update(Patient patient)
        {
            Patient existing = patients.FirstOrDefault(p => p.PatientId == patient.PatientId);
            if (existing != null)
            {
                existing.Name = patient.Name;
                existing.DOB = patient.DOB;
                existing.Phone = patient.Phone;
                existing.Address = patient.Address;
                existing.BloodGroup = patient.BloodGroup;
            }
        }

        /// <summary>
        /// Search a single patient by ID
        /// </summary>
        public Patient SearchById(int id)
        {
            return patients.FirstOrDefault(p => p.PatientId == id);
        }

        /// <summary>
        /// Search patients by Name (partial match)
        /// </summary>
        public List<Patient> SearchByName(string name)
        {
            return patients.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
