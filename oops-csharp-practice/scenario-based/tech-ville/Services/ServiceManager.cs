using Interfaces;
using Models;

namespace Services
{
    /// <summary>
    /// Acts as coordinator between UI and Services.
    /// Demonstrates dependency injection and loose coupling.
    /// </summary>
    public class ServiceManager
    {
        private IService service;

        public ServiceManager(IService service)
        {
            this.service = service;
        }

        public void Execute(ServiceRequest request)
        {
            service.ProcessRequest(request);
        }
    }
}
