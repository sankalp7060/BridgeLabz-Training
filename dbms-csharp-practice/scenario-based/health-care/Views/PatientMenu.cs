using System;
using System.Collections.Generic;
using System.Linq;
using HealthCareClinicSystem.Interfaces;
using HealthCareClinicSystem.Models;
using HealthCareClinicSystem.Utilities;

namespace HealthCareClinicSystem.Views
{
    public class PatientMenu
    {
        private readonly IPatientService _patientService;

        public PatientMenu(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("        PATIENT MANAGEMENT");
                Console.WriteLine("========================================");
                Console.WriteLine("\n1. Register New Patient");
                Console.WriteLine("2. Update Patient Information");
                Console.WriteLine("3. Search Patient Records");
                Console.WriteLine("4. View Patient Visit History");
                Console.WriteLine("5. Back to Main Menu");
                Console.WriteLine("\n========================================");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterPatient();
                        break;
                    case "2":
                        UpdatePatient();
                        break;
                    case "3":
                        SearchPatients();
                        break;
                    case "4":
                        ViewPatientHistory();
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

        private void RegisterPatient()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        REGISTER NEW PATIENT");
            Console.WriteLine("========================================");

            Patient patient = new Patient();
            patient.FullName = InputValidator.GetValidString("Full Name: ");
            patient.DOB = InputValidator.GetValidDate("Date of Birth (yyyy-mm-dd): ", false);
            patient.Gender = InputValidator.GetValidString("Gender (M/F/O): ").ToUpper();

            do
            {
                patient.Phone = InputValidator.GetValidString("Phone (10 digits): ");
                if (!InputValidator.IsValidPhone(patient.Phone))
                    Console.WriteLine("Invalid phone number. Please enter 10 digits.");
            } while (!InputValidator.IsValidPhone(patient.Phone));

            do
            {
                patient.Email = InputValidator.GetValidString("Email: ");
                if (!InputValidator.IsValidEmail(patient.Email))
                    Console.WriteLine("Invalid email format. Please try again.");
            } while (!InputValidator.IsValidEmail(patient.Email));

            patient.Address = InputValidator.GetValidString("Address: ");
            patient.BloodGroup = InputValidator.GetValidString("Blood Group (A+, B+, O+, etc): ");

            int patientId = _patientService.RegisterPatient(patient);

            if (patientId > 0)
                Console.WriteLine($"\n✓ Patient registered successfully with ID: {patientId}");
            else
                Console.WriteLine(
                    "\n✗ Failed to register patient. Phone or email may already exist."
                );

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void UpdatePatient()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        UPDATE PATIENT INFORMATION");
            Console.WriteLine("========================================");

            Console.Write("Enter Patient ID or Phone: ");
            string searchTerm = Console.ReadLine();

            Patient patient = null;
            if (int.TryParse(searchTerm, out int patientId))
                patient = _patientService.GetPatientById(patientId);
            else
                patient = _patientService.GetPatientByPhone(searchTerm);

            if (patient == null)
            {
                Console.WriteLine("\nPatient not found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nCurrent Patient Details:");
            DisplayPatientDetails(patient);

            Console.WriteLine("\nEnter new details (press Enter to keep current value):");

            Patient updatedPatient = new Patient { PatientId = patient.PatientId };

            Console.Write($"Full Name [{patient.FullName}]: ");
            string input = Console.ReadLine();
            updatedPatient.FullName = string.IsNullOrWhiteSpace(input) ? patient.FullName : input;

            Console.Write($"DOB [{patient.DOB:yyyy-MM-dd}]: ");
            input = Console.ReadLine();
            updatedPatient.DOB = string.IsNullOrWhiteSpace(input)
                ? patient.DOB
                : DateTime.Parse(input);

            Console.Write($"Gender [{patient.Gender}]: ");
            input = Console.ReadLine();
            updatedPatient.Gender = string.IsNullOrWhiteSpace(input)
                ? patient.Gender
                : input.ToUpper();

            Console.Write($"Phone [{patient.Phone}]: ");
            input = Console.ReadLine();
            updatedPatient.Phone = string.IsNullOrWhiteSpace(input) ? patient.Phone : input;

            Console.Write($"Email [{patient.Email}]: ");
            input = Console.ReadLine();
            updatedPatient.Email = string.IsNullOrWhiteSpace(input) ? patient.Email : input;

            Console.Write($"Address [{patient.Address}]: ");
            input = Console.ReadLine();
            updatedPatient.Address = string.IsNullOrWhiteSpace(input) ? patient.Address : input;

            Console.Write($"Blood Group [{patient.BloodGroup}]: ");
            input = Console.ReadLine();
            updatedPatient.BloodGroup = string.IsNullOrWhiteSpace(input)
                ? patient.BloodGroup
                : input;

            if (_patientService.UpdatePatient(updatedPatient))
                Console.WriteLine("\n✓ Patient information updated successfully!");
            else
                Console.WriteLine("\n✗ Failed to update patient information.");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void SearchPatients()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        SEARCH PATIENT RECORDS");
            Console.WriteLine("========================================");

            Console.Write("Enter Name, Phone, or ID to search: ");
            string searchTerm = Console.ReadLine();

            var patients = _patientService.SearchPatients(searchTerm);

            if (patients.Count == 0)
                Console.WriteLine("\nNo patients found.");
            else
            {
                Console.WriteLine($"\nFound {patients.Count} patient(s):\n");
                foreach (var patient in patients)
                {
                    Console.WriteLine($"ID: {patient.PatientId}");
                    Console.WriteLine($"Name: {patient.FullName}");
                    Console.WriteLine($"Phone: {patient.Phone}");
                    Console.WriteLine($"Email: {patient.Email}");
                    Console.WriteLine($"Age: {patient.Age}");
                    Console.WriteLine($"Blood Group: {patient.BloodGroup}");
                    Console.WriteLine("------------------------");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void ViewPatientHistory()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        VIEW PATIENT VISIT HISTORY");
            Console.WriteLine("========================================");

            Console.Write("Enter Patient ID: ");
            if (!int.TryParse(Console.ReadLine(), out int patientId))
            {
                Console.WriteLine("Invalid ID.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            var visits = _patientService.GetPatientVisitHistory(patientId);

            if (visits.Count == 0)
                Console.WriteLine("\nNo visit history found for this patient.");
            else
            {
                Patient patient = _patientService.GetPatientById(patientId);
                Console.WriteLine($"\nVisit History for: {patient.FullName}");
                Console.WriteLine($"Total Visits: {visits.Count}\n");

                foreach (var visit in visits)
                {
                    Console.WriteLine($"Visit Date: {visit.VisitDate:yyyy-MM-dd HH:mm}");
                    Console.WriteLine($"Doctor: {visit.DoctorName}");
                    Console.WriteLine($"Diagnosis: {visit.Diagnosis}");
                    Console.WriteLine($"Notes: {visit.Notes}");

                    var prescriptions = _patientService.GetPrescriptionsByVisit(visit.VisitId);
                    if (prescriptions.Any())
                    {
                        Console.WriteLine("Prescriptions:");
                        foreach (var prescription in prescriptions)
                        {
                            Console.WriteLine(
                                $"  - {prescription.MedicineName} | {prescription.Dosage} | {prescription.Duration}"
                            );
                        }
                    }
                    Console.WriteLine("------------------------");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void DisplayPatientDetails(Patient patient)
        {
            Console.WriteLine($"ID: {patient.PatientId}");
            Console.WriteLine($"Name: {patient.FullName}");
            Console.WriteLine($"DOB: {patient.DOB:yyyy-MM-dd}");
            Console.WriteLine($"Gender: {patient.Gender}");
            Console.WriteLine($"Phone: {patient.Phone}");
            Console.WriteLine($"Email: {patient.Email}");
            Console.WriteLine($"Address: {patient.Address}");
            Console.WriteLine($"Blood Group: {patient.BloodGroup}");
        }
    }
}
