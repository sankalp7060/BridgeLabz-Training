using System;
using HealthCareClinicSystem.Services;

namespace HealthCareClinicSystem.Views
{
    public class LoginMenu
    {
        public bool Show()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("   HEALTHCARE CLINIC MANAGEMENT SYSTEM");
            Console.WriteLine("========================================");
            Console.WriteLine("\nLOGIN");
            Console.WriteLine("========================================");

            Console.WriteLine("\nSelect Role:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Receptionist");
            Console.Write("\nEnter choice (1 or 2): ");

            string roleChoice = Console.ReadLine();
            string role =
                roleChoice == "1" ? "admin"
                : roleChoice == "2" ? "receptionist"
                : "";

            if (string.IsNullOrEmpty(role))
            {
                Console.WriteLine("\nInvalid role selection!");
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
                return false;
            }

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            bool loginSuccess = AuthService.Login(role, password);

            if (loginSuccess)
            {
                Console.WriteLine($"\n✓ Login successful! Welcome, {AuthService.CurrentUserRole}!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("\n✗ Invalid credentials for Admin!");
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
                return false;
            }
        }
    }
}
