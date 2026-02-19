using System;
using System.Collections.Generic;
using HealthCareClinicSystem.Interfaces;
using HealthCareClinicSystem.Models;

namespace HealthCareClinicSystem.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public int AddSpecialty(string specialtyName, string description)
        {
            if (string.IsNullOrWhiteSpace(specialtyName))
                throw new ArgumentException("Specialty name is required");

            var specialty = new Specialty
            {
                SpecialtyName = specialtyName,
                Description = description,
            };

            return _adminRepository.AddSpecialty(specialty);
        }

        public bool UpdateSpecialty(int specialtyId, string specialtyName, string description)
        {
            var specialty = new Specialty
            {
                SpecialtyId = specialtyId,
                SpecialtyName = specialtyName,
                Description = description,
            };

            return _adminRepository.UpdateSpecialty(specialty);
        }

        public bool DeleteSpecialty(int specialtyId)
        {
            return _adminRepository.DeleteSpecialty(specialtyId);
        }

        public List<Specialty> GetAllSpecialties()
        {
            return _adminRepository.GetAllSpecialties();
        }

        public void DisplayAllSpecialties()
        {
            var specialties = GetAllSpecialties();

            if (specialties.Count == 0)
            {
                Console.WriteLine("\nNo specialties found.");
                return;
            }

            Console.WriteLine("\nAvailable Specialties:");
            Console.WriteLine("========================================");
            foreach (var specialty in specialties)
            {
                Console.WriteLine($"ID: {specialty.SpecialtyId}");
                Console.WriteLine($"Name: {specialty.SpecialtyName}");
                if (!string.IsNullOrEmpty(specialty.Description))
                    Console.WriteLine($"Description: {specialty.Description}");
                Console.WriteLine("------------------------");
            }
        }

        public List<AuditLog> GetAuditLogs(string tableName = null, string actionType = null)
        {
            return _adminRepository.GetAuditLogs(tableName, actionType);
        }

        public void DisplayAuditLogs(string tableName = null, string actionType = null)
        {
            var logs = GetAuditLogs(tableName, actionType);

            if (logs.Count == 0)
            {
                Console.WriteLine("\nNo audit logs found.");
                return;
            }

            Console.WriteLine("\nAudit Logs:");
            Console.WriteLine("========================================");
            foreach (var log in logs)
            {
                Console.WriteLine($"Date: {log.ActionDate:yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine($"Table: {log.TableName}");
                Console.WriteLine($"Action: {log.ActionType}");
                Console.WriteLine($"Record ID: {log.RecordId}");
                if (!string.IsNullOrEmpty(log.PerformedBy))
                    Console.WriteLine($"User: {log.PerformedBy}");
                Console.WriteLine("------------------------");
            }
        }

        public void PerformDatabaseBackup(string backupPath)
        {
            _adminRepository.PerformDatabaseBackup(backupPath);
            Console.WriteLine($"Database backup completed successfully at: {backupPath}");
        }
    }
}
