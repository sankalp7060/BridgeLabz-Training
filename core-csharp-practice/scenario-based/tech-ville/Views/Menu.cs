using Interfaces;
using Models;

namespace Views
{
    /// <summary>
    /// Console UI layer.
    ///
    /// RESPONSIBILITY:
    /// - Take user input
    /// - Display menus
    /// - Call service layer
    ///
    /// NO BUSINESS LOGIC HERE.
    /// </summary>
    public class Menu
    {
        // Service dependency (interface type)
        private readonly ICitizenService service;

        // Constructor injection
        public Menu(ICitizenService citizenService)
        {
            service = citizenService;
        }

        /// <summary>
        /// Displays main menu continuously.
        /// </summary>
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n===== TechVille Core Menu =====");
                Console.WriteLine("1. Register Citizen");
                Console.WriteLine("2. View Citizen Details");
                Console.WriteLine("3. Register Family Members");
                Console.WriteLine("4. Exit");

                Console.Write("Enter Choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterCitizenUI();
                        break;

                    case 2:
                        service.ShowCitizen();
                        break;

                    case 3:
                        service.RegisterFamilyMembers();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        /// <summary>
        /// Collects citizen input from console.
        /// </summary>
        private void RegisterCitizenUI()
        {
            Citizen c = new Citizen();

            Console.Write("Name: ");
            c.Name = Console.ReadLine();

            Console.Write("Age: ");
            c.Age = int.Parse(Console.ReadLine());

            Console.Write("Income: ");
            c.Income = double.Parse(Console.ReadLine());

            Console.Write("Residency Years: ");
            c.ResidencyYears = int.Parse(Console.ReadLine());

            service.RegisterCitizen(c);
        }
    }
}
