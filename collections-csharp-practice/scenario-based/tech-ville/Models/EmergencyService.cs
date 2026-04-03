using System;
using System.Collections.Generic;
using TechVilleSmartCity.Models.Enums;

namespace TechVilleSmartCity.Models
{
    /// <summary>
    /// Emergency Service - Specialized service with priority handling
    /// Module 8: Inheritance - Specialized service overriding standard procedures
    /// </summary>
    [Serializable]
    public class EmergencyService : Service
    {
        #region Private Fields
        private string emergencyType; // Police, Fire, Ambulance
        private int responseTimeMinutes;
        private string contactNumber;
        private List<string> availableVehicles;
        private int numberOfPersonnel;
        private bool is24x7;
        #endregion

        #region Public Properties
        public string EmergencyType
        {
            get { return emergencyType; }
            set { emergencyType = value; }
        }

        public int ResponseTimeMinutes
        {
            get { return responseTimeMinutes; }
            set { responseTimeMinutes = value; }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        public List<string> AvailableVehicles
        {
            get { return availableVehicles; }
            set { availableVehicles = value ?? new List<string>(); }
        }

        public int NumberOfPersonnel
        {
            get { return numberOfPersonnel; }
            set { numberOfPersonnel = value; }
        }

        public bool Is24x7
        {
            get { return is24x7; }
            set { is24x7 = value; }
        }
        #endregion

        #region Constructors
        public EmergencyService()
        {
            ServiceType = ServiceType.Emergency;
            availableVehicles = new List<string>();
        }

        public EmergencyService(
            string serviceName,
            string description,
            decimal monthlyFee,
            string emergencyType,
            int responseTimeMinutes,
            string contactNumber
        )
            : base(serviceName, description, monthlyFee, ServiceType.Emergency)
        {
            this.emergencyType = emergencyType;
            this.responseTimeMinutes = responseTimeMinutes;
            this.contactNumber = contactNumber;
            this.availableVehicles = new List<string>();
            this.is24x7 = true;
        }
        #endregion

        #region Override Methods
        /// <summary>
        /// Override - Emergency services have different charge calculation
        /// </summary>
        public override decimal CalculateServiceCharge(int usageCount)
        {
            // Emergency services have base fee + per-incident charge
            decimal baseCharge = MonthlyFee;
            decimal incidentCharge = 2000m * usageCount;
            return baseCharge + incidentCharge;
        }

        /// <summary>
        /// Override - Emergency services are available to all active citizens
        /// </summary>
        public override bool IsEligible(Citizen citizen)
        {
            // Emergency services available to all citizens regardless of age/income
            return citizen.IsActive;
        }

        /// <summary>
        /// Override - Emergency service details
        /// </summary>
        public override string GetServiceDetails()
        {
            return $"{base.ToString()}\n"
                + $"Emergency Type: {emergencyType}\n"
                + $"Response Time: {responseTimeMinutes} minutes\n"
                + $"Contact: {contactNumber}\n"
                + $"24x7 Available: {(is24x7 ? "Yes" : "No")}\n"
                + $"Personnel: {numberOfPersonnel}\n"
                + $"Vehicles: {string.Join(", ", availableVehicles)}";
        }

        /// <summary>
        /// Override Activate with emergency-specific behavior
        /// </summary>
        public override void Activate()
        {
            base.Activate();
            Console.WriteLine(
                $"EMERGENCY SERVICE ACTIVATED: {emergencyType} - Response time: {responseTimeMinutes} mins"
            );
        }
        #endregion

        #region Emergency Specific Methods
        public void DispatchVehicle(string vehicleType, string location)
        {
            if (availableVehicles.Contains(vehicleType))
            {
                Console.WriteLine(
                    $"Dispatching {vehicleType} to {location}. ETA: {responseTimeMinutes} minutes"
                );
                // In real system, would remove from available and track
            }
            else
            {
                Console.WriteLine($"No {vehicleType} available for dispatch!");
            }
        }

        public void AddVehicle(string vehicle)
        {
            if (!availableVehicles.Contains(vehicle))
            {
                availableVehicles.Add(vehicle);
                Console.WriteLine($"Vehicle {vehicle} added to emergency fleet.");
            }
        }
        #endregion
    }
}
