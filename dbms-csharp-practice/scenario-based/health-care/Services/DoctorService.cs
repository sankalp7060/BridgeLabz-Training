using System;
using System.Collections.Generic;
using HealthCareClinicSystem.Interfaces;
using HealthCareClinicSystem.Models;

namespace HealthCareClinicSystem.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public int AddDoctor(Doctor doctor)
        {
            AuthService.CheckAdminAccess();

            if (string.IsNullOrWhiteSpace(doctor.FullName))
                throw new ArgumentException("Doctor name is required");

            if (doctor.SpecialtyId <= 0)
                throw new ArgumentException("Valid specialty is required");

            if (doctor.ConsultationFee <= 0)
                throw new ArgumentException("Consultation fee must be greater than 0");

            return _doctorRepository.AddDoctor(doctor);
        }

        public bool UpdateDoctor(Doctor doctor)
        {
            AuthService.CheckAdminAccess();

            if (doctor.DoctorId <= 0)
                throw new ArgumentException("Invalid doctor ID");

            return _doctorRepository.UpdateDoctor(doctor);
        }

        public bool UpdateDoctorSpecialty(int doctorId, int specialtyId)
        {
            AuthService.CheckAdminAccess();
            return _doctorRepository.UpdateDoctorSpecialty(doctorId, specialtyId);
        }

        public bool DeactivateDoctor(int doctorId)
        {
            AuthService.CheckAdminAccess();
            return _doctorRepository.DeactivateDoctor(doctorId);
        }

        public Doctor GetDoctorById(int doctorId)
        {
            AuthService.CheckReceptionistAccess();
            return _doctorRepository.GetDoctorById(doctorId);
        }

        public List<Doctor> GetDoctorsBySpecialty(string specialtyName)
        {
            AuthService.CheckReceptionistAccess();
            return _doctorRepository.GetDoctorsBySpecialty(specialtyName);
        }

        public List<Doctor> GetAllActiveDoctors()
        {
            AuthService.CheckReceptionistAccess();
            return _doctorRepository.GetAllActiveDoctors();
        }

        public List<Specialty> GetAllSpecialties()
        {
            AuthService.CheckReceptionistAccess();
            return _doctorRepository.GetAllSpecialties();
        }

        public bool CanDeactivateDoctor(int doctorId)
        {
            AuthService.CheckAdminAccess();
            return !_doctorRepository.HasFutureAppointments(doctorId);
        }
    }
}
