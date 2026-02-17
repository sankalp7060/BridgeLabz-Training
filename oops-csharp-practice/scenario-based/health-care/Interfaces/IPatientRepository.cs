using Models;

namespace Interfaces
{
    /// <summary>
    /// Repository contract for patient data operations.
    /// Data layer implementation will follow this contract.
    /// </summary>
    public interface IPatientRepository
    {
        void Save(Patient patient);
        Patient Get();
        void Update(Patient patient);
        Patient SearchById(int id);
    }
}
