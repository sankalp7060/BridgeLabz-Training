namespace TechVille.OOPS.Models
{
    // Separate profile class to demonstrate object relationships
    public class CitizenProfile
    {
        public string Address { get; set; }
        public string Email { get; set; }

        public void ShowProfile()
        {
            System.Console.WriteLine($"Address: {Address}, Email: {Email}");
        }
    }
}
