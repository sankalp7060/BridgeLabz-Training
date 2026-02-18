using Models;

namespace Services
{
    /// <summary>
    /// Derived class representing Education Service.
    /// Demonstrates runtime polymorphism.
    /// </summary>
    public class EducationService : BaseService
    {
        public EducationService()
        {
            ServiceName = "Education";
        }

        public override void ProcessRequest(ServiceRequest request)
        {
            Console.WriteLine("Processing education request...");
            Console.WriteLine("Course enrollment successful.");
            request.Status = "COMPLETED";
        }
    }
}
