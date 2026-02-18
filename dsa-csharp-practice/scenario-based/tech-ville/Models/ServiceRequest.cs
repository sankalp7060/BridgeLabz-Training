namespace TechVille.DSA.Models
{
    // Represents service request in queue systems
    public class ServiceRequest
    {
        public int CitizenId;
        public string ServiceName;
        public int Priority;

        public ServiceRequest(int id, string service, int priority)
        {
            CitizenId = id;
            ServiceName = service;
            Priority = priority;
        }
    }
}
