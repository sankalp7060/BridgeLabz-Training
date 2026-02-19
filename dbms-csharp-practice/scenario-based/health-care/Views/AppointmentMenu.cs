using System;
using System.Linq;
using HealthCareClinicSystem.Interfaces;
using HealthCareClinicSystem.Models;
using HealthCareClinicSystem.Utilities;

namespace HealthCareClinicSystem.Views
{
    public class AppointmentMenu
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public AppointmentMenu(
            IAppointmentService appointmentService,
            IPatientService patientService,
            IDoctorService doctorService
        )
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("        APPOINTMENT SCHEDULING");
                Console.WriteLine("========================================");
                Console.WriteLine("\n1. Book New Appointment");
                Console.WriteLine("2. Check Doctor Availability");
                Console.WriteLine("3. Cancel Appointment");
                Console.WriteLine("4. Reschedule Appointment");
                Console.WriteLine("5. View Daily Appointment Schedule");
                Console.WriteLine("6. Back to Main Menu");
                Console.WriteLine("\n========================================");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BookAppointment();
                        break;
                    case "2":
                        CheckAvailability();
                        break;
                    case "3":
                        CancelAppointment();
                        break;
                    case "4":
                        RescheduleAppointment();
                        break;
                    case "5":
                        ViewDailySchedule();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void BookAppointment()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        BOOK NEW APPOINTMENT");
            Console.WriteLine("========================================");

            Console.Write("Enter Patient Phone: ");
            string phone = Console.ReadLine();
            var patient = _patientService.GetPatientByPhone(phone);

            if (patient == null)
            {
                Console.WriteLine("\nPatient not found. Please register the patient first.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\nPatient: {patient.FullName}");

            var doctors = _doctorService.GetAllActiveDoctors();
            if (doctors.Count == 0)
            {
                Console.WriteLine("\nNo active doctors available.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nAvailable Doctors:");
            foreach (var doctor in doctors)
                Console.WriteLine(
                    $"{doctor.DoctorId}. Dr. {doctor.FullName} - {doctor.SpecialtyName}"
                );

            int doctorId = InputValidator.GetValidInt("\nSelect Doctor ID: ", 1);

            DateTime appointmentDate = InputValidator.GetValidDate(
                "Enter Appointment Date (yyyy-mm-dd): "
            );
            TimeSpan appointmentTime = InputValidator.GetValidTime(
                "Enter Appointment Time (HH:mm, 9 AM - 5 PM): "
            );

            if (
                !_appointmentService.CheckDoctorAvailability(
                    doctorId,
                    appointmentDate,
                    appointmentTime
                )
            )
            {
                Console.WriteLine(
                    "\n✗ This time slot is not available. Please choose another time."
                );
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            int appointmentId = _appointmentService.BookAppointment(
                patient.PatientId,
                doctorId,
                appointmentDate,
                appointmentTime
            );

            if (appointmentId > 0)
            {
                Console.WriteLine($"\n✓ Appointment booked successfully!");
                Console.WriteLine($"Appointment ID: {appointmentId}");
                Console.WriteLine(
                    $"Date: {appointmentDate:yyyy-MM-dd} at {appointmentTime:hh\\:mm}"
                );
            }
            else
                Console.WriteLine("\n✗ Failed to book appointment.");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void CheckAvailability()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        CHECK DOCTOR AVAILABILITY");
            Console.WriteLine("========================================");

            var doctors = _doctorService.GetAllActiveDoctors();
            if (doctors.Count == 0)
            {
                Console.WriteLine("\nNo active doctors available.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nAvailable Doctors:");
            foreach (var doctor in doctors)
                Console.WriteLine(
                    $"{doctor.DoctorId}. Dr. {doctor.FullName} - {doctor.SpecialtyName}"
                );

            int doctorId = InputValidator.GetValidInt("\nSelect Doctor ID: ", 1);
            DateTime date = InputValidator.GetValidDate("Enter Date to Check (yyyy-mm-dd): ");

            _appointmentService.DisplayDoctorAvailability(doctorId, date);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void CancelAppointment()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        CANCEL APPOINTMENT");
            Console.WriteLine("========================================");

            int appointmentId = InputValidator.GetValidInt("Enter Appointment ID: ", 1);

            var appointment = _appointmentService.GetAppointmentById(appointmentId);
            if (appointment == null)
            {
                Console.WriteLine("\nAppointment not found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\nAppointment Details:");
            Console.WriteLine($"Patient: {appointment.PatientName}");
            Console.WriteLine($"Doctor: Dr. {appointment.DoctorName}");
            Console.WriteLine(
                $"Date: {appointment.AppointmentDate:yyyy-MM-dd} at {appointment.AppointmentTime:hh\\:mm}"
            );
            Console.WriteLine($"Status: {appointment.Status}");

            if (appointment.Status == "CANCELLED")
            {
                Console.WriteLine("\nThis appointment is already cancelled.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.Write("\nEnter cancellation reason: ");
            string remarks = Console.ReadLine();

            Console.Write("\nAre you sure you want to cancel this appointment? (Y/N): ");
            if (Console.ReadLine()?.ToUpper() == "Y")
            {
                if (_appointmentService.CancelAppointment(appointmentId, remarks))
                    Console.WriteLine("\n✓ Appointment cancelled successfully!");
                else
                    Console.WriteLine("\n✗ Failed to cancel appointment.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void RescheduleAppointment()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        RESCHEDULE APPOINTMENT");
            Console.WriteLine("========================================");

            int appointmentId = InputValidator.GetValidInt("Enter Appointment ID: ", 1);

            var appointment = _appointmentService.GetAppointmentById(appointmentId);
            if (appointment == null)
            {
                Console.WriteLine("\nAppointment not found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\nCurrent Appointment Details:");
            Console.WriteLine($"Patient: {appointment.PatientName}");
            Console.WriteLine($"Doctor: Dr. {appointment.DoctorName}");
            Console.WriteLine(
                $"Date: {appointment.AppointmentDate:yyyy-MM-dd} at {appointment.AppointmentTime:hh\\:mm}"
            );
            Console.WriteLine($"Status: {appointment.Status}");

            if (appointment.Status == "CANCELLED" || appointment.Status == "COMPLETED")
            {
                Console.WriteLine(
                    $"\nCannot reschedule {appointment.Status.ToLower()} appointment."
                );
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.Write("\nDo you want to change the doctor? (Y/N): ");
            int? newDoctorId = null;
            if (Console.ReadLine()?.ToUpper() == "Y")
            {
                var doctors = _doctorService.GetAllActiveDoctors();
                Console.WriteLine("\nAvailable Doctors:");
                foreach (var doctor in doctors)
                    Console.WriteLine(
                        $"{doctor.DoctorId}. Dr. {doctor.FullName} - {doctor.SpecialtyName}"
                    );
                newDoctorId = InputValidator.GetValidInt("Select New Doctor ID: ", 1);
            }

            DateTime newDate = InputValidator.GetValidDate("Enter New Date (yyyy-mm-dd): ");
            TimeSpan newTime = InputValidator.GetValidTime("Enter New Time (HH:mm, 9 AM - 5 PM): ");

            if (
                _appointmentService.RescheduleAppointment(
                    appointmentId,
                    newDate,
                    newTime,
                    newDoctorId
                )
            )
                Console.WriteLine("\n✓ Appointment rescheduled successfully!");
            else
                Console.WriteLine(
                    "\n✗ Failed to reschedule appointment. The new time slot may not be available."
                );

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void ViewDailySchedule()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        DAILY APPOINTMENT SCHEDULE");
            Console.WriteLine("========================================");

            DateTime date = InputValidator.GetValidDate("Enter Date (yyyy-mm-dd): ");

            var appointments = _appointmentService.GetDailyAppointmentSchedule(date);

            if (appointments.Count == 0)
                Console.WriteLine($"\nNo appointments scheduled for {date:yyyy-MM-dd}");
            else
            {
                Console.WriteLine($"\nAppointments for {date:yyyy-MM-dd}:");
                Console.WriteLine("========================================");
                foreach (var appointment in appointments.OrderBy(a => a.AppointmentTime))
                {
                    Console.WriteLine($"Time: {appointment.AppointmentTime:hh\\:mm}");
                    Console.WriteLine($"Patient: {appointment.PatientName}");
                    Console.WriteLine($"Doctor: Dr. {appointment.DoctorName}");
                    Console.WriteLine($"Status: {appointment.Status}");
                    Console.WriteLine("------------------------");
                }
                Console.WriteLine($"Total Appointments: {appointments.Count}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
