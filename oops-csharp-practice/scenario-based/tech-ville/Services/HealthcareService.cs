using Models;

namespace Services
{
    /// <summary>
    /// Derived class representing Healthcare Service.
    /// Demonstrates inheritance and polymorphism.
    /// </summary>
    public class HealthcareService : BaseService
    {
        public HealthcareService()
        {
            ServiceName = "Healthcare";
        }

        public override void ProcessRequest(ServiceRequest request)
        {
            Console.WriteLine("Processing healthcare request...");
            Console.WriteLine("Doctor assigned.");
            request.Status = "COMPLETED";
        }
    }
}
