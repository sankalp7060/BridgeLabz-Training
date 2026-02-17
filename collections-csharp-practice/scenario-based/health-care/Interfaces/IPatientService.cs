using System.Collections.Generic;
using Models;

namespace Interfaces
{
    /// <summary>
    /// Service layer contract for business logic.
    /// Handles multiple patients, searching, and sorting.
    /// </summary>
    public interface IPatientService
    {
        void RegisterPatient(Patient patient);
        void ShowAllPatients();
        void UpdatePatient(int id);
        void SearchPatientById(int id);
        void SearchPatientByName(string name);
        void ShowPatientsSortedByName();
        void CountPatients();
    }
}
