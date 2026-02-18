namespace Models
{
    /// <summary>
    /// Represents a request made by a citizen.
    /// Demonstrates object composition.
    /// </summary>
    public class ServiceRequest
    {
        public Citizen Citizen { get; set; }
        public string ServiceType { get; set; }
        public string Status { get; set; }

        public ServiceRequest(Citizen citizen, string serviceType)
        {
            Citizen = citizen;
            ServiceType = serviceType;
            Status = "BOOKED";
        }
    }
}
