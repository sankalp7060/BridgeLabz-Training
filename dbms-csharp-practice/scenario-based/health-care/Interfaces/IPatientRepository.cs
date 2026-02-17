using System.Collections.Generic;
using Models;

namespace Interfaces
{
    /// <summary>
    /// Repository contract for patient database operations.
    /// This interface abstracts ADO.NET operations for Patients table.
    /// </summary>
    public interface IPatientRepository
    {
        void InsertPatient(Patient patient);
        void UpdatePatient(Patient patient);
        Patient GetPatientById(int id);
        List<Patient> GetAllPatients();
        Patient GetPatientByPhoneOrEmail(string phone, string email);
        List<Patient> SearchPatientsByName(string name);
    }
}
