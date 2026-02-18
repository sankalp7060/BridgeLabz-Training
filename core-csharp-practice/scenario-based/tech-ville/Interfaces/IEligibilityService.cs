using TechVille.Core.Models;

namespace TechVille.Core.Interfaces
{
    public interface IEligibilityService
    {
        ServicePackage CalculatePackage(Citizen citizen);
    }
}
