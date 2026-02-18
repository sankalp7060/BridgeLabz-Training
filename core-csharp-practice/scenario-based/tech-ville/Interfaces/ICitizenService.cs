using TechVille.Core.Models;

namespace TechVille.Core.Interfaces
{
    public interface ICitizenService
    {
        RegistrationResult RegisterCitizen(Citizen citizen);
        void DisplayCitizen(Citizen citizen);
    }
}
