using Models;
using Services;

namespace Views
{
    /// <summary>
    /// Console UI layer.
    /// Handles user interaction only.
    /// </summary>
    public class Menu
    {
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n===== TechVille OOP Menu =====");
                Console.WriteLine("1. Healthcare Service");
                Console.WriteLine("2. Education Service");
                Console.WriteLine("3. Exit");

                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 3)
                    return;

                Console.Write("Enter Citizen Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Age: ");
                int age = int.Parse(Console.ReadLine());

                Citizen citizen = new Citizen(name, age);
                ServiceRequest request = null;

                switch (choice)
                {
                    case 1:
                        request = new ServiceRequest(citizen, "Healthcare");
                        var healthService = new HealthcareService();
                        var manager1 = new ServiceManager(healthService);
                        manager1.Execute(request);
                        break;

                    case 2:
                        request = new ServiceRequest(citizen, "Education");
                        var eduService = new EducationService();
                        var manager2 = new ServiceManager(eduService);
                        manager2.Execute(request);
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                if (request != null)
                {
                    Console.WriteLine($"Service Status: {request.Status}");
                }
            }
        }
    }
}
