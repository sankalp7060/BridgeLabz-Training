using TechVille.Core.Interfaces;

namespace TechVille.Core.Services
{
    public class ValidationService : IValidationService
    {
        public bool ValidateName(string name) => !string.IsNullOrWhiteSpace(name);

        public bool ValidateAge(int age) => age >= 18 && age <= 100;

        public bool ValidateIncome(double income) => income >= 0;

        public bool ValidateResidency(int years) => years >= 0;
    }
}
