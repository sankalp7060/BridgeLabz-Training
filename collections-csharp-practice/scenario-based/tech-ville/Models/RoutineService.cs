using System;
using System.Collections.Generic;
using TechVilleSmartCity.Models.Enums;

namespace TechVilleSmartCity.Models
{
    /// <summary>
    /// Routine Service - Standard city services
    /// Module 8: Inheritance
    /// </summary>
    [Serializable]
    public class RoutineService : Service
    {
        #region Private Fields
        private string serviceCategory; // Maintenance, Cleaning, Inspection
        private int frequencyPerMonth;
        private TimeSpan startTime;
        private TimeSpan endTime;
        private List<string> requiredEquipment;
        private int assignedStaff;
        #endregion

        #region Public Properties
        public string ServiceCategory
        {
            get { return serviceCategory; }
            set { serviceCategory = value; }
        }

        public int FrequencyPerMonth
        {
            get { return frequencyPerMonth; }
            set { frequencyPerMonth = value; }
        }

        public TimeSpan StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public TimeSpan EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public List<string> RequiredEquipment
        {
            get { return requiredEquipment; }
            set { requiredEquipment = value ?? new List<string>(); }
        }

        public int AssignedStaff
        {
            get { return assignedStaff; }
            set { assignedStaff = value; }
        }
        #endregion

        #region Constructors
        public RoutineService()
        {
            ServiceType = ServiceType.Routine;
            requiredEquipment = new List<string>();
        }

        public RoutineService(
            string serviceName,
            string description,
            decimal monthlyFee,
            string serviceCategory,
            int frequencyPerMonth
        )
            : base(serviceName, description, monthlyFee, ServiceType.Routine)
        {
            this.serviceCategory = serviceCategory;
            this.frequencyPerMonth = frequencyPerMonth;
            this.requiredEquipment = new List<string>();
            this.startTime = new TimeSpan(9, 0, 0); // 9 AM default
            this.endTime = new TimeSpan(17, 0, 0); // 5 PM default
        }
        #endregion

        #region Override Methods
        public override decimal CalculateServiceCharge(int usageCount)
        {
            // Routine services have fixed monthly fee
            return MonthlyFee;
        }

        public override bool IsEligible(Citizen citizen)
        {
            // Most routine services require minimum residency
            return citizen.IsActive && citizen.ResidencyYears >= 1;
        }

        public override string GetServiceDetails()
        {
            return $"{base.ToString()}\n"
                + $"Category: {serviceCategory}\n"
                + $"Frequency: {frequencyPerMonth} times/month\n"
                + $"Operating Hours: {startTime:hh\\:mm} - {endTime:hh\\:mm}\n"
                + $"Staff Assigned: {assignedStaff}\n"
                + $"Equipment: {string.Join(", ", requiredEquipment)}";
        }
        #endregion

        #region Routine Specific Methods
        public bool IsWithinOperatingHours(TimeSpan currentTime)
        {
            return currentTime >= startTime && currentTime <= endTime;
        }

        public void ScheduleService(DateTime date, string location)
        {
            if (IsWithinOperatingHours(date.TimeOfDay))
            {
                Console.WriteLine(
                    $"Routine {serviceCategory} scheduled at {location} on {date:yyyy-MM-dd}"
                );
            }
            else
            {
                Console.WriteLine(
                    $"Cannot schedule: Outside operating hours ({startTime:hh\\:mm} - {endTime:hh\\:mm})"
                );
            }
        }
        #endregion
    }
}
