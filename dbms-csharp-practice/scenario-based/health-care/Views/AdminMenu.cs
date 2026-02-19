using System;
using HealthCareClinicSystem.Interfaces;
using HealthCareClinicSystem.Utilities;

namespace HealthCareClinicSystem.Views
{
    public class AdminMenu
    {
        private readonly IAdminService _adminService;

        public AdminMenu(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("        SYSTEM ADMINISTRATION");
                Console.WriteLine("========================================");
                Console.WriteLine("\n1. Manage Specialties");
                Console.WriteLine("2. View Audit Logs");
                Console.WriteLine("3. Perform Database Backup");
                Console.WriteLine("4. Back to Main Menu");
                Console.WriteLine("\n========================================");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageSpecialties();
                        break;
                    case "2":
                        ViewAuditLogs();
                        break;
                    case "3":
                        PerformBackup();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ManageSpecialties()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("        MANAGE SPECIALTIES");
                Console.WriteLine("========================================");
                Console.WriteLine("\n1. Add Specialty");
                Console.WriteLine("2. Update Specialty");
                Console.WriteLine("3. Delete Specialty");
                Console.WriteLine("4. View All Specialties");
                Console.WriteLine("5. Back to Admin Menu");
                Console.WriteLine("\n========================================");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddSpecialty();
                        break;
                    case "2":
                        UpdateSpecialty();
                        break;
                    case "3":
                        DeleteSpecialty();
                        break;
                    case "4":
                        _adminService.DisplayAllSpecialties();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddSpecialty()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        ADD SPECIALTY");
            Console.WriteLine("========================================");

            string name = InputValidator.GetValidString("Specialty Name: ");
            Console.Write("Description (optional): ");
            string description = Console.ReadLine();

            int specialtyId = _adminService.AddSpecialty(name, description);

            if (specialtyId > 0)
                Console.WriteLine($"\n✓ Specialty added successfully with ID: {specialtyId}");
            else
                Console.WriteLine("\n✗ Failed to add specialty.");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void UpdateSpecialty()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        UPDATE SPECIALTY");
            Console.WriteLine("========================================");

            _adminService.DisplayAllSpecialties();

            int specialtyId = InputValidator.GetValidInt("\nEnter Specialty ID to update: ", 1);

            Console.Write("New Specialty Name: ");
            string name = Console.ReadLine();

            Console.Write("New Description: ");
            string description = Console.ReadLine();

            if (_adminService.UpdateSpecialty(specialtyId, name, description))
                Console.WriteLine("\n✓ Specialty updated successfully!");
            else
                Console.WriteLine("\n✗ Failed to update specialty.");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void DeleteSpecialty()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        DELETE SPECIALTY");
            Console.WriteLine("========================================");

            _adminService.DisplayAllSpecialties();

            int specialtyId = InputValidator.GetValidInt("\nEnter Specialty ID to delete: ", 1);

            Console.Write($"\nAre you sure you want to delete specialty ID {specialtyId}? (Y/N): ");
            if (Console.ReadLine()?.ToUpper() == "Y")
            {
                if (_adminService.DeleteSpecialty(specialtyId))
                    Console.WriteLine("\n✓ Specialty deleted successfully!");
                else
                    Console.WriteLine(
                        "\n✗ Failed to delete specialty. It may be in use by doctors."
                    );
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void ViewAuditLogs()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        VIEW AUDIT LOGS");
            Console.WriteLine("========================================");

            Console.WriteLine("\nFilter Options (press Enter to skip):");
            Console.Write("Table Name (Patients, Doctors, Appointments, etc): ");
            string tableName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(tableName))
                tableName = null;

            Console.Write("Action Type (INSERT, UPDATE, DELETE): ");
            string actionType = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(actionType))
                actionType = null;

            _adminService.DisplayAuditLogs(tableName, actionType);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void PerformBackup()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        DATABASE BACKUP");
            Console.WriteLine("========================================");

            Console.Write("Enter backup directory path (e.g., C:\\Backup): ");
            string backupPath = Console.ReadLine();

            try
            {
                _adminService.PerformDatabaseBackup(backupPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Backup failed: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
