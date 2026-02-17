using System;
using Interfaces;
using Models;

namespace Views
{
    /// <summary>
    /// Console UI for DBMS-backed patient operations
    /// </summary>
    public class Menu
    {
        private readonly IPatientService service;

        public Menu(IPatientService patientService)
        {
            service = patientService;
        }

        /// <summary>
        /// Main menu loop
        /// </summary>
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n===== HealthCare DBMS Menu =====");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. Show All Patients");
                Console.WriteLine("3. Update Patient");
                Console.WriteLine("4. Search Patient by ID");
                Console.WriteLine("5. Search Patient by Name");
                Console.WriteLine("6. Exit");

                Console.Write("Enter Choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterUI();
                        break;

                    case 2:
                        service.ShowAllPatients();
                        break;

                    case 3:
                        Console.Write("Enter Patient ID to Update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        service.UpdatePatient(updateId);
                        break;

                    case 4:
                        Console.Write("Enter Patient ID to Search: ");
                        int searchId = int.Parse(Console.ReadLine());
                        service.ShowPatientById(searchId);
                        break;

                    case 5:
                        Console.Write("Enter Name to Search: ");
                        string name = Console.ReadLine();
                        service.SearchPatientByName(name);
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        /// <summary>
        /// UI method to register patient
        /// </summary>
        private void RegisterUI()
        {
            Patient p = new Patient();

            Console.Write("Full Name: ");
            p.FullName = Console.ReadLine();

            Console.Write("DOB (yyyy-mm-dd): ");
            p.DOB = Console.ReadLine();

            Console.Write("Gender (M/F): ");
            p.Gender = Console.ReadLine();

            Console.Write("Phone: ");
            p.Phone = Console.ReadLine();

            Console.Write("Email: ");
            p.Email = Console.ReadLine();

            Console.Write("Address: ");
            p.Address = Console.ReadLine();

            Console.Write("Blood Group: ");
            p.BloodGroup = Console.ReadLine();

            service.RegisterPatient(p);
        }
    }
}
