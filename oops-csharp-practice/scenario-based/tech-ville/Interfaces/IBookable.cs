using Models;

namespace Interfaces
{
    /// <summary>
    /// Interface for bookable services.
    /// Demonstrates interface segregation.
    /// </summary>
    public interface IBookable
    {
        void Book(ServiceRequest request);
    }
}
