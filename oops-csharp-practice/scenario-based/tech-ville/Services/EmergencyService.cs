namespace TechVille.OOPS.Services
{
    // Sealed class - cannot be inherited
    public sealed class EmergencyService : Service
    {
        public EmergencyService()
            : base("Emergency Service") { }

        public override void ExecuteService()
        {
            System.Console.WriteLine("Handling emergency immediately!");
        }

        // Overriding virtual method
        public override void BookService()
        {
            System.Console.WriteLine("Emergency service auto-booked!");
        }
    }
}
