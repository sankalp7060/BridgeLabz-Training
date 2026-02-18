namespace TechVille.Core.Interfaces
{
    public interface IValidationService
    {
        bool ValidateName(string name);
        bool ValidateAge(int age);
        bool ValidateIncome(double income);
        bool ValidateResidency(int years);
    }
}
