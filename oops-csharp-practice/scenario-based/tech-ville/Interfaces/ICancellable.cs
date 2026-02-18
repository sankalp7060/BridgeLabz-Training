using Models;

namespace Interfaces
{
    /// <summary>
    /// Interface for cancellable services.
    /// Demonstrates multiple interface implementation.
    /// </summary>
    public interface ICancellable
    {
        void Cancel(ServiceRequest request);
    }
}
