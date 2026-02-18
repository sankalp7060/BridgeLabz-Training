using TechVille.Core.Interfaces;
using TechVille.Core.Services;
using TechVille.Core.View;

namespace TechVille.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            IEligibilityService eligibilityService = new EligibilityService();
            IValidationService validationService = new ValidationService();
            ILoggerService loggerService = new LoggerService();

            ICitizenService citizenService = new CitizenService(
                eligibilityService,
                validationService,
                loggerService
            );

            ConsoleUI ui = new ConsoleUI(citizenService);
            ui.Start();
        }
    }
}
