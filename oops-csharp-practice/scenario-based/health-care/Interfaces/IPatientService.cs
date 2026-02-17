using Models;

namespace Interfaces
{
    /// <summary>
    /// Business layer contract.
    /// All patient-related business operations are defined here.
    /// </summary>
    public interface IPatientService
    {
        void RegisterPatient(Patient patient);
        void ShowPatient();
        void UpdatePatient();
        void SearchPatient(int id);
    }
}
