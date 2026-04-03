using System.Collections.Generic;
using Models;

namespace Interfaces
{
    /// <summary>
    /// Repository contract for patient data operations.
    /// Handles multiple patients using collections.
    /// </summary>
    public interface IPatientRepository
    {
        void Save(Patient patient); // Save a single patient
        List<Patient> GetAll(); // Retrieve all patients
        void Update(Patient patient); // Update patient by ID
        Patient SearchById(int id); // Search a patient by ID
        List<Patient> SearchByName(string name); // Search patients by Name (partial match)
    }
}
