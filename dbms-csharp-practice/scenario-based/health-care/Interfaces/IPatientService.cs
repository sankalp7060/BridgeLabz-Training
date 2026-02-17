using System.Collections.Generic;
using Models;

namespace Interfaces
{
    /// <summary>
    /// Service layer contract for patient operations.
    /// Implements business logic using repository layer.
    /// </summary>
    public interface IPatientService
    {
        void RegisterPatient(Patient patient);
        void UpdatePatient(int patientId);
        void ShowPatientById(int patientId);
        void ShowAllPatients();
        void SearchPatientByName(string name);
    }
}
