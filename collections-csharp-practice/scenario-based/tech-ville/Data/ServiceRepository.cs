using System;
using System.Collections.Generic;
using System.Linq;
using TechVilleSmartCity.Models;
using TechVilleSmartCity.Utilities;

namespace TechVilleSmartCity.Data
{
    /// <summary>
    /// Service Repository Implementation
    /// </summary>
    public class ServiceRepository : IServiceRepository
    {
        private readonly DataContext _context;

        public ServiceRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Service GetById(string serviceId)
        {
            return _context.Services.FirstOrDefault(s => s.ServiceId == serviceId);
        }

        public List<Service> GetAll()
        {
            return _context.Services.ToList();
        }

        public void Add(Service service)
        {
            try
            {
                if (service == null)
                    throw new ArgumentNullException(nameof(service));

                if (Exists(service.ServiceId))
                    throw new InvalidOperationException(
                        $"Service with ID {service.ServiceId} already exists"
                    );

                _context.Services.Add(service);
                _context.SaveData();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "ServiceRepository.Add");
                throw;
            }
        }

        public void Update(Service service)
        {
            try
            {
                var existing = GetById(service.ServiceId);
                if (existing == null)
                    throw new InvalidOperationException(
                        $"Service with ID {service.ServiceId} not found"
                    );

                int index = _context.Services.FindIndex(s => s.ServiceId == service.ServiceId);
                _context.Services[index] = service;

                _context.SaveData();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "ServiceRepository.Update");
                throw;
            }
        }

        public void Delete(string serviceId)
        {
            try
            {
                var service = GetById(serviceId);
                if (service == null)
                    throw new InvalidOperationException($"Service with ID {serviceId} not found");

                _context.Services.Remove(service);
                _context.SaveData();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "ServiceRepository.Delete");
                throw;
            }
        }

        public List<Service> GetByType(string serviceType)
        {
            return _context
                .Services.Where(s =>
                    s.ServiceType.ToString().Equals(serviceType, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();
        }

        public List<Service> GetAvailableServices()
        {
            return _context.Services.Where(s => s.IsAvailable).ToList();
        }

        public bool Exists(string serviceId)
        {
            return _context.Services.Any(s => s.ServiceId == serviceId);
        }
    }
}
