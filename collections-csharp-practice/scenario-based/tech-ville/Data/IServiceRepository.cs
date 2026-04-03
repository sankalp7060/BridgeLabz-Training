using System.Collections.Generic;
using TechVilleSmartCity.Models;

namespace TechVilleSmartCity.Data
{
    /// <summary>
    /// Service Repository Interface
    /// Module 9: Interface for contract definition
    /// </summary>
    public interface IServiceRepository
    {
        Service GetById(string serviceId);
        List<Service> GetAll();
        void Add(Service service);
        void Update(Service service);
        void Delete(string serviceId);
        List<Service> GetByType(string serviceType);
        List<Service> GetAvailableServices();
        bool Exists(string serviceId);
    }
}
