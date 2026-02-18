using Interfaces;
using Models;

namespace Views
{
    /// <summary>
    /// Console user interface.
    /// Handles user interaction only.
    /// </summary>
    public class Menu
    {
        private readonly ICitizenManager manager;

        public Menu(ICitizenManager manager)
        {
            this.manager = manager;
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n===== TechVille Collections Menu =====");
                Console.WriteLine("1 Register Citizen");
                Console.WriteLine("2 View All Citizens");
                Console.WriteLine("3 Search By City");
                Console.WriteLine("4 Sort By Name");
                Console.WriteLine("5 Add Service Request");
                Console.WriteLine("6 Process Next Request");
                Console.WriteLine("7 Undo Last Registration");
                Console.WriteLine("8 Count By City");
                Console.WriteLine("9 Exit");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 9)
                    return;

                switch (choice)
                {
                    case 1:
                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("City: ");
                        string city = Console.ReadLine();

                        Console.Write("Age: ");
                        int age = int.Parse(Console.ReadLine());

                        manager.RegisterCitizen(new Citizen(name, city, age));
                        break;

                    case 2:
                        manager.ViewAllCitizens();
                        break;

                    case 3:
                        Console.Write("Enter City: ");
                        manager.SearchByCity(Console.ReadLine());
                        break;

                    case 4:
                        manager.SortByName();
                        break;

                    case 5:
                        Console.Write("Citizen ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Service Type: ");
                        string type = Console.ReadLine();

                        // Simple lookup via temporary search
                        manager.AddToServiceQueue(
                            new ServiceRequest(new Citizen("Temp", "Temp", 0), type)
                        );
                        break;

                    case 6:
                        manager.ProcessNextRequest();
                        break;

                    case 7:
                        manager.UndoLastRegistration();
                        break;

                    case 8:
                        manager.CountByCity();
                        break;
                }
            }
        }
    }
}
