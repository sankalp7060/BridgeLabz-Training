using System;
using System.Collections.Generic;
using HealthCareClinicSystem.Interfaces;
using HealthCareClinicSystem.Models;

namespace HealthCareClinicSystem.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;

        public AppointmentService(
            IAppointmentRepository appointmentRepository,
            IDoctorRepository doctorRepository
        )
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
        }

        public int BookAppointment(int patientId, int doctorId, DateTime date, TimeSpan time)
        {
            if (date < DateTime.Today)
                throw new ArgumentException("Appointment date cannot be in the past");

            if (!IsValidAppointmentTime(time))
                throw new ArgumentException("Appointment time must be between 9 AM and 5 PM");

            var appointment = new Appointment
            {
                PatientId = patientId,
                DoctorId = doctorId,
                AppointmentDate = date,
                AppointmentTime = time,
                Status = "SCHEDULED",
            };

            return _appointmentRepository.BookAppointment(appointment);
        }

        public bool CheckDoctorAvailability(int doctorId, DateTime date, TimeSpan time)
        {
            return _appointmentRepository.CheckDoctorAvailability(doctorId, date, time);
        }

        public void DisplayDoctorAvailability(int doctorId, DateTime date)
        {
            var doctor = _doctorRepository.GetDoctorById(doctorId);
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            Console.WriteLine($"\nAvailability for Dr. {doctor.FullName} on {date:yyyy-MM-dd}");
            Console.WriteLine("========================================");

            var slotAvailability = _appointmentRepository.GetDoctorSlotAvailability(
                doctorId,
                date,
                1
            );

            for (int hour = 9; hour <= 17; hour++)
            {
                TimeSpan slot = TimeSpan.FromHours(hour);
                bool isAvailable =
                    !slotAvailability.ContainsKey(slot) || slotAvailability[slot] == 0;

                string status = isAvailable ? "✓ Available" : "✗ Booked";
                Console.WriteLine($"{slot:hh\\:mm} - {status}");
            }
        }

        public bool CancelAppointment(int appointmentId, string remarks)
        {
            return _appointmentRepository.CancelAppointment(appointmentId, remarks);
        }

        public bool RescheduleAppointment(
            int appointmentId,
            DateTime newDate,
            TimeSpan newTime,
            int? newDoctorId
        )
        {
            return _appointmentRepository.RescheduleAppointment(
                appointmentId,
                newDate,
                newTime,
                newDoctorId
            );
        }

        public List<Appointment> GetDailyAppointmentSchedule(DateTime date)
        {
            return _appointmentRepository.GetDailyAppointmentSchedule(date);
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            return _appointmentRepository.GetAppointmentById(appointmentId);
        }

        private bool IsValidAppointmentTime(TimeSpan time)
        {
            return time >= TimeSpan.FromHours(9) && time <= TimeSpan.FromHours(17);
        }
    }
}
