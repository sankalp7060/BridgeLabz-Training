using System;
using System.Collections.Generic;
using TechVilleSmartCity.Models.Enums;

namespace TechVilleSmartCity.Models
{
    /// <summary>
    /// Citizen class representing a resident of TechVille
    /// Modules 1-5: Basic citizen information and registration
    /// Module 6: OOP Basics - Classes, Objects, Encapsulation
    /// Module 7: Advanced OOP - Static members, this keyword
    /// Module 8: Inheritance - Base class for specialized citizens
    /// </summary>
    [Serializable]
    public class Citizen
    {
        #region Static Members
        // Module 7: Static variables to track total citizens
        private static int totalCitizens = 0;
        private static readonly object lockObject = new object();

        /// <summary>
        /// Static property to get total citizen count
        /// </summary>
        public static int TotalCitizens
        {
            get { return totalCitizens; }
        }
        #endregion

        #region Private Fields
        // Module 6: Private attributes with encapsulation
        private string citizenId;
        private string name;
        private int age;
        private decimal income;
        private int residencyYears;
        private ZoneType zone;
        private int sector;
        private string email;
        private string phoneNumber;
        private string password;
        private DateTime registrationDate;
        private bool isActive;
        private List<Service> subscribedServices;
        #endregion

        #region Public Properties
        // Module 6: Public properties with validation
        public string CitizenId
        {
            get { return citizenId; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Citizen ID cannot be empty");
                citizenId = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                if (value.Length < 2 || value.Length > 50)
                    throw new ArgumentException("Name must be between 2 and 50 characters");
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 150)
                    throw new ArgumentException("Age must be between 0 and 150");
                age = value;
            }
        }

        public decimal Income
        {
            get { return income; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Income cannot be negative");
                income = value;
            }
        }

        public int ResidencyYears
        {
            get { return residencyYears; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Residency years cannot be negative");
                residencyYears = value;
            }
        }

        public ZoneType Zone
        {
            get { return zone; }
            set { zone = value; }
        }

        public int Sector
        {
            get { return sector; }
            set
            {
                if (value < 1 || value > 20)
                    throw new ArgumentException("Sector must be between 1 and 20");
                sector = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && !IsValidEmail(value))
                    throw new ArgumentException("Invalid email format");
                email = value;
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && !IsValidPhoneNumber(value))
                    throw new ArgumentException("Invalid phone number format");
                phoneNumber = value;
            }
        }

        public string Password
        {
            set
            {
                if (!IsValidPassword(value))
                    throw new ArgumentException(
                        "Password must contain at least 8 characters, one uppercase, one lowercase, one digit, and one special character"
                    );
                password = value;
            }
        }

        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public List<Service> SubscribedServices
        {
            get { return subscribedServices; }
            set { subscribedServices = value ?? new List<Service>(); }
        }
        #endregion

        #region Constructors
        // Module 6: Multiple constructors demonstrating constructor overloading
        /// <summary>
        /// Default constructor
        /// </summary>
        public Citizen()
        {
            citizenId = GenerateCitizenId();
            registrationDate = DateTime.Now;
            isActive = true;
            subscribedServices = new List<Service>();
            lock (lockObject)
            {
                totalCitizens++;
            }
        }

        /// <summary>
        /// Parameterized constructor with essential details
        /// </summary>
        public Citizen(string name, int age, decimal income, int residencyYears)
            : this()
        {
            Name = name;
            Age = age;
            Income = income;
            ResidencyYears = residencyYears;
        }

        /// <summary>
        /// Full parameterized constructor
        /// </summary>
        public Citizen(
            string name,
            int age,
            decimal income,
            int residencyYears,
            ZoneType zone,
            int sector,
            string email,
            string phoneNumber
        )
            : this(name, age, income, residencyYears)
        {
            Zone = zone;
            Sector = sector;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Copy constructor - Module 4: Pass by reference demonstration
        /// </summary>
        public Citizen(Citizen other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            citizenId = other.citizenId;
            name = other.name;
            age = other.age;
            income = other.income;
            residencyYears = other.residencyYears;
            zone = other.zone;
            sector = other.sector;
            email = other.email;
            phoneNumber = other.phoneNumber;
            registrationDate = other.registrationDate;
            isActive = other.isActive;
            subscribedServices = new List<Service>(other.subscribedServices);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calculate service eligibility score based on citizen attributes
        /// Module 1: Basic arithmetic operators
        /// </summary>
        public int CalculateEligibilityScore()
        {
            // Base score calculation using arithmetic operators
            int score = 0;

            // Age factor (0-30 points)
            if (age >= 18 && age <= 60)
                score += 30;
            else if (age > 60)
                score += 20;
            else
                score += 10;

            // Income factor (0-30 points)
            if (income > 50000)
                score += 30;
            else if (income > 30000)
                score += 20;
            else if (income > 10000)
                score += 10;

            // Residency factor (0-40 points)
            if (residencyYears >= 10)
                score += 40;
            else if (residencyYears >= 5)
                score += 30;
            else if (residencyYears >= 2)
                score += 20;
            else
                score += 10;

            return score;
        }

        /// <summary>
        /// Determine service package eligibility using conditional statements
        /// Module 2: Nested if-else and ternary operators
        /// </summary>
        public ServiceType GetEligibleServicePackage()
        {
            int score = CalculateEligibilityScore();

            // Nested if-else for multi-level eligibility
            if (score >= 90)
            {
                return ServiceType.Platinum;
            }
            else if (score >= 70)
            {
                return ServiceType.Gold;
            }
            else if (score >= 50)
            {
                return ServiceType.Silver;
            }
            else
            {
                return ServiceType.Basic;
            }

            // Ternary operator example (commented)
            // return score >= 90 ? ServiceType.Platinum :
            //        score >= 70 ? ServiceType.Gold :
            //        score >= 50 ? ServiceType.Silver :
            //        ServiceType.Basic;
        }

        /// <summary>
        /// Validate email format using regex
        /// Module 20: Regular Expressions
        /// </summary>
        private bool IsValidEmail(string email)
        {
            return Business.Validators.RegexValidator.IsValidEmail(email);
        }

        /// <summary>
        /// Validate phone number format using regex
        /// Module 20: Regular Expressions
        /// </summary>
        private bool IsValidPhoneNumber(string phone)
        {
            return Business.Validators.RegexValidator.IsValidPhoneNumber(phone);
        }

        /// <summary>
        /// Validate password strength using regex
        /// Module 20: Regular Expressions
        /// </summary>
        private bool IsValidPassword(string password)
        {
            return Business.Validators.RegexValidator.IsValidPassword(password);
        }

        /// <summary>
        /// Generate unique citizen ID
        /// Format: TC-YYYY-XXXXX (TC = TechVille City)
        /// </summary>
        private string GenerateCitizenId()
        {
            return $"TC-{DateTime.Now.Year}-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
        }

        /// <summary>
        /// Override ToString method - Module 8: Object class override
        /// </summary>
        public override string ToString()
        {
            return $"Citizen ID: {citizenId}\n"
                + $"Name: {name}\n"
                + $"Age: {age}\n"
                + $"Income: {income:C}\n"
                + $"Residency: {residencyYears} years\n"
                + $"Zone: {zone}, Sector: {sector}\n"
                + $"Email: {email ?? "N/A"}\n"
                + $"Phone: {phoneNumber ?? "N/A"}\n"
                + $"Registration: {registrationDate:yyyy-MM-dd}\n"
                + $"Status: {(isActive ? "Active" : "Inactive")}";
        }

        /// <summary>
        /// Override Equals method - Module 8: Object class override
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Citizen other = (Citizen)obj;
            return citizenId == other.citizenId;
        }

        /// <summary>
        /// Override GetHashCode method - Module 8: Object class override
        /// </summary>
        public override int GetHashCode()
        {
            return citizenId?.GetHashCode() ?? 0;
        }
        #endregion
    }
}
