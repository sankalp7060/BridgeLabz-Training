using System.Collections.Generic;
using TechVilleSmartCity.Models;

namespace TechVilleSmartCity.Business
{
    /// <summary>
    /// Citizen Service Business Logic Interface
    /// Module 4: Service layer abstraction
    /// </summary>
    public interface ICitizenService
    {
        Citizen RegisterCitizen(
            string name,
            int age,
            decimal income,
            int residencyYears,
            string zone,
            int sector,
            string email,
            string phone,
            string password
        );
        Citizen GetCitizen(string citizenId);
        List<Citizen> GetAllCitizens();
        bool UpdateCitizen(Citizen citizen);
        bool DeleteCitizen(string citizenId);
        List<Citizen> SearchCitizens(string searchTerm);
        int CalculateEligibilityScore(string citizenId);
        string GetRecommendedServicePackage(string citizenId);
        bool ValidateCitizenData(Citizen citizen);
    }
}
