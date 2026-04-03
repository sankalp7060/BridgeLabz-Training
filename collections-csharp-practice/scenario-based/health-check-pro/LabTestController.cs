using System;
using HealthCheckPro.Domain.Attributes;

namespace HealthCheckPro.Controllers
{
    public class LabTestController
    {
        [PublicAPI]
        public void GetTestResult()
        {
            Console.WriteLine("Fetching lab test results...");
        }

        [RequiresAuth]
        public void SubmitTestRequest()
        {
            Console.WriteLine("Submitting lab test request...");
        }

        // Missing annotation
        public void InternalMethod()
        {
            Console.WriteLine("Internal processing...");
        }
    }
}
