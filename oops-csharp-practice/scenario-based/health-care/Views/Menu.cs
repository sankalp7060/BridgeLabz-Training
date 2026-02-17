using Interfaces;
using Models;

namespace Views
{
    /// <summary>
    /// Handles all console UI interactions.
    /// Contains NO business logic.
    /// </summary>
    public class Menu
    {
        private readonly IPatientService service;

        public Menu(IPatientService patientService)
        {
            service = patientService;
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n===== HealthCare OOP Menu =====");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. Show Patient");
                Console.WriteLine("3. Update Patient");
                Console.WriteLine("4. Search Patient");
                Console.WriteLine("5. Exit");

                Console.Write("Enter Choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterUI();
                        break;

                    case 2:
                        service.ShowPatient();
                        break;

                    case 3:
                        service.UpdatePatient();
                        break;

                    case 4:
                        Console.Write("Enter Patient ID: ");
                        int id = int.Parse(Console.ReadLine());
                        service.SearchPatient(id);
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void RegisterUI()
        {
            Patient p = new Patient();

            Console.Write("Patient ID: ");
            p.PatientId = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            p.Name = Console.ReadLine();

            Console.Write("DOB: ");
            p.DOB = Console.ReadLine();

            Console.Write("Phone: ");
            p.Phone = Console.ReadLine();

            Console.Write("Address: ");
            p.Address = Console.ReadLine();

            Console.Write("Blood Group: ");
            p.BloodGroup = Console.ReadLine();

            service.RegisterPatient(p);
        }
    }
}
