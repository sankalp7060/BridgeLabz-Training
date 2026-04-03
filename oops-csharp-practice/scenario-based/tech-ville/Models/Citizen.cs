namespace TechVille.OOPS.Models
{
    // Citizen class demonstrates Encapsulation
    public class Citizen
    {
        // Private fields (data hiding)
        private string name;
        private int age;

        // Public property for Name (controlled access)
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Public property for Age
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0)
                    age = value;
            }
        }

        // Static variable shared across all objects
        public static int TotalCitizens = 0;

        // Readonly field (can only be set in constructor)
        public readonly int CitizenId;

        // Constructor
        public Citizen(string name, int age, int id)
        {
            // this keyword differentiates field from parameter
            this.name = name;
            this.age = age;
            this.CitizenId = id;

            TotalCitizens++; // Static variable increment
        }

        // Method to display citizen info
        public void Display()
        {
            System.Console.WriteLine($"Citizen ID: {CitizenId}, Name: {Name}, Age: {Age}");
        }
    }
}
