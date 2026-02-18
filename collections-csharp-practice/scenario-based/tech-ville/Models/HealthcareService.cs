using System;
using System.Collections.Generic;
using TechVilleSmartCity.Models.Enums;

namespace TechVilleSmartCity.Models
{
    /// <summary>
    /// Healthcare Service implementation
    /// Module 8: Inheritance
    /// Module 9: Polymorphism
    /// </summary>
    [Serializable]
    public class HealthcareService : Service
    {
        #region Private Fields
        private string hospitalName;
        private string doctorName;
        private string specialization;
        private int numberOfBeds;
        private bool emergencyAvailable;
        private List<string> insuranceProviders;
        #endregion

        #region Public Properties
        public string HospitalName
        {
            get { return hospitalName; }
            set { hospitalName = value; }
        }

        public string DoctorName
        {
            get { return doctorName; }
            set { doctorName = value; }
        }

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public int NumberOfBeds
        {
            get { return numberOfBeds; }
            set { numberOfBeds = value; }
        }

        public bool EmergencyAvailable
        {
            get { return emergencyAvailable; }
            set { emergencyAvailable = value; }
        }

        public List<string> InsuranceProviders
        {
            get { return insuranceProviders; }
            set { insuranceProviders = value ?? new List<string>(); }
        }
        #endregion

        #region Constructors
        public HealthcareService()
        {
            ServiceType = ServiceType.Healthcare;
            insuranceProviders = new List<string>();
        }

        public HealthcareService(
            string serviceName,
            string description,
            decimal monthlyFee,
            string hospitalName,
            string doctorName,
            string specialization
        )
            : base(serviceName, description, monthlyFee, ServiceType.Healthcare)
        {
            this.hospitalName = hospitalName;
            this.doctorName = doctorName;
            this.specialization = specialization;
            this.insuranceProviders = new List<string>();
        }
        #endregion

        #region Override Methods
        /// <summary>
        /// Calculate healthcare service charges based on visits
        /// </summary>
        public override decimal CalculateServiceCharge(int usageCount)
        {
            decimal baseCharge = MonthlyFee;
            decimal consultationFee = 500m * usageCount;
            return baseCharge + consultationFee;
        }

        /// <summary>
        /// Check if citizen is eligible for healthcare service
        /// </summary>
        public override bool IsEligible(Citizen citizen)
        {
            // All citizens are eligible for basic healthcare
            return citizen.IsActive;
        }

        /// <summary>
        /// Get detailed healthcare service information
        /// </summary>
        public override string GetServiceDetails()
        {
            return $"{base.ToString()}\n"
                + $"Hospital: {hospitalName}\n"
                + $"Doctor: {doctorName}\n"
                + $"Specialization: {specialization}\n"
                + $"Beds Available: {numberOfBeds}\n"
                + $"Emergency: {(emergencyAvailable ? "Yes" : "No")}\n"
                + $"Insurance Providers: {string.Join(", ", insuranceProviders)}";
        }

        /// <summary>
        /// Override base Activate method - Module 8: Method overriding
        /// </summary>
        public override void Activate()
        {
            base.Activate();
            Console.WriteLine($"Healthcare service at {hospitalName} is now active.");
        }
        #endregion

        #region Healthcare Specific Methods
        public bool AcceptsInsurance(string insuranceProvider)
        {
            return insuranceProviders.Contains(insuranceProvider);
        }

        public void AddInsuranceProvider(string provider)
        {
            if (!insuranceProviders.Contains(provider))
            {
                insuranceProviders.Add(provider);
                Console.WriteLine($"Insurance provider {provider} added.");
            }
        }
        #endregion
    }
}
