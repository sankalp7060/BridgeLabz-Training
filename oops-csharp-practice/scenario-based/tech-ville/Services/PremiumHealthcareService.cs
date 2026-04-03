namespace TechVille.OOPS.Services
{
    // Demonstrating use of base keyword
    public class PremiumHealthcareService : HealthcareService
    {
        public override void ExecuteService()
        {
            base.ExecuteService(); // Call parent method
            System.Console.WriteLine("Providing premium healthcare benefits.");
        }
    }
}
