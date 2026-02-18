namespace Models
{
    /// <summary>
    /// Represents a citizen in TechVille system.
    ///
    /// Demonstrates:
    /// - Encapsulation
    /// - Static auto ID generation
    /// </summary>
    public class Citizen
    {
        private static int counter = 1;

        public int CitizenId { get; private set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }

        public Citizen(string name, string city, int age)
        {
            CitizenId = counter++;
            Name = name;
            City = city;
            Age = age;
        }
    }
}
