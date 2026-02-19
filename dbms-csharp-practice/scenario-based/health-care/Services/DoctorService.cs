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
            if (doctor.DoctorId <= 0)
                throw new ArgumentException("Invalid doctor ID");

            return _doctorRepository.UpdateDoctor(doctor);
        }

        public bool UpdateDoctorSpecialty(int doctorId, int specialtyId)
        {
            return _doctorRepository.UpdateDoctorSpecialty(doctorId, specialtyId);
        }

        public bool DeactivateDoctor(int doctorId)
        {
            return _doctorRepository.DeactivateDoctor(doctorId);
        }

        public Doctor GetDoctorById(int doctorId)
        {
            return _doctorRepository.GetDoctorById(doctorId);
        }

        public List<Doctor> GetDoctorsBySpecialty(string specialtyName)
        {
            return _doctorRepository.GetDoctorsBySpecialty(specialtyName);
        }

        public List<Doctor> GetAllActiveDoctors()
        {
            return _doctorRepository.GetAllActiveDoctors();
        }

        public List<Specialty> GetAllSpecialties()
        {
            return _doctorRepository.GetAllSpecialties();
        }

        public bool CanDeactivateDoctor(int doctorId)
        {
            return !_doctorRepository.HasFutureAppointments(doctorId);
        }
    }
}
