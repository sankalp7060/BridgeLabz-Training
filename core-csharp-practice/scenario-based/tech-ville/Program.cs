using System;
using TechVille.Core.Services;
using TechVille.Core.Views;

namespace TechVille.Core
{
    class Program
    {
        static void Main()
        {
            CitizenView view = new CitizenView();
            CitizenService citizenService = new CitizenService();
            EligibilityService eligibility = new EligibilityService();

            view.ShowWelcome();

            bool running = true;

            while (running)
            {
                var citizen = citizenService.RegisterCitizen();

                citizen.EligibilityScore = eligibility.CalculateEligibility(citizen);

                citizen.Package = eligibility.GetPackage(citizen.EligibilityScore);

                citizenService.DisplayCitizen(citizen);

                Console.WriteLine("\nRegister Another? (y/n)");
                string choice = Console.ReadLine();

                running = choice.ToLower() == "y";
            }

            view.ShowExit();
        }
    }
}
