using System;
using System.Collections.Generic;
using System.Linq;
using TechVilleSmartCity.Data;
using TechVilleSmartCity.Models;
using TechVilleSmartCity.Utilities;

namespace TechVilleSmartCity.Business
{
    /// <summary>
    /// Service Manager Implementation
    /// Modules 6-9: Service business logic with polymorphism
    /// Module 7: Static members and instanceof equivalent
    /// </summary>
    public class ServiceManager : IServiceManager
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ICitizenRepository _citizenRepository;

        // Module 7: Static counter for total services
        private static int totalServiceRegistrations = 0;

        public ServiceManager(
            IServiceRepository serviceRepository,
            ICitizenRepository citizenRepository = null
        )
        {
            _serviceRepository =
                serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
            _citizenRepository = citizenRepository;
        }

        public ServiceManager(IServiceRepository serviceRepository)
        {
            _serviceRepository =
                serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
        }

        public void AddService(Service service)
        {
            try
            {
                if (service == null)
                    throw new ArgumentNullException(nameof(service));

                _serviceRepository.Add(service);
                Console.WriteLine($"Service {service.ServiceName} added successfully.");
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "ServiceManager.AddService");
                throw;
            }
        }

        public Service GetService(string serviceId)
        {
            try
            {
                var service = _serviceRepository.GetById(serviceId);
                if (service == null)
                    throw new ServiceNotAvailableException(
                        $"Service with ID {serviceId} not found"
                    );

                return service;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, $"ServiceManager.GetService({serviceId})");
                throw;
            }
        }

        public List<Service> GetAllServices()
        {
            try
            {
                return _serviceRepository.GetAll();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "ServiceManager.GetAllServices");
                throw;
            }
        }

        /// <summary>
        /// Subscribe citizen to a service
        /// Module 7: instanceof equivalent using pattern matching
        /// </summary>
        public bool SubscribeToService(string citizenId, string serviceId)
        {
            try
            {
                if (_citizenRepository == null)
                    throw new InvalidOperationException("Citizen repository not available");

                var citizen = _citizenRepository.GetById(citizenId);
                if (citizen == null)
                    throw new InvalidCitizenIDException($"Citizen with ID {citizenId} not found");

                var service = _serviceRepository.GetById(serviceId);
                if (service == null)
                    throw new ServiceNotAvailableException(
                        $"Service with ID {serviceId} not found"
                    );

                if (!service.IsAvailable)
                    throw new ServiceNotAvailableException(
                        $"Service {service.ServiceName} is not available"
                    );

                // Module 7: Type checking using pattern matching (C# equivalent of instanceof)
                if (service is EmergencyService emergency)
                {
                    Console.WriteLine(
                        $"EMERGENCY SERVICE: {emergency.EmergencyType} - Priority subscription"
                    );
                }

                // Check eligibility
                if (!service.IsEligible(citizen))
                {
                    throw new ServiceNotAvailableException(
                        $"Citizen is not eligible for {service.ServiceName}"
                    );
                }

                // Check if already subscribed
                if (citizen.SubscribedServices.Any(s => s.ServiceId == serviceId))
                {
                    throw new InvalidOperationException(
                        $"Citizen already subscribed to {service.ServiceName}"
                    );
                }

                // Subscribe
                citizen.SubscribedServices.Add(service);
                totalServiceRegistrations++;

                // Update citizen
                _citizenRepository.Update(citizen);

                return true;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(
                    ex,
                    $"ServiceManager.SubscribeToService({citizenId}, {serviceId})"
                );
                return false;
            }
        }

        public bool UnsubscribeFromService(string citizenId, string serviceId)
        {
            try
            {
                if (_citizenRepository == null)
                    throw new InvalidOperationException("Citizen repository not available");

                var citizen = _citizenRepository.GetById(citizenId);
                if (citizen == null)
                    throw new InvalidCitizenIDException($"Citizen with ID {citizenId} not found");

                var service = citizen.SubscribedServices.FirstOrDefault(s =>
                    s.ServiceId == serviceId
                );
                if (service == null)
                    throw new InvalidOperationException(
                        $"Citizen is not subscribed to service {serviceId}"
                    );

                citizen.SubscribedServices.Remove(service);
                _citizenRepository.Update(citizen);

                return true;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(
                    ex,
                    $"ServiceManager.UnsubscribeFromService({citizenId}, {serviceId})"
                );
                return false;
            }
        }

        public decimal CalculateServiceCharge(string citizenId, string serviceId, int usageCount)
        {
            try
            {
                if (_citizenRepository == null)
                    throw new InvalidOperationException("Citizen repository not available");

                var citizen = _citizenRepository.GetById(citizenId);
                if (citizen == null)
                    throw new InvalidCitizenIDException($"Citizen with ID {citizenId} not found");

                var service = citizen.SubscribedServices.FirstOrDefault(s =>
                    s.ServiceId == serviceId
                );
                if (service == null)
                    throw new InvalidOperationException(
                        $"Citizen is not subscribed to service {serviceId}"
                    );

                // Module 8: Polymorphic method call
                return service.CalculateServiceCharge(usageCount);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(
                    ex,
                    $"ServiceManager.CalculateServiceCharge({citizenId}, {serviceId})"
                );
                throw;
            }
        }

        public List<Service> GetAvailableServicesForCitizen(string citizenId)
        {
            try
            {
                if (_citizenRepository == null)
                    throw new InvalidOperationException("Citizen repository not available");

                var citizen = _citizenRepository.GetById(citizenId);
                if (citizen == null)
                    throw new InvalidCitizenIDException($"Citizen with ID {citizenId} not found");

                var allServices = _serviceRepository.GetAvailableServices();
                return allServices.Where(s => s.IsEligible(citizen)).ToList();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(
                    ex,
                    $"ServiceManager.GetAvailableServicesForCitizen({citizenId})"
                );
                throw;
            }
        }

        /// <summary>
        /// Generate service report
        /// Module 14: Merge sort for report generation
        /// </summary>
        public string GetServiceReport()
        {
            try
            {
                var services = _serviceRepository.GetAll();
                var report = new System.Text.StringBuilder();

                report.AppendLine("\n=== TechVille Service Report ===");
                report.AppendLine($"Total Services: {services.Count}");
                report.AppendLine($"Total Registrations: {totalServiceRegistrations}");
                report.AppendLine("\nServices by Type:");

                // Group by service type
                var grouped = services.GroupBy(s => s.ServiceType);

                foreach (var group in grouped)
                {
                    report.AppendLine($"\n{group.Key}:");
                    report.AppendLine($"  Count: {group.Count()}");
                    report.AppendLine($"  Available: {group.Count(s => s.IsAvailable)}");

                    // Module 14: Merge sort for alphabetical ordering
                    var sorted = MergeSort(group.ToList());
                    foreach (var service in sorted.Take(5)) // Show top 5
                    {
                        report.AppendLine(
                            $"  - {service.ServiceName} (Fee: {service.MonthlyFee:C})"
                        );
                    }
                }

                return report.ToString();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "ServiceManager.GetServiceReport");
                throw;
            }
        }

        /// <summary>
        /// Module 14: Merge sort implementation
        /// </summary>
        private List<Service> MergeSort(List<Service> services)
        {
            if (services.Count <= 1)
                return services;

            int mid = services.Count / 2;
            var left = MergeSort(services.Take(mid).ToList());
            var right = MergeSort(services.Skip(mid).ToList());

            return Merge(left, right);
        }

        private List<Service> Merge(List<Service> left, List<Service> right)
        {
            var result = new List<Service>();
            int i = 0,
                j = 0;

            while (i < left.Count && j < right.Count)
            {
                if (string.Compare(left[i].ServiceName, right[j].ServiceName) <= 0)
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }

            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }

            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }

            return result;
        }
    }
}
