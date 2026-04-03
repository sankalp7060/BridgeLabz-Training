namespace TechVille.OOPS.Services
{
    // Inheritance example
    public class HealthcareService : Service
    {
        public HealthcareService()
            : base("Healthcare Service") { }

        // Overriding abstract method
        public override void ExecuteService()
        {
            System.Console.WriteLine("Providing healthcare facilities.");
        }

        // Method overloading example
        public void ExecuteService(string department)
        {
            System.Console.WriteLine($"Providing healthcare in {department} department.");
        }
    }
}
