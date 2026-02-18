using TechVille.OOPS.Interfaces;

namespace TechVille.OOPS.Services
{
    // Abstract class - cannot be instantiated
    public abstract class Service : IBookable, ICancellable, ITrackable
    {
        // Static variable to count total services
        public static int TotalServices = 0;

        // Common property
        public string ServiceName { get; set; }

        // Constructor
        public Service(string name)
        {
            ServiceName = name;
            TotalServices++;
        }

        // Abstract method (must be overridden)
        public abstract void ExecuteService();

        // Virtual method (can be overridden)
        public virtual void BookService()
        {
            System.Console.WriteLine($"{ServiceName} booked successfully.");
        }

        public virtual void CancelService()
        {
            System.Console.WriteLine($"{ServiceName} cancelled.");
        }

        public virtual void TrackStatus()
        {
            System.Console.WriteLine($"{ServiceName} is in progress.");
        }
    }
}
