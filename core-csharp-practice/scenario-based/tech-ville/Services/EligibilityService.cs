using TechVille.Core.Interfaces;
using TechVille.Core.Models;

namespace TechVille.Core.Services
{
    public class EligibilityService : IEligibilityService
    {
        public ServicePackage CalculatePackage(Citizen citizen)
        {
            if (citizen.Age > 60 && citizen.Income < 300000)
                return ServicePackage.Platinum;

            if (citizen.Income > 1000000)
                return ServicePackage.Gold;

            if (citizen.ResidencyYears > 5)
                return ServicePackage.Silver;

            return ServicePackage.Basic;
        }
    }
}
