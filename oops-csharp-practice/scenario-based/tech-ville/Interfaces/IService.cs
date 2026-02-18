using Models;

namespace Interfaces
{
    /// <summary>
    /// Base abstraction for all city services.
    /// Demonstrates abstraction.
    /// </summary>
    public interface IService
    {
        void ProcessRequest(ServiceRequest request);
    }
}
