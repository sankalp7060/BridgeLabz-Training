using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechVilleSmartCity.Business;
using TechVilleSmartCity.Data;
using TechVilleSmartCity.UI;
using TechVilleSmartCity.Utilities;

namespace TechVilleSmartCity
{
    /// <summary>
    /// Main entry point for TechVille Smart City Management System
    /// This console application demonstrates all 20 modules of the project
    /// Following layered architecture with proper separation of concerns
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Initialize the application
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine("    WELCOME TO TECHVILLE SMART CITY MANAGEMENT SYSTEM");
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine("\nInitializing system components...");

                // Setup data context and repositories
                var dataContext = new DataContext();
                var citizenRepository = new CitizenRepository(dataContext);
                var serviceRepository = new ServiceRepository(dataContext);

                // Setup business services
                var citizenService = new CitizenService(citizenRepository);
                var serviceManager = new ServiceManager(serviceRepository);

                // Initialize and run menu manager
                var menuManager = new MenuManager(citizenService, serviceManager);
                menuManager.ShowMainMenu();

                Console.WriteLine("\nThank you for using TechVille Smart City Management System!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "Program.Main");
                Console.WriteLine($"\nFatal Error: {ex.Message}");
                Console.WriteLine("Please check the log file for details.");
                Console.ReadKey();
            }
        }
    }
}
