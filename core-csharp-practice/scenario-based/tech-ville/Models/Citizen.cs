namespace Models
{
    /// <summary>
    /// Represents a citizen registering in TechVille system.
    ///
    /// CORE CONCEPTS USED:
    /// - Variables
    /// - Data Types
    /// - Properties
    ///
    /// This model stores basic citizen information
    /// required for service eligibility calculation.
    /// </summary>
    public class Citizen
    {
        // Citizen full name
        public string Name { get; set; }

        // Citizen age
        public int Age { get; set; }

        // Annual income of citizen
        public double Income { get; set; }

        // Number of years citizen stayed in city
        public int ResidencyYears { get; set; }

        // Calculated eligibility score
        public double EligibilityScore { get; set; }

        // Service package assigned
        public string ServicePackage { get; set; }
    }
}
