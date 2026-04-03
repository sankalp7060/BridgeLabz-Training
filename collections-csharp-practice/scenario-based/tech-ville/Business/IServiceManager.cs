using System.Collections.Generic;
using TechVilleSmartCity.Models;

namespace TechVilleSmartCity.Business
{
    /// <summary>
    /// Service Manager Interface
    /// Module 6-9: Service management abstraction
    /// </summary>
    public interface IServiceManager
    {
        void AddService(Service service);
        Service GetService(string serviceId);
        List<Service> GetAllServices();
        bool SubscribeToService(string citizenId, string serviceId);
        bool UnsubscribeFromService(string citizenId, string serviceId);
        decimal CalculateServiceCharge(string citizenId, string serviceId, int usageCount);
        List<Service> GetAvailableServicesForCitizen(string citizenId);
        string GetServiceReport();
    }
}
