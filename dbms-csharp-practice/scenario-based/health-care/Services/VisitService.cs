using System;
using System.Collections.Generic;
using HealthCareClinicSystem.Interfaces;
using HealthCareClinicSystem.Models;

namespace HealthCareClinicSystem.Services
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public VisitService(
            IVisitRepository visitRepository,
            IAppointmentRepository appointmentRepository,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository
        )
        {
            _visitRepository = visitRepository;
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
        }

        public int RecordVisit(
            int appointmentId,
            string diagnosis,
            string notes,
            List<Prescription> prescriptions
        )
        {
            AuthService.CheckReceptionistAccess();

            var appointment = _appointmentRepository.GetAppointmentById(appointmentId);
            if (appointment == null)
                throw new ArgumentException("Appointment not found");

            if (appointment.Status == "CANCELLED")
                throw new InvalidOperationException(
                    "Cannot record visit for cancelled appointment"
                );

            if (appointment.Status == "COMPLETED")
                throw new InvalidOperationException("Visit already recorded for this appointment");

            var visit = new Visit
            {
                AppointmentId = appointmentId,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                VisitDate = DateTime.Now,
                Diagnosis = diagnosis,
                Notes = notes,
            };

            return _visitRepository.RecordVisit(visit, prescriptions);
        }

        public List<Visit> GetPatientMedicalHistory(int patientId)
        {
            AuthService.CheckReceptionistAccess();
            return _visitRepository.GetPatientMedicalHistory(patientId);
        }

        public Visit GetVisitById(int visitId)
        {
            AuthService.CheckReceptionistAccess();
            return _visitRepository.GetVisitById(visitId);
        }

        public List<Prescription> GetPrescriptionsByVisit(int visitId)
        {
            AuthService.CheckReceptionistAccess();
            return _visitRepository.GetPrescriptionsByVisit(visitId);
        }

        public void DisplayVisitDetails(int visitId)
        {
            AuthService.CheckReceptionistAccess();

            var visit = GetVisitById(visitId);
            if (visit == null)
            {
                Console.WriteLine("Visit not found.");
                return;
            }

            Console.WriteLine($"\nVisit Details (ID: {visit.VisitId})");
            Console.WriteLine("========================================");
            Console.WriteLine($"Patient: {visit.PatientName}");
            Console.WriteLine($"Doctor: {visit.DoctorName}");
            Console.WriteLine($"Date: {visit.VisitDate:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"Diagnosis: {visit.Diagnosis}");
            Console.WriteLine($"Notes: {visit.Notes}");

            var prescriptions = GetPrescriptionsByVisit(visitId);
            if (prescriptions.Count > 0)
            {
                Console.WriteLine("\nPrescriptions:");
                foreach (var prescription in prescriptions)
                {
                    Console.WriteLine(
                        $"  - {prescription.MedicineName} | {prescription.Dosage} | {prescription.Duration}"
                    );
                }
            }
        }
    }
}
