using TechVille.Core.Models;

namespace TechVille.Core.Interfaces
{
    public interface ICitizenService
    {
        Citizen RegisterCitizen();
        void DisplayCitizen(Citizen citizen);
    }
}
