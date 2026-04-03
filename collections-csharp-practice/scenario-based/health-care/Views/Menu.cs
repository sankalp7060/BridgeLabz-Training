using System;
using Interfaces;
using Models;

namespace Views
{
    /// <summary>
    /// Console UI for multiple patient operations
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
                Console.WriteLine("\n===== HealthCare Collections Menu =====");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. Show All Patients");
                Console.WriteLine("3. Update Patient");
                Console.WriteLine("4. Search Patient by ID");
                Console.WriteLine("5. Search Patient by Name");
                Console.WriteLine("6. Show Patients Sorted by Name");
                Console.WriteLine("7. Count Patients");
                Console.WriteLine("8. Exit");

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
                        service.SearchPatientById(searchId);
                        break;

                    case 5:
                        Console.Write("Enter Name to Search: ");
                        string name = Console.ReadLine();
                        service.SearchPatientByName(name);
                        break;

                    case 6:
                        service.ShowPatientsSortedByName();
                        break;

                    case 7:
                        service.CountPatients();
                        break;

                    case 8:
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        /// <summary>
        /// UI method for registering a patient
        /// </summary>
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
