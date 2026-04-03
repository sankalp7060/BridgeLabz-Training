using TechVille.Core.Interfaces;
using TechVille.Core.Models;

namespace TechVille.Core.Services
{
    public class EligibilityService : IEligibilityService
    {
        public double CalculateEligibility(Citizen c)
        {
            double score = 0;

            score += c.Age * 0.3;
            score += c.ResidencyYears * 5;
            score += c.Income / 10000;

            return score;
        }

        public ServicePackage GetPackage(double score)
        {
            return score switch
            {
                >= 80 => ServicePackage.Platinum,
                >= 60 => ServicePackage.Gold,
                >= 40 => ServicePackage.Silver,
                _ => ServicePackage.Basic,
            };
        }
    }
}
