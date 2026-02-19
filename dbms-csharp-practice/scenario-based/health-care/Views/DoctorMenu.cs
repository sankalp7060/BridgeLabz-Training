using System;
using System.Collections.Generic;
using HealthCareClinicSystem.Interfaces;
using HealthCareClinicSystem.Models;
using HealthCareClinicSystem.Services;
using HealthCareClinicSystem.Utilities;

namespace HealthCareClinicSystem.Views
{
    public class DoctorMenu
    {
        private readonly IDoctorService _doctorService;

        public DoctorMenu(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public void Show()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("========================================");
                    Console.WriteLine("        DOCTOR MANAGEMENT");
                    Console.WriteLine("========================================");

                    if (AuthService.IsAdmin())
                    {
                        // Admin - Full CRUD
                        Console.WriteLine("\n1. Add Doctor Profile");
                        Console.WriteLine("2. Update Doctor Information");
                        Console.WriteLine("3. Assign/Update Doctor Specialty");
                        Console.WriteLine("4. View Doctors by Specialty");
                        Console.WriteLine("5. Deactivate Doctor Profile");
                        Console.WriteLine("6. Back to Main Menu");
                    }
                    else
                    {
                        // Receptionist - View Only
                        Console.WriteLine("\n1. View Doctors by Specialty");
                        Console.WriteLine("2. Back to Main Menu");
                    }

                    Console.WriteLine("\n========================================");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();

                    if (AuthService.IsAdmin())
                    {
                        switch (choice)
                        {
                            case "1":
                                AddDoctor();
                                break;
                            case "2":
                                UpdateDoctor();
                                break;
                            case "3":
                                UpdateDoctorSpecialty();
                                break;
                            case "4":
                                ViewDoctorsBySpecialty();
                                break;
                            case "5":
                                DeactivateDoctor();
                                break;
                            case "6":
                                return;
                            default:
                                Console.WriteLine("Invalid option. Press any key...");
                                Console.ReadKey();
                                break;
                        }
                    }
                    else
                    {
                        switch (choice)
                        {
                            case "1":
                                ViewDoctorsBySpecialty();
                                break;
                            case "2":
                                return;
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
            }
        }

        private void AddDoctor()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        ADD DOCTOR PROFILE");
            Console.WriteLine("========================================");

            var specialties = _doctorService.GetAllSpecialties();
            if (specialties.Count == 0)
            {
                Console.WriteLine("\nNo specialties available. Please add specialties first.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Doctor doctor = new Doctor();
            doctor.FullName = InputValidator.GetValidString("Full Name: ");

            Console.WriteLine("\nAvailable Specialties:");
            foreach (var specialty in specialties)
                Console.WriteLine($"{specialty.SpecialtyId}. {specialty.SpecialtyName}");

            doctor.SpecialtyId = InputValidator.GetValidInt("Select Specialty ID: ", 1);
            doctor.Phone = InputValidator.GetValidString("Phone: ");
            doctor.Email = InputValidator.GetValidString("Email: ");
            doctor.ConsultationFee = InputValidator.GetValidDecimal("Consultation Fee: $", 0);

            int doctorId = _doctorService.AddDoctor(doctor);

            if (doctorId > 0)
                Console.WriteLine($"\n✓ Doctor added successfully with ID: {doctorId}");
            else
                Console.WriteLine("\n✗ Failed to add doctor.");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void UpdateDoctor()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        UPDATE DOCTOR INFORMATION");
            Console.WriteLine("========================================");

            int doctorId = InputValidator.GetValidInt("Enter Doctor ID: ", 1);

            var doctor = _doctorService.GetDoctorById(doctorId);
            if (doctor == null)
            {
                Console.WriteLine("\nDoctor not found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nCurrent Doctor Details:");
            DisplayDoctorDetails(doctor);

            Console.WriteLine("\nEnter new details (press Enter to keep current value):");

            Doctor updatedDoctor = new Doctor { DoctorId = doctorId };

            Console.Write($"Full Name [{doctor.FullName}]: ");
            string input = Console.ReadLine();
            updatedDoctor.FullName = string.IsNullOrWhiteSpace(input) ? doctor.FullName : input;

            Console.Write($"Phone [{doctor.Phone}]: ");
            input = Console.ReadLine();
            updatedDoctor.Phone = string.IsNullOrWhiteSpace(input) ? doctor.Phone : input;

            Console.Write($"Email [{doctor.Email}]: ");
            input = Console.ReadLine();
            updatedDoctor.Email = string.IsNullOrWhiteSpace(input) ? doctor.Email : input;

            Console.Write($"Consultation Fee [{doctor.ConsultationFee}]: $");
            input = Console.ReadLine();
            updatedDoctor.ConsultationFee = string.IsNullOrWhiteSpace(input)
                ? doctor.ConsultationFee
                : decimal.Parse(input);

            if (_doctorService.UpdateDoctor(updatedDoctor))
                Console.WriteLine("\n✓ Doctor information updated successfully!");
            else
                Console.WriteLine("\n✗ Failed to update doctor information.");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void UpdateDoctorSpecialty()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        UPDATE DOCTOR SPECIALTY");
            Console.WriteLine("========================================");

            int doctorId = InputValidator.GetValidInt("Enter Doctor ID: ", 1);

            var doctor = _doctorService.GetDoctorById(doctorId);
            if (doctor == null)
            {
                Console.WriteLine("\nDoctor not found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\nCurrent Specialty: {doctor.SpecialtyName}");

            var specialties = _doctorService.GetAllSpecialties();
            Console.WriteLine("\nAvailable Specialties:");
            foreach (var specialty in specialties)
                Console.WriteLine($"{specialty.SpecialtyId}. {specialty.SpecialtyName}");

            int newSpecialtyId = InputValidator.GetValidInt("Select New Specialty ID: ", 1);

            if (_doctorService.UpdateDoctorSpecialty(doctorId, newSpecialtyId))
                Console.WriteLine("\n✓ Doctor specialty updated successfully!");
            else
                Console.WriteLine("\n✗ Failed to update doctor specialty.");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void ViewDoctorsBySpecialty()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        VIEW DOCTORS BY SPECIALTY");
            Console.WriteLine("========================================");

            string specialtyName = InputValidator.GetValidString("Enter Specialty Name: ");

            var doctors = _doctorService.GetDoctorsBySpecialty(specialtyName);

            if (doctors.Count == 0)
                Console.WriteLine($"\nNo doctors found for specialty: {specialtyName}");
            else
            {
                Console.WriteLine($"\nDoctors in {specialtyName}:");
                Console.WriteLine("========================================");
                foreach (var doctor in doctors)
                {
                    Console.WriteLine($"ID: {doctor.DoctorId}");
                    Console.WriteLine($"Name: Dr. {doctor.FullName}");
                    Console.WriteLine($"Phone: {doctor.Phone}");
                    Console.WriteLine($"Email: {doctor.Email}");
                    Console.WriteLine($"Fee: ${doctor.ConsultationFee}");
                    Console.WriteLine("------------------------");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void DeactivateDoctor()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        DEACTIVATE DOCTOR PROFILE");
            Console.WriteLine("========================================");

            int doctorId = InputValidator.GetValidInt("Enter Doctor ID: ", 1);

            var doctor = _doctorService.GetDoctorById(doctorId);
            if (doctor == null)
            {
                Console.WriteLine("\nDoctor not found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            DisplayDoctorDetails(doctor);

            if (!_doctorService.CanDeactivateDoctor(doctorId))
            {
                Console.WriteLine(
                    "\nCannot deactivate doctor. There are future appointments scheduled."
                );
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.Write("\nAre you sure you want to deactivate this doctor? (Y/N): ");
            if (Console.ReadLine()?.ToUpper() == "Y")
            {
                if (_doctorService.DeactivateDoctor(doctorId))
                    Console.WriteLine("\n✓ Doctor deactivated successfully!");
                else
                    Console.WriteLine("\n✗ Failed to deactivate doctor.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void DisplayDoctorDetails(Doctor doctor)
        {
            Console.WriteLine($"\nID: {doctor.DoctorId}");
            Console.WriteLine($"Name: Dr. {doctor.FullName}");
            Console.WriteLine($"Specialty: {doctor.SpecialtyName}");
            Console.WriteLine($"Phone: {doctor.Phone}");
            Console.WriteLine($"Email: {doctor.Email}");
            Console.WriteLine($"Fee: ${doctor.ConsultationFee}");
            Console.WriteLine($"Status: {(doctor.IsActive ? "Active" : "Inactive")}");
        }
    }
}
