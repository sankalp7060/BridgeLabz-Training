using TechVille.Core.Models;

namespace TechVille.Core.Interfaces
{
    public interface IEligibilityService
    {
        double CalculateEligibility(Citizen citizen);
        ServicePackage GetPackage(double score);
    }
}
