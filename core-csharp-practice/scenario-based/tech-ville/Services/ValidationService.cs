namespace TechVille.Core.Services
{
    public class ValidationService
    {
        public bool ValidateAge(int age)
        {
            return age >= 0 && age <= 120;
        }

        public bool ValidateIncome(double income)
        {
            return income >= 0;
        }
    }
}
