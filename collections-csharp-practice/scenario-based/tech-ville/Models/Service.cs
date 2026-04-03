using System;
using System.Collections.Generic;
using TechVilleSmartCity.Models.Enums;

namespace TechVilleSmartCity.Models
{
    /// <summary>
    /// Base Service class for all city services
    /// Module 6: OOP Basics
    /// Module 7: Advanced OOP
    /// Module 8: Inheritance
    /// Module 9: Abstract classes
    /// </summary>
    [Serializable]
    public abstract class Service
    {
        #region Static Members
        // Module 7: Static variable to track total services
        private static int totalServices = 0;
        private static readonly object lockObject = new object();

        public static int TotalServices
        {
            get { return totalServices; }
        }
        #endregion

        #region Private Fields
        private string serviceId;
        private string serviceName;
        private string description;
        private decimal monthlyFee;
        private ServiceType serviceType;
        private bool isAvailable;
        private List<string> eligibleZones;
        private DateTime startDate;
        private DateTime? endDate;
        #endregion

        #region Public Properties
        public string ServiceId
        {
            get { return serviceId; }
            set { serviceId = value; }
        }

        public string ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal MonthlyFee
        {
            get { return monthlyFee; }
            set { monthlyFee = value; }
        }

        public ServiceType ServiceType
        {
            get { return serviceType; }
            set { serviceType = value; }
        }

        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }

        public List<string> EligibleZones
        {
            get { return eligibleZones; }
            set { eligibleZones = value ?? new List<string>(); }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime? EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        #endregion

        #region Constructors
        public Service()
        {
            serviceId = GenerateServiceId();
            eligibleZones = new List<string>();
            isAvailable = true;
            startDate = DateTime.Now;
            lock (lockObject)
            {
                totalServices++;
            }
        }

        public Service(
            string serviceName,
            string description,
            decimal monthlyFee,
            ServiceType serviceType
        )
            : this()
        {
            ServiceName = serviceName;
            Description = description;
            MonthlyFee = monthlyFee;
            ServiceType = serviceType;
        }

        // Module 7: Using this keyword to avoid parameter confusion
        public Service(
            string serviceName,
            string description,
            decimal monthlyFee,
            ServiceType serviceType,
            List<string> eligibleZones
        )
            : this(serviceName, description, monthlyFee, serviceType)
        {
            this.eligibleZones = eligibleZones;
        }
        #endregion

        #region Abstract Methods
        // Module 9: Abstract methods that must be implemented by derived classes
        public abstract decimal CalculateServiceCharge(int usageCount);
        public abstract bool IsEligible(Citizen citizen);
        public abstract string GetServiceDetails();
        #endregion

        #region Virtual Methods
        // Module 8: Virtual methods that can be overridden
        public virtual void Activate()
        {
            isAvailable = true;
            Console.WriteLine($"Service {serviceName} activated.");
        }

        public virtual void Deactivate()
        {
            isAvailable = false;
            Console.WriteLine($"Service {serviceName} deactivated.");
        }

        public virtual bool IsAvailableInZone(ZoneType zone)
        {
            return eligibleZones.Contains(zone.ToString());
        }
        #endregion

        #region Methods
        private string GenerateServiceId()
        {
            return $"SVC-{DateTime.Now.Year}-{Guid.NewGuid().ToString().Substring(0, 6).ToUpper()}";
        }

        public override string ToString()
        {
            return $"Service ID: {serviceId}\n"
                + $"Name: {serviceName}\n"
                + $"Type: {serviceType}\n"
                + $"Fee: {monthlyFee:C}\n"
                + $"Available: {(isAvailable ? "Yes" : "No")}\n"
                + $"Description: {description}";
        }
        #endregion
    }
}
