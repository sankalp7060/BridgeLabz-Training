using System;
using System.Collections.Generic;
using HealthCareClinicSystem.Interfaces;
using HealthCareClinicSystem.Models;

namespace HealthCareClinicSystem.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public int RegisterPatient(Patient patient)
        {
            AuthService.CheckReceptionistAccess();

            if (string.IsNullOrWhiteSpace(patient.FullName))
                throw new ArgumentException("Patient name is required");

            if (patient.DOB > DateTime.Today)
                throw new ArgumentException("Date of birth cannot be in the future");

            if (string.IsNullOrWhiteSpace(patient.Phone))
                throw new ArgumentException("Phone number is required");

            if (_patientRepository.PatientExists(patient.Phone, patient.Email))
                return 0;

            return _patientRepository.RegisterPatient(patient);
        }

        public bool UpdatePatient(Patient patient)
        {
            AuthService.CheckReceptionistAccess();

            if (patient.PatientId <= 0)
                throw new ArgumentException("Invalid patient ID");

            return _patientRepository.UpdatePatient(patient);
        }

        public Patient GetPatientById(int patientId)
        {
            AuthService.CheckReceptionistAccess();
            return _patientRepository.GetPatientById(patientId);
        }

        public Patient GetPatientByPhone(string phone)
        {
            AuthService.CheckReceptionistAccess();
            return _patientRepository.GetPatientByPhone(phone);
        }

        public List<Patient> SearchPatients(string searchTerm)
        {
            AuthService.CheckReceptionistAccess();

            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<Patient>();

            return _patientRepository.SearchPatients(searchTerm);
        }

        public List<Visit> GetPatientVisitHistory(int patientId)
        {
            AuthService.CheckReceptionistAccess();
            return _patientRepository.GetPatientVisitHistory(patientId);
        }

        public List<Prescription> GetPrescriptionsByVisit(int visitId)
        {
            AuthService.CheckReceptionistAccess();
            return new List<Prescription>();
        }
    }
}
