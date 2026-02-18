using System;
using TechVilleSmartCity.Models;

namespace TechVilleSmartCity.Business.Validators
{
    /// <summary>
    /// Citizen data validator
    /// Module 4: Validation methods
    /// Module 20: Data validation
    /// </summary>
    public static class CitizenValidator
    {
        public static bool Validate(Citizen citizen)
        {
            if (citizen == null)
                throw new ArgumentNullException(nameof(citizen));

            // Validate name
            if (string.IsNullOrWhiteSpace(citizen.Name))
                throw new ArgumentException("Name cannot be empty");

            if (citizen.Name.Length < 2 || citizen.Name.Length > 50)
                throw new ArgumentException("Name must be between 2 and 50 characters");

            // Validate age
            if (citizen.Age < 0 || citizen.Age > 150)
                throw new ArgumentException("Age must be between 0 and 150");

            // Validate income
            if (citizen.Income < 0)
                throw new ArgumentException("Income cannot be negative");

            // Validate residency years
            if (citizen.ResidencyYears < 0)
                throw new ArgumentException("Residency years cannot be negative");

            // Validate sector
            if (citizen.Sector < 1 || citizen.Sector > 20)
                throw new ArgumentException("Sector must be between 1 and 20");

            return true;
        }
    }
}
