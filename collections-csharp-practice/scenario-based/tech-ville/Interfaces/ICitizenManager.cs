using Models;

namespace Interfaces
{
    /// <summary>
    /// Defines operations for managing citizens
    /// and service requests using collections.
    /// </summary>
    public interface ICitizenManager
    {
        void RegisterCitizen(Citizen citizen);
        void ViewAllCitizens();
        void SearchByCity(string city);
        void SortByName();
        void AddToServiceQueue(ServiceRequest request);
        void ProcessNextRequest();
        void UndoLastRegistration();
        void CountByCity();
    }
}
