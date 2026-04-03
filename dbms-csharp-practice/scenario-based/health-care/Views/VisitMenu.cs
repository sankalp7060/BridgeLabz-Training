using System;
using System.Collections.Generic;
using HealthCareClinicSystem.Interfaces;
using HealthCareClinicSystem.Models;
using HealthCareClinicSystem.Utilities;

namespace HealthCareClinicSystem.Views
{
    public class VisitMenu
    {
        private readonly IVisitService _visitService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public VisitMenu(
            IVisitService visitService,
            IPatientService patientService,
            IDoctorService doctorService
        )
        {
            _visitService = visitService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("        VISIT & MEDICAL RECORDS");
                Console.WriteLine("========================================");
                Console.WriteLine("\n1. Record Patient Visit");
                Console.WriteLine("2. View Patient Medical History");
                Console.WriteLine("3. Add Prescription Details");
                Console.WriteLine("4. View Visit Details");
                Console.WriteLine("5. Back to Main Menu");
                Console.WriteLine("\n========================================");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RecordVisit();
                        break;
                    case "2":
                        ViewMedicalHistory();
                        break;
                    case "3":
                        AddPrescriptions();
                        break;
                    case "4":
                        ViewVisitDetails();
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

        private void RecordVisit()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        RECORD PATIENT VISIT");
            Console.WriteLine("========================================");

            int appointmentId = InputValidator.GetValidInt("Enter Appointment ID: ", 1);

            Console.Write("Diagnosis: ");
            string diagnosis = Console.ReadLine();

            Console.Write("Notes: ");
            string notes = Console.ReadLine();

            List<Prescription> prescriptions = new List<Prescription>();
            Console.WriteLine("\nAdd Prescriptions (press Enter to skip):");

            while (true)
            {
                Console.Write("\nMedicine Name (or Enter to finish): ");
                string medicineName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(medicineName))
                    break;

                Prescription prescription = new Prescription();
                prescription.MedicineName = medicineName;
                Console.Write("Dosage: ");
                prescription.Dosage = Console.ReadLine();
                Console.Write("Duration: ");
                prescription.Duration = Console.ReadLine();

                prescriptions.Add(prescription);
            }

            int visitId = _visitService.RecordVisit(appointmentId, diagnosis, notes, prescriptions);

            if (visitId > 0)
                Console.WriteLine($"\n✓ Visit recorded successfully with ID: {visitId}");
            else
                Console.WriteLine("\n✗ Failed to record visit.");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void ViewMedicalHistory()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        VIEW PATIENT MEDICAL HISTORY");
            Console.WriteLine("========================================");

            int patientId = InputValidator.GetValidInt("Enter Patient ID: ", 1);

            var patient = _patientService.GetPatientById(patientId);
            if (patient == null)
            {
                Console.WriteLine("\nPatient not found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            var visits = _visitService.GetPatientMedicalHistory(patientId);

            if (visits.Count == 0)
                Console.WriteLine($"\nNo medical history found for {patient.FullName}");
            else
            {
                Console.WriteLine($"\nMedical History for {patient.FullName}:");
                Console.WriteLine("========================================");
                foreach (var visit in visits)
                {
                    Console.WriteLine($"Visit Date: {visit.VisitDate:yyyy-MM-dd HH:mm}");
                    Console.WriteLine($"Doctor: Dr. {visit.DoctorName}");
                    Console.WriteLine($"Diagnosis: {visit.Diagnosis}");
                    Console.WriteLine($"Notes: {visit.Notes}");

                    var prescriptions = _visitService.GetPrescriptionsByVisit(visit.VisitId);
                    if (prescriptions.Count > 0)
                    {
                        Console.WriteLine("Prescriptions:");
                        foreach (var prescription in prescriptions)
                            Console.WriteLine(
                                $"  - {prescription.MedicineName} | {prescription.Dosage} | {prescription.Duration}"
                            );
                    }
                    Console.WriteLine("------------------------");
                }
                Console.WriteLine($"Total Visits: {visits.Count}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void AddPrescriptions()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        ADD PRESCRIPTION DETAILS");
            Console.WriteLine("========================================");

            int visitId = InputValidator.GetValidInt("Enter Visit ID: ", 1);

            var visit = _visitService.GetVisitById(visitId);
            if (visit == null)
            {
                Console.WriteLine("\nVisit not found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\nVisit Date: {visit.VisitDate:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"Patient: {visit.PatientName}");
            Console.WriteLine($"Doctor: Dr. {visit.DoctorName}");
            Console.WriteLine($"Diagnosis: {visit.Diagnosis}");

            List<Prescription> prescriptions = new List<Prescription>();
            Console.WriteLine("\nAdd Prescriptions:");

            while (true)
            {
                Console.Write("\nMedicine Name (or Enter to finish): ");
                string medicineName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(medicineName))
                    break;

                Prescription prescription = new Prescription();
                prescription.MedicineName = medicineName;
                Console.Write("Dosage: ");
                prescription.Dosage = Console.ReadLine();
                Console.Write("Duration: ");
                prescription.Duration = Console.ReadLine();

                prescriptions.Add(prescription);
            }

            Console.WriteLine("\n✓ Prescriptions added successfully!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void ViewVisitDetails()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        VIEW VISIT DETAILS");
            Console.WriteLine("========================================");

            int visitId = InputValidator.GetValidInt("Enter Visit ID: ", 1);
            _visitService.DisplayVisitDetails(visitId);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
