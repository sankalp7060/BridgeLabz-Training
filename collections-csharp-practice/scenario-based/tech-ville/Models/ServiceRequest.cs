namespace Models
{
    /// <summary>
    /// Represents a service request.
    /// Used inside Queue collection.
    /// </summary>
    public class ServiceRequest
    {
        public Citizen Citizen { get; set; }
        public string ServiceType { get; set; }

        public ServiceRequest(Citizen citizen, string type)
        {
            Citizen = citizen;
            ServiceType = type;
        }
    }
}
