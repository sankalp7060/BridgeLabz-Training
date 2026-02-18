using TechVille.Core.Interfaces;
using TechVille.Core.Models;

namespace TechVille.Core.Services
{
    public class CitizenService : ICitizenService
    {
        private readonly IEligibilityService _eligibilityService;
        private readonly IValidationService _validationService;
        private readonly ILoggerService _logger;

        public CitizenService(
            IEligibilityService eligibilityService,
            IValidationService validationService,
            ILoggerService logger
        )
        {
            _eligibilityService = eligibilityService;
            _validationService = validationService;
            _logger = logger;
        }

        public RegistrationResult RegisterCitizen(Citizen citizen)
        {
            if (!_validationService.ValidateName(citizen.Name))
                return new RegistrationResult { IsSuccessful = false, Message = "Invalid Name" };

            if (!_validationService.ValidateAge(citizen.Age))
                return new RegistrationResult { IsSuccessful = false, Message = "Invalid Age" };

            citizen.Package = _eligibilityService.CalculatePackage(citizen);

            _logger.Log("Citizen Registered Successfully");

            return new RegistrationResult
            {
                IsSuccessful = true,
                Message = "Registration Successful",
                Citizen = citizen,
            };
        }

        public void DisplayCitizen(Citizen citizen)
        {
            Console.WriteLine("\n===== Citizen Details =====");
            Console.WriteLine(citizen);
        }
    }
}
