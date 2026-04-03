using Interfaces;
using Models;

namespace DataAccess
{
    /// <summary>
    /// Repository implementation.
    /// In OOP version we store data in memory.
    /// DB implementation will come in DBMS branch.
    /// </summary>
    public class PatientRepository : IPatientRepository
    {
        private Patient patient;

        public void Save(Patient p)
        {
            patient = p;
        }

        public Patient Get()
        {
            return patient;
        }

        public void Update(Patient p)
        {
            patient = p;
        }

        public Patient SearchById(int id)
        {
            if (patient != null && patient.PatientId == id)
                return patient;

            return null;
        }
    }
}
