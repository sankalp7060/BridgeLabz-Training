using System.Collections.Generic;
using TechVilleSmartCity.Models;

namespace TechVilleSmartCity.Data
{
    /// <summary>
    /// Citizen Repository Interface
    /// Module 9: Interface for contract definition
    /// </summary>
    public interface ICitizenRepository
    {
        Citizen GetById(string citizenId);
        List<Citizen> GetAll();
        void Add(Citizen citizen);
        void Update(Citizen citizen);
        void Delete(string citizenId);
        List<Citizen> GetByZone(string zone);
        List<Citizen> GetByAgeRange(int minAge, int maxAge);
        bool Exists(string citizenId);
        int GetTotalCount();
    }
}
