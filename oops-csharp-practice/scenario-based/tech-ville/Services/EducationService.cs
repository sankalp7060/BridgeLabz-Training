namespace TechVille.OOPS.Services
{
    public class EducationService : Service
    {
        public EducationService()
            : base("Education Service") { }

        public override void ExecuteService()
        {
            System.Console.WriteLine("Providing education support.");
        }
    }
}
