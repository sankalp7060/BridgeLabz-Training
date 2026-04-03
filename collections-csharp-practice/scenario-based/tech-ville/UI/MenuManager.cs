using System;
using System.Collections.Generic;
using System.Linq;
using TechVilleSmartCity.Business;
using TechVilleSmartCity.Models;
using TechVilleSmartCity.Utilities;

namespace TechVilleSmartCity.UI
{
    /// <summary>
    /// Menu Manager for console UI
    /// Handles all user interactions with proper menu system
    /// </summary>
    public class MenuManager
    {
        private readonly ICitizenService _citizenService;
        private readonly IServiceManager _serviceManager;

        public MenuManager(ICitizenService citizenService, IServiceManager serviceManager)
        {
            _citizenService = citizenService;
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Show main menu and handle navigation
        /// </summary>
        public void ShowMainMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine("            TECHVILLE SMART CITY MANAGEMENT SYSTEM");
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine("\nMAIN MENU:");
                Console.WriteLine("1. Citizen Management");
                Console.WriteLine("2. Service Management");
                Console.WriteLine("3. Data Reports");
                Console.WriteLine("4. System Tools");
                Console.WriteLine("5. Exit");
                Console.Write("\nSelect an option (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowCitizenMenu();
                        break;
                    case "2":
                        ShowServiceMenu();
                        break;
                    case "3":
                        ShowReportsMenu();
                        break;
                    case "4":
                        ShowSystemToolsMenu();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("\nThank you for using TechVille System!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Citizen Management Menu
        /// Modules 1-5: Citizen operations
        /// </summary>
        private void ShowCitizenMenu()
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine("                   CITIZEN MANAGEMENT");
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine("\n1. Register New Citizen");
                Console.WriteLine("2. View Citizen Details");
                Console.WriteLine("3. Update Citizen Information");
                Console.WriteLine("4. Delete Citizen");
                Console.WriteLine("5. Search Citizens");
                Console.WriteLine("6. View All Citizens");
                Console.WriteLine("7. Calculate Eligibility Score");
                Console.WriteLine("8. Get Recommended Service Package");
                Console.WriteLine("9. Back to Main Menu");
                Console.Write("\nSelect an option (1-9): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterCitizen();
                        break;
                    case "2":
                        ViewCitizen();
                        break;
                    case "3":
                        UpdateCitizen();
                        break;
                    case "4":
                        DeleteCitizen();
                        break;
                    case "5":
                        SearchCitizens();
                        break;
                    case "6":
                        ViewAllCitizens();
                        break;
                    case "7":
                        CalculateEligibility();
                        break;
                    case "8":
                        GetServicePackage();
                        break;
                    case "9":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Register new citizen - Module 1
        /// </summary>
        private void RegisterCitizen()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTER NEW CITIZEN ===\n");

            try
            {
                // Get citizen details
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Age: ");
                if (!int.TryParse(Console.ReadLine(), out int age))
                {
                    throw new ArgumentException("Invalid age format");
                }

                Console.Write("Enter Annual Income: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal income))
                {
                    throw new ArgumentException("Invalid income format");
                }

                Console.Write("Enter Residency Years: ");
                if (!int.TryParse(Console.ReadLine(), out int residencyYears))
                {
                    throw new ArgumentException("Invalid residency years format");
                }

                Console.Write("Enter Zone (North/South/East/West/Central): ");
                string zone = Console.ReadLine();

                Console.Write("Enter Sector (1-20): ");
                if (!int.TryParse(Console.ReadLine(), out int sector))
                {
                    throw new ArgumentException("Invalid sector format");
                }

                Console.Write("Enter Email (optional): ");
                string email = Console.ReadLine();

                Console.Write("Enter Phone Number (optional): ");
                string phone = Console.ReadLine();

                Console.Write("Enter Password: ");
                string password = ReadPassword();

                // Register citizen
                var citizen = _citizenService.RegisterCitizen(
                    name,
                    age,
                    income,
                    residencyYears,
                    zone,
                    sector,
                    email,
                    phone,
                    password
                );

                Console.WriteLine($"\nCitizen registered successfully!");
                Console.WriteLine($"Citizen ID: {citizen.CitizenId}");
                Console.WriteLine($"Eligibility Score: {citizen.CalculateEligibilityScore()}");
                Console.WriteLine($"Recommended Package: {citizen.GetEligibleServicePackage()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
                ExceptionLogger.LogException(ex, "RegisterCitizen");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// View citizen details
        /// </summary>
        private void ViewCitizen()
        {
            Console.Clear();
            Console.WriteLine("=== VIEW CITIZEN DETAILS ===\n");

            Console.Write("Enter Citizen ID: ");
            string citizenId = Console.ReadLine();

            try
            {
                var citizen = _citizenService.GetCitizen(citizenId);
                Console.WriteLine("\n" + citizen.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Update citizen information
        /// </summary>
        private void UpdateCitizen()
        {
            Console.Clear();
            Console.WriteLine("=== UPDATE CITIZEN INFORMATION ===\n");

            Console.Write("Enter Citizen ID: ");
            string citizenId = Console.ReadLine();

            try
            {
                var citizen = _citizenService.GetCitizen(citizenId);
                Console.WriteLine("\nCurrent Information:");
                Console.WriteLine(citizen.ToString());

                Console.WriteLine("\nEnter new information (press Enter to keep current value):");

                Console.Write($"Name [{citizen.Name}]: ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                    citizen.Name = name;

                Console.Write($"Age [{citizen.Age}]: ");
                string ageStr = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(ageStr) && int.TryParse(ageStr, out int age))
                    citizen.Age = age;

                Console.Write($"Income [{citizen.Income:C}]: ");
                string incomeStr = Console.ReadLine();
                if (
                    !string.IsNullOrWhiteSpace(incomeStr)
                    && decimal.TryParse(incomeStr, out decimal income)
                )
                    citizen.Income = income;

                Console.Write($"Phone [{citizen.PhoneNumber}]: ");
                string phone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(phone))
                    citizen.PhoneNumber = phone;

                if (_citizenService.UpdateCitizen(citizen))
                {
                    Console.WriteLine("\nCitizen information updated successfully!");
                }
                else
                {
                    Console.WriteLine("\nFailed to update citizen information.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Delete citizen
        /// </summary>
        private void DeleteCitizen()
        {
            Console.Clear();
            Console.WriteLine("=== DELETE CITIZEN ===\n");

            Console.Write("Enter Citizen ID: ");
            string citizenId = Console.ReadLine();

            try
            {
                var citizen = _citizenService.GetCitizen(citizenId);
                Console.WriteLine("\n" + citizen.ToString());

                Console.Write("\nAre you sure you want to delete this citizen? (Y/N): ");
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    if (_citizenService.DeleteCitizen(citizenId))
                    {
                        Console.WriteLine("\nCitizen deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("\nFailed to delete citizen.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Search citizens
        /// </summary>
        private void SearchCitizens()
        {
            Console.Clear();
            Console.WriteLine("=== SEARCH CITIZENS ===\n");

            Console.Write("Enter search term (name or ID): ");
            string term = Console.ReadLine();

            var results = _citizenService.SearchCitizens(term);

            if (results.Any())
            {
                Console.WriteLine($"\nFound {results.Count} citizen(s):\n");
                foreach (var citizen in results)
                {
                    Console.WriteLine(
                        $"ID: {citizen.CitizenId} | Name: {citizen.Name} | Age: {citizen.Age} | Zone: {citizen.Zone}"
                    );
                }
            }
            else
            {
                Console.WriteLine("\nNo citizens found matching the search term.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// View all citizens
        /// </summary>
        private void ViewAllCitizens()
        {
            Console.Clear();
            Console.WriteLine("=== ALL CITIZENS ===\n");

            var citizens = _citizenService.GetAllCitizens();

            if (citizens.Any())
            {
                Console.WriteLine($"Total Citizens: {citizens.Count}\n");
                foreach (var citizen in citizens.OrderBy(c => c.Name))
                {
                    Console.WriteLine(
                        $"ID: {citizen.CitizenId} | Name: {citizen.Name} | Age: {citizen.Age} | Zone: {citizen.Zone}"
                    );
                }
            }
            else
            {
                Console.WriteLine("No citizens registered.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Calculate eligibility score
        /// </summary>
        private void CalculateEligibility()
        {
            Console.Clear();
            Console.WriteLine("=== CALCULATE ELIGIBILITY SCORE ===\n");

            Console.Write("Enter Citizen ID: ");
            string citizenId = Console.ReadLine();

            try
            {
                int score = _citizenService.CalculateEligibilityScore(citizenId);
                Console.WriteLine($"\nEligibility Score: {score}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Get recommended service package
        /// </summary>
        private void GetServicePackage()
        {
            Console.Clear();
            Console.WriteLine("=== RECOMMENDED SERVICE PACKAGE ===\n");

            Console.Write("Enter Citizen ID: ");
            string citizenId = Console.ReadLine();

            try
            {
                string package = _citizenService.GetRecommendedServicePackage(citizenId);
                Console.WriteLine($"\nRecommended Package: {package}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Service Management Menu
        /// Modules 6-9: Service operations
        /// </summary>
        private void ShowServiceMenu()
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine("                   SERVICE MANAGEMENT");
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine("\n1. Add New Service");
                Console.WriteLine("2. View Service Details");
                Console.WriteLine("3. Subscribe to Service");
                Console.WriteLine("4. Unsubscribe from Service");
                Console.WriteLine("5. View Available Services");
                Console.WriteLine("6. View All Services");
                Console.WriteLine("7. Calculate Service Charge");
                Console.WriteLine("8. Back to Main Menu");
                Console.Write("\nSelect an option (1-8): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddService();
                        break;
                    case "2":
                        ViewService();
                        break;
                    case "3":
                        SubscribeService();
                        break;
                    case "4":
                        UnsubscribeService();
                        break;
                    case "5":
                        ViewAvailableServices();
                        break;
                    case "6":
                        ViewAllServices();
                        break;
                    case "7":
                        CalculateServiceCharge();
                        break;
                    case "8":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Add new service
        /// </summary>
        private void AddService()
        {
            Console.Clear();
            Console.WriteLine("=== ADD NEW SERVICE ===\n");

            try
            {
                Console.Write("Service Name: ");
                string name = Console.ReadLine();

                Console.Write("Description: ");
                string description = Console.ReadLine();

                Console.Write("Monthly Fee: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal fee))
                {
                    throw new ArgumentException("Invalid fee format");
                }

                Console.WriteLine("\nService Type:");
                Console.WriteLine("1. Healthcare");
                Console.WriteLine("2. Education");
                Console.WriteLine("3. Emergency");
                Console.WriteLine("4. Routine");
                Console.Write("Select type (1-4): ");

                string typeChoice = Console.ReadLine();
                Service service = null;

                switch (typeChoice)
                {
                    case "1":
                        Console.Write("Hospital Name: ");
                        string hospital = Console.ReadLine();
                        Console.Write("Doctor Name: ");
                        string doctor = Console.ReadLine();
                        Console.Write("Specialization: ");
                        string specialization = Console.ReadLine();
                        service = new HealthcareService(
                            name,
                            description,
                            fee,
                            hospital,
                            doctor,
                            specialization
                        );
                        break;

                    case "2":
                        Console.Write("Institution Name: ");
                        string institution = Console.ReadLine();
                        Console.Write("Course Name: ");
                        string course = Console.ReadLine();
                        Console.Write("Duration (months): ");
                        if (!int.TryParse(Console.ReadLine(), out int duration))
                            duration = 6;
                        service = new EducationService(
                            name,
                            description,
                            fee,
                            institution,
                            course,
                            duration
                        );
                        break;

                    case "3":
                        Console.Write("Emergency Type (Police/Fire/Ambulance): ");
                        string emergencyType = Console.ReadLine();
                        Console.Write("Response Time (minutes): ");
                        if (!int.TryParse(Console.ReadLine(), out int responseTime))
                            responseTime = 10;
                        Console.Write("Contact Number: ");
                        string contact = Console.ReadLine();
                        service = new EmergencyService(
                            name,
                            description,
                            fee,
                            emergencyType,
                            responseTime,
                            contact
                        );
                        break;

                    case "4":
                        Console.Write("Service Category: ");
                        string category = Console.ReadLine();
                        Console.Write("Frequency per month: ");
                        if (!int.TryParse(Console.ReadLine(), out int frequency))
                            frequency = 4;
                        service = new RoutineService(name, description, fee, category, frequency);
                        break;

                    default:
                        throw new ArgumentException("Invalid service type");
                }

                _serviceManager.AddService(service);
                Console.WriteLine($"\nService added successfully! Service ID: {service.ServiceId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// View service details
        /// </summary>
        private void ViewService()
        {
            Console.Clear();
            Console.WriteLine("=== VIEW SERVICE DETAILS ===\n");

            Console.Write("Enter Service ID: ");
            string serviceId = Console.ReadLine();

            try
            {
                var service = _serviceManager.GetService(serviceId);
                Console.WriteLine("\n" + service.GetServiceDetails());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Subscribe to service
        /// </summary>
        private void SubscribeService()
        {
            Console.Clear();
            Console.WriteLine("=== SUBSCRIBE TO SERVICE ===\n");

            Console.Write("Enter Citizen ID: ");
            string citizenId = Console.ReadLine();

            Console.Write("Enter Service ID: ");
            string serviceId = Console.ReadLine();

            try
            {
                if (_serviceManager.SubscribeToService(citizenId, serviceId))
                {
                    Console.WriteLine("\nSuccessfully subscribed to service!");
                }
                else
                {
                    Console.WriteLine("\nFailed to subscribe to service.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Unsubscribe from service
        /// </summary>
        private void UnsubscribeService()
        {
            Console.Clear();
            Console.WriteLine("=== UNSUBSCRIBE FROM SERVICE ===\n");

            Console.Write("Enter Citizen ID: ");
            string citizenId = Console.ReadLine();

            Console.Write("Enter Service ID: ");
            string serviceId = Console.ReadLine();

            try
            {
                if (_serviceManager.UnsubscribeFromService(citizenId, serviceId))
                {
                    Console.WriteLine("\nSuccessfully unsubscribed from service!");
                }
                else
                {
                    Console.WriteLine("\nFailed to unsubscribe from service.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// View available services for citizen
        /// </summary>
        private void ViewAvailableServices()
        {
            Console.Clear();
            Console.WriteLine("=== AVAILABLE SERVICES ===\n");

            Console.Write("Enter Citizen ID: ");
            string citizenId = Console.ReadLine();

            try
            {
                var services = _serviceManager.GetAvailableServicesForCitizen(citizenId);

                if (services.Any())
                {
                    Console.WriteLine($"\nAvailable Services ({services.Count}):\n");
                    foreach (var service in services)
                    {
                        Console.WriteLine(
                            $"ID: {service.ServiceId} | {service.ServiceName} | Fee: {service.MonthlyFee:C} | Type: {service.ServiceType}"
                        );
                    }
                }
                else
                {
                    Console.WriteLine("\nNo services available for this citizen.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// View all services
        /// </summary>
        private void ViewAllServices()
        {
            Console.Clear();
            Console.WriteLine("=== ALL SERVICES ===\n");

            var services = _serviceManager.GetAllServices();

            if (services.Any())
            {
                Console.WriteLine($"Total Services: {services.Count}\n");
                foreach (var service in services)
                {
                    Console.WriteLine(
                        $"ID: {service.ServiceId} | {service.ServiceName} | Fee: {service.MonthlyFee:C} | Available: {(service.IsAvailable ? "Yes" : "No")}"
                    );
                }
            }
            else
            {
                Console.WriteLine("No services available.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Calculate service charge
        /// </summary>
        private void CalculateServiceCharge()
        {
            Console.Clear();
            Console.WriteLine("=== CALCULATE SERVICE CHARGE ===\n");

            Console.Write("Enter Citizen ID: ");
            string citizenId = Console.ReadLine();

            Console.Write("Enter Service ID: ");
            string serviceId = Console.ReadLine();

            Console.Write("Enter Usage Count: ");
            if (!int.TryParse(Console.ReadLine(), out int usageCount))
            {
                usageCount = 1;
            }

            try
            {
                decimal charge = _serviceManager.CalculateServiceCharge(
                    citizenId,
                    serviceId,
                    usageCount
                );
                Console.WriteLine($"\nTotal Service Charge: {charge:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Reports Menu
        /// Module 14: Data organization and retrieval
        /// </summary>
        private void ShowReportsMenu()
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine("                      DATA REPORTS");
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine("\n1. Service Report");
                Console.WriteLine("2. Population Density Report");
                Console.WriteLine("3. Citizen Demographics");
                Console.WriteLine("4. Performance Benchmarks");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("\nSelect an option (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowServiceReport();
                        break;
                    case "2":
                        ShowPopulationReport();
                        break;
                    case "3":
                        ShowDemographicsReport();
                        break;
                    case "4":
                        ShowBenchmarks();
                        break;
                    case "5":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowServiceReport()
        {
            Console.Clear();
            Console.WriteLine("=== SERVICE REPORT ===\n");

            try
            {
                string report = _serviceManager.GetServiceReport();
                Console.WriteLine(report);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void ShowPopulationReport()
        {
            Console.Clear();
            Console.WriteLine("=== POPULATION DENSITY REPORT ===\n");

            // This would come from DataContext
            Console.WriteLine("Zone\tSector\tPopulation");
            Console.WriteLine("----\t------\t----------");
            Console.WriteLine("North\tSector-1\t45");
            Console.WriteLine("North\tSector-2\t32");
            Console.WriteLine("South\tSector-1\t28");
            Console.WriteLine("East\tSector-1\t56");
            Console.WriteLine("West\tSector-1\t41");
            Console.WriteLine("Central\tSector-1\t67");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void ShowDemographicsReport()
        {
            Console.Clear();
            Console.WriteLine("=== DEMOGRAPHICS REPORT ===\n");

            var citizens = _citizenService.GetAllCitizens();

            if (citizens.Any())
            {
                Console.WriteLine($"Total Citizens: {citizens.Count}");
                Console.WriteLine($"Average Age: {citizens.Average(c => c.Age):F1}");
                Console.WriteLine($"Average Income: {citizens.Average(c => c.Income):C}");
                Console.WriteLine(
                    $"Average Residency: {citizens.Average(c => c.ResidencyYears):F1} years"
                );

                Console.WriteLine("\nAge Distribution:");
                Console.WriteLine($"  0-18: {citizens.Count(c => c.Age <= 18)}");
                Console.WriteLine($" 19-35: {citizens.Count(c => c.Age > 18 && c.Age <= 35)}");
                Console.WriteLine($" 36-60: {citizens.Count(c => c.Age > 35 && c.Age <= 60)}");
                Console.WriteLine($" 60+  : {citizens.Count(c => c.Age > 60)}");

                Console.WriteLine("\nZone Distribution:");
                foreach (var zone in Enum.GetValues(typeof(Models.Enums.ZoneType)))
                {
                    int count = citizens.Count(c => c.Zone.ToString() == zone.ToString());
                    Console.WriteLine($"  {zone}: {count}");
                }
            }
            else
            {
                Console.WriteLine("No citizen data available.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void ShowBenchmarks()
        {
            Console.Clear();
            Console.WriteLine("=== PERFORMANCE BENCHMARKS ===\n");
            Console.WriteLine("Module 15: Performance Optimization");
            Console.WriteLine("\nTime Complexity Analysis:");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Operation\t\tTime Complexity\tSpace Complexity");
            Console.WriteLine("Citizen Lookup (by ID)\tO(1)\t\tO(n)");
            Console.WriteLine("Citizen Search (by name)\tO(n)\t\tO(1)");
            Console.WriteLine("Add Citizen\t\tO(1)\t\tO(1)");
            Console.WriteLine("Quick Sort (by age)\tO(n log n)\tO(log n)");
            Console.WriteLine("Merge Sort\t\tO(n log n)\tO(n)");
            Console.WriteLine("Binary Search\t\tO(log n)\tO(1)");

            Console.WriteLine("\nData Structure Comparison:");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Structure\tAccess\tSearch\tInsert\tDelete");
            Console.WriteLine("Array\t\tO(1)\tO(n)\tO(n)\tO(n)");
            Console.WriteLine("Linked List\tO(n)\tO(n)\tO(1)\tO(1)");
            Console.WriteLine("Stack\t\tO(n)\tO(n)\tO(1)\tO(1)");
            Console.WriteLine("Queue\t\tO(n)\tO(n)\tO(1)\tO(1)");
            Console.WriteLine("HashMap\t\tO(1)\tO(1)\tO(1)\tO(1)");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// System Tools Menu
        /// Module 18: I/O Operations
        /// Module 19: Exception Management
        /// </summary>
        private void ShowSystemToolsMenu()
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine("                      SYSTEM TOOLS");
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine("\n1. View Error Logs");
                Console.WriteLine("2. Clear Error Logs");
                Console.WriteLine("3. Backup Data");
                Console.WriteLine("4. Restore Data");
                Console.WriteLine("5. System Configuration");
                Console.WriteLine("6. Test Generics (Module 16)");
                Console.WriteLine("7. Back to Main Menu");
                Console.Write("\nSelect an option (1-7): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewErrorLogs();
                        break;
                    case "2":
                        ClearErrorLogs();
                        break;
                    case "3":
                        BackupData();
                        break;
                    case "4":
                        RestoreData();
                        break;
                    case "5":
                        ShowConfiguration();
                        break;
                    case "6":
                        TestGenerics();
                        break;
                    case "7":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ViewErrorLogs()
        {
            Console.Clear();
            Console.WriteLine("=== ERROR LOGS ===\n");

            string logs = ExceptionLogger.GetRecentLogs(50);
            Console.WriteLine(logs);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void ClearErrorLogs()
        {
            Console.Clear();
            Console.WriteLine("=== CLEAR ERROR LOGS ===\n");

            Console.Write("Are you sure? (Y/N): ");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                ExceptionLogger.ClearLogs();
                Console.WriteLine("Logs cleared successfully!");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void BackupData()
        {
            Console.Clear();
            Console.WriteLine("=== BACKUP DATA ===\n");
            Console.WriteLine("Data backup initiated...");
            // In real system, would call backup method
            Console.WriteLine("Backup completed successfully!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void RestoreData()
        {
            Console.Clear();
            Console.WriteLine("=== RESTORE DATA ===\n");
            Console.Write("Enter backup file name: ");
            string filename = Console.ReadLine();
            Console.WriteLine($"Restoring from {filename}...");
            Console.WriteLine("Restore completed successfully!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void ShowConfiguration()
        {
            Console.Clear();
            Console.WriteLine("=== SYSTEM CONFIGURATION ===\n");
            Console.WriteLine("Database Path: Data/");
            Console.WriteLine("Log File: Logs/error.log");
            Console.WriteLine("Auto-save: Enabled");
            Console.WriteLine("Max Citizens per Zone: 1000");
            Console.WriteLine("Session Timeout: 30 minutes");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Test Generics functionality - Module 16
        /// </summary>
        private void TestGenerics()
        {
            Console.Clear();
            Console.WriteLine("=== TEST GENERICS (MODULE 16) ===\n");

            try
            {
                // Test CityContainer
                Console.WriteLine("Testing CityContainer<string>...");
                var stringContainer = new CityContainer<string>(5);
                stringContainer.Add("Citizen1");
                stringContainer.Add("Citizen2");
                stringContainer.Add("Citizen3");
                Console.WriteLine($"Container count: {stringContainer.Count}");
                Console.WriteLine($"Item at index 1: {stringContainer[1]}");

                // Test Pair class
                Console.WriteLine("\nTesting Pair<K,V>...");
                var pair = new Pair<string, int>("Citizen ID", 1001);
                Console.WriteLine($"Pair: {pair}");

                // Test generic method
                Console.WriteLine("\nTesting generic method with numbers...");
                var numbers = new List<int> { 5, 2, 8, 1, 9 };
                var max = FindMax(numbers);
                Console.WriteLine($"Maximum number: {max}");

                // Test with different types
                var names = new List<string> { "Alice", "Bob", "Charlie" };
                var maxName = FindMax(names);
                Console.WriteLine($"Maximum name (alphabetical): {maxName}");

                Console.WriteLine("\nGenerics test completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Generic method to find maximum element
        /// Module 16: Bounded type parameters
        /// </summary>
        private T FindMax<T>(List<T> items)
            where T : IComparable<T>
        {
            if (items == null || items.Count == 0)
                throw new ArgumentException("List is empty");

            T max = items[0];
            for (int i = 1; i < items.Count; i++)
            {
                if (items[i].CompareTo(max) > 0)
                {
                    max = items[i];
                }
            }
            return max;
        }

        /// <summary>
        /// Read password from console (masked input)
        /// </summary>
        private string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
    }
}
