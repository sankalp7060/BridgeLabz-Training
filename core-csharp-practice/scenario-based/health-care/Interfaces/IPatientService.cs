using Models;

namespace Interfaces
{
    public interface IPatientService
    {
        void RegisterPatient(Patient patient);
        void ShowPatient();
        void UpdatePatient();
        void SearchPatient();
    }
}
