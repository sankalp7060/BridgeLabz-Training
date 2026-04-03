using System;
using System.Collections.Generic;
using TechVilleSmartCity.Models.Enums;

namespace TechVilleSmartCity.Models
{
    /// <summary>
    /// Education Service implementation
    /// Module 8: Inheritance
    /// </summary>
    [Serializable]
    public class EducationService : Service
    {
        #region Private Fields
        private string institutionName;
        private string courseName;
        private int durationInMonths;
        private string qualification;
        private int maxStudents;
        private List<string> subjects;
        #endregion

        #region Public Properties
        public string InstitutionName
        {
            get { return institutionName; }
            set { institutionName = value; }
        }

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        public int DurationInMonths
        {
            get { return durationInMonths; }
            set { durationInMonths = value; }
        }

        public string Qualification
        {
            get { return qualification; }
            set { qualification = value; }
        }

        public int MaxStudents
        {
            get { return maxStudents; }
            set { maxStudents = value; }
        }

        public List<string> Subjects
        {
            get { return subjects; }
            set { subjects = value ?? new List<string>(); }
        }
        #endregion

        #region Constructors
        public EducationService()
        {
            ServiceType = ServiceType.Education;
            subjects = new List<string>();
        }

        public EducationService(
            string serviceName,
            string description,
            decimal monthlyFee,
            string institutionName,
            string courseName,
            int durationInMonths
        )
            : base(serviceName, description, monthlyFee, ServiceType.Education)
        {
            this.institutionName = institutionName;
            this.courseName = courseName;
            this.durationInMonths = durationInMonths;
            this.subjects = new List<string>();
        }
        #endregion

        #region Override Methods
        public override decimal CalculateServiceCharge(int usageCount)
        {
            decimal baseCharge = MonthlyFee;
            decimal materialFee = 1000m * usageCount;
            return baseCharge + materialFee;
        }

        public override bool IsEligible(Citizen citizen)
        {
            // Age-based eligibility for education services
            return citizen.IsActive && citizen.Age >= 5 && citizen.Age <= 60;
        }

        public override string GetServiceDetails()
        {
            return $"{base.ToString()}\n"
                + $"Institution: {institutionName}\n"
                + $"Course: {courseName}\n"
                + $"Duration: {durationInMonths} months\n"
                + $"Qualification: {qualification}\n"
                + $"Max Students: {maxStudents}\n"
                + $"Subjects: {string.Join(", ", subjects)}";
        }
        #endregion

        #region Education Specific Methods
        public bool HasSeatsAvailable(int currentEnrollment)
        {
            return currentEnrollment < maxStudents;
        }

        public void AddSubject(string subject)
        {
            if (!subjects.Contains(subject))
            {
                subjects.Add(subject);
                Console.WriteLine($"Subject {subject} added to course.");
            }
        }
        #endregion
    }
}
