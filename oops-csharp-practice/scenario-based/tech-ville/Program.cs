using System;
using TechVille.OOPS.Models;
using TechVille.OOPS.Services;
using TechVille.OOPS.Views;

namespace TechVille.OOPS
{
    class Program
    {
        static void Main()
        {
            // Creating Citizen object
            Citizen citizen = new Citizen("Sankalp", 22, 101);
            citizen.Display();

            ConsoleView view = new ConsoleView();
            view.ShowMenu();

            int choice = Convert.ToInt32(Console.ReadLine());

            // Factory pattern usage
            Service service = ServiceFactory.CreateService(choice);

            if (service != null)
            {
                service.BookService();
                service.ExecuteService();
                service.TrackStatus();

                // instanceof equivalent in C#
                if (service is EmergencyService)
                {
                    Console.WriteLine("Priority handling confirmed.");
                }
            }

            Console.WriteLine($"\nTotal Citizens: {Citizen.TotalCitizens}");
            Console.WriteLine($"Total Services Created: {Service.TotalServices}");
        }
    }
}
