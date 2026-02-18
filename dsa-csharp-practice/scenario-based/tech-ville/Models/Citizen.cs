namespace TechVille.DSA.Models
{
    // Citizen model used across DSA structures
    public class Citizen
    {
        public int Id;
        public string Name;
        public int Age;

        public Citizen(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
}
