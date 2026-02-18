namespace TechVille.Core.Models
{
    public class RegistrationResult
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public Citizen Citizen { get; set; }
    }
}
