using System;
using HealthCheckPro.Domain.Attributes;

namespace HealthCheckPro.Controllers
{
    public class PatientController
    {
        [PublicAPI]
        public void GetPatientInfo()
        {
            Console.WriteLine("Fetching patient info...");
        }

        [RequiresAuth]
        public void UpdatePatientInfo()
        {
            Console.WriteLine("Updating patient info...");
        }
    }
}
