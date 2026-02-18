using Interfaces;
using Models;

namespace Services
{
    /// <summary>
    /// Abstract base class for all services.
    /// Demonstrates abstraction and inheritance.
    /// </summary>
    public abstract class BaseService : IService, IBookable, ICancellable
    {
        public string ServiceName { get; protected set; }

        // Abstract method forces derived classes to implement their own logic
        public abstract void ProcessRequest(ServiceRequest request);

        public virtual void Book(ServiceRequest request)
        {
            request.Status = "BOOKED";
            Console.WriteLine($"{ServiceName} service booked successfully.");
        }

        public virtual void Cancel(ServiceRequest request)
        {
            request.Status = "CANCELLED";
            Console.WriteLine($"{ServiceName} service cancelled.");
        }
    }
}
