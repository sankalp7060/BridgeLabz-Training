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
        private readonly LoginMenu _loginMenu;

        // Make services available at class level
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;
        private readonly IVisitService _visitService;
        private readonly IBillingService _billingService;
        private readonly IAdminService _adminService;

        public MainMenu()
        {
            // Initialize repositories
            IPatientRepository patientRepo = new PatientRepository();
            IDoctorRepository doctorRepo = new DoctorRepository();
            IAppointmentRepository appointmentRepo = new AppointmentRepository();
            IVisitRepository visitRepo = new VisitRepository();
            IBillingRepository billingRepo = new BillingRepository();
            IAdminRepository adminRepo = new AdminRepository();

            // Initialize services and store them
            _patientService = new PatientService(patientRepo);
            _doctorService = new DoctorService(doctorRepo);
            _appointmentService = new AppointmentService(appointmentRepo, doctorRepo);
            _visitService = new VisitService(visitRepo, appointmentRepo, doctorRepo, patientRepo);
            _billingService = new BillingService(billingRepo, doctorRepo);
            _adminService = new AdminService(adminRepo);

            // Initialize menus with services
            _patientMenu = new PatientMenu(_patientService);
            _doctorMenu = new DoctorMenu(_doctorService);
            _appointmentMenu = new AppointmentMenu(
                _appointmentService,
                _patientService,
                _doctorService
            );
            _visitMenu = new VisitMenu(_visitService, _patientService, _doctorService);
            _billingMenu = new BillingMenu(_billingService, _visitService);
            _adminMenu = new AdminMenu(_adminService);
            _loginMenu = new LoginMenu();
        }

        public void Show()
        {
            // Login first
            while (!AuthService.IsAuthenticated)
            {
                if (!_loginMenu.Show())
                {
                    Console.WriteLine("\nDo you want to exit? (Y/N): ");
                    if (Console.ReadLine()?.ToUpper() == "Y")
                        Environment.Exit(0);
                }
            }

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("========================================");
                    Console.WriteLine("   HEALTHCARE CLINIC MANAGEMENT SYSTEM");
                    Console.WriteLine("========================================");
                    Console.WriteLine($"Logged in as: {AuthService.CurrentUserRole}");
                    Console.WriteLine("========================================");

                    if (AuthService.IsAdmin())
                    {
                        // Admin Menu - No Appointment Scheduling
                        Console.WriteLine("\n1. Patient Management");
                        Console.WriteLine("2. Doctor Management");
                        Console.WriteLine("3. Visit & Medical Records");
                        Console.WriteLine("4. Billing & Payments");
                        Console.WriteLine("5. System Administration");
                        Console.WriteLine("6. Logout");
                        Console.WriteLine("7. Exit");
                    }
                    else
                    {
                        // Receptionist Menu - Full Access to Appointments
                        Console.WriteLine("\n1. Patient Management");
                        Console.WriteLine("2. View Doctors");
                        Console.WriteLine("3. Appointment Scheduling");
                        Console.WriteLine("4. Visit & Medical Records");
                        Console.WriteLine("5. Billing & Payments");
                        Console.WriteLine("6. Logout");
                        Console.WriteLine("7. Exit");
                    }

                    Console.WriteLine("\n========================================");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();

                    if (AuthService.IsAdmin())
                    {
                        // Admin Menu Handling - No Appointment option
                        switch (choice)
                        {
                            case "1":
                                _patientMenu.Show();
                                break;
                            case "2":
                                _doctorMenu.Show();
                                break;
                            case "3":
                                _visitMenu.Show();
                                break;
                            case "4":
                                _billingMenu.Show();
                                break;
                            case "5":
                                _adminMenu.Show();
                                break;
                            case "6":
                                AuthService.Logout();
                                Console.WriteLine("Logged out successfully!");
                                Console.WriteLine("Press any key to return to login...");
                                Console.ReadKey();
                                Show(); // Return to login
                                return;
                            case "7":
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid option. Press any key...");
                                Console.ReadKey();
                                break;
                        }
                    }
                    else
                    {
                        // Receptionist Menu Handling - Includes Appointment Scheduling
                        switch (choice)
                        {
                            case "1":
                                _patientMenu.Show();
                                break;
                            case "2":
                                // View Doctors Only (No Add/Update/Delete)
                                Console.Clear();
                                Console.WriteLine("========================================");
                                Console.WriteLine("        VIEW DOCTORS");
                                Console.WriteLine("========================================");
                                var doctors = _doctorService.GetAllActiveDoctors();
                                foreach (var doc in doctors)
                                {
                                    Console.WriteLine($"Dr. {doc.FullName} - {doc.SpecialtyName}");
                                    Console.WriteLine($"Phone: {doc.Phone}");
                                    Console.WriteLine($"Fee: ${doc.ConsultationFee}");
                                    Console.WriteLine("------------------------");
                                }
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
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
                                AuthService.Logout();
                                Console.WriteLine("Logged out successfully!");
                                Console.WriteLine("Press any key to return to login...");
                                Console.ReadKey();
                                Show(); // Return to login
                                return;
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
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine($"\n✗ Access Denied: {ex.Message}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n✗ Error: {ex.Message}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
