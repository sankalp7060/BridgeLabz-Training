using System;
using HealthCareClinicSystem.Interfaces;
using HealthCareClinicSystem.Repositories;
using HealthCareClinicSystem.Services;

namespace HealthCareClinicSystem.Views
{
    public class MainMenu
    {
        private readonly PatientMenu _patientMenu;
        private readonly DoctorMenu _doctorMenu;
        private readonly AppointmentMenu _appointmentMenu;
        private readonly VisitMenu _visitMenu;
        private readonly BillingMenu _billingMenu;
        private readonly AdminMenu _adminMenu;

        public MainMenu()
        {
            IPatientRepository patientRepo = new PatientRepository();
            IDoctorRepository doctorRepo = new DoctorRepository();
            IAppointmentRepository appointmentRepo = new AppointmentRepository();
            IVisitRepository visitRepo = new VisitRepository();
            IBillingRepository billingRepo = new BillingRepository();
            IAdminRepository adminRepo = new AdminRepository();

            IPatientService patientService = new PatientService(patientRepo);
            IDoctorService doctorService = new DoctorService(doctorRepo);
            IAppointmentService appointmentService = new AppointmentService(
                appointmentRepo,
                doctorRepo
            );
            IVisitService visitService = new VisitService(
                visitRepo,
                appointmentRepo,
                doctorRepo,
                patientRepo
            );
            IBillingService billingService = new BillingService(billingRepo, doctorRepo);
            IAdminService adminService = new AdminService(adminRepo);

            _patientMenu = new PatientMenu(patientService);
            _doctorMenu = new DoctorMenu(doctorService);
            _appointmentMenu = new AppointmentMenu(
                appointmentService,
                patientService,
                doctorService
            );
            _visitMenu = new VisitMenu(visitService, patientService, doctorService);
            _billingMenu = new BillingMenu(billingService, visitService);
            _adminMenu = new AdminMenu(adminService);
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("   HEALTHCARE CLINIC MANAGEMENT SYSTEM");
                Console.WriteLine("========================================");
                Console.WriteLine("\n1. Patient Management");
                Console.WriteLine("2. Doctor Management");
                Console.WriteLine("3. Appointment Scheduling");
                Console.WriteLine("4. Visit & Medical Records");
                Console.WriteLine("5. Billing & Payments");
                Console.WriteLine("6. System Administration");
                Console.WriteLine("7. Exit");
                Console.WriteLine("\n========================================");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _patientMenu.Show();
                        break;
                    case "2":
                        _doctorMenu.Show();
                        break;
                    case "3":
                        _appointmentMenu.Show();
                        break;
                    case "4":
                        _visitMenu.Show();
                        break;
                    case "5":
                        _billingMenu.Show();
                        break;
                    case "6":
                        _adminMenu.Show();
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
