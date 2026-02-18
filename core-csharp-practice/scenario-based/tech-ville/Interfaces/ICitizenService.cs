using Models;

namespace Interfaces
{
    /// <summary>
    /// Interface defining citizen-related operations.
    ///
    /// PURPOSE:
    /// - Introduces abstraction (basic level)
    /// - UI layer depends on interface, not implementation
    /// </summary>
    public interface ICitizenService
    {
        // Registers a citizen and calculates eligibility
        void RegisterCitizen(Citizen citizen);

        // Displays citizen details
        void ShowCitizen();

        // Allows multiple family member registration
        void RegisterFamilyMembers();
    }
}
