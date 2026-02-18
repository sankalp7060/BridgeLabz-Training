namespace Models
{
    /// <summary>
    /// Represents a citizen in TechVille system.
    ///
    /// OOP CONCEPTS:
    /// - Encapsulation
    /// - Private fields with public properties
    /// </summary>
    public class Citizen
    {
        private string name;
        private int age;

        // Static member to auto-generate citizen IDs
        private static int counter = 1;

        public int CitizenId { get; private set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                    age = value;
            }
        }

        // Constructor
        public Citizen(string name, int age)
        {
            CitizenId = counter++;
            Name = name;
            Age = age;
        }
    }
}
