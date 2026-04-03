using System;
using System.Collections.Generic;
using System.Linq;
using TechVilleSmartCity.Business.Validators;
using TechVilleSmartCity.Data;
using TechVilleSmartCity.Models;
using TechVilleSmartCity.Models.Enums;
using TechVilleSmartCity.Utilities;

namespace TechVilleSmartCity.Business
{
    /// <summary>
    /// Citizen Service Business Logic Implementation
    /// Modules 1-5: Core business logic with validation
    /// Module 4: String manipulation and search
    /// Module 5: Exception handling
    /// Module 19: Comprehensive exception management
    /// </summary>
    public class CitizenService : ICitizenService
    {
        private readonly ICitizenRepository _citizenRepository;

        public CitizenService(ICitizenRepository citizenRepository)
        {
            _citizenRepository =
                citizenRepository ?? throw new ArgumentNullException(nameof(citizenRepository));
        }

        /// <summary>
        /// Register a new citizen with validation
        /// Module 1: Basic input handling
        /// Module 5: Exception handling
        /// Module 19: Custom exceptions
        /// </summary>
        public Citizen RegisterCitizen(
            string name,
            int age,
            decimal income,
            int residencyYears,
            string zone,
            int sector,
            string email,
            string phone,
            string password
        )
        {
            try
            {
                // Module 19: Validate age with custom exception
                if (age < 18)
                {
                    throw new UnderageException(
                        "Citizen must be at least 18 years old to register"
                    );
                }

                if (age > 120)
                {
                    throw new OverageException("Invalid age: Maximum age is 120 years");
                }

                // Module 19: Validate using regex
                if (!string.IsNullOrEmpty(email) && !RegexValidator.IsValidEmail(email))
                {
                    throw new ArgumentException("Invalid email format", nameof(email));
                }

                if (!string.IsNullOrEmpty(phone) && !RegexValidator.IsValidPhoneNumber(phone))
                {
                    throw new ArgumentException("Invalid phone number format", nameof(phone));
                }

                if (!RegexValidator.IsValidPassword(password))
                {
                    throw new ArgumentException(
                        "Password must contain at least 8 characters, one uppercase, one lowercase, one digit, and one special character"
                    );
                }

                // Parse zone enum
                if (!Enum.TryParse<ZoneType>(zone, true, out ZoneType zoneType))
                {
                    throw new InvalidZoneException($"Invalid zone: {zone}");
                }

                // Create citizen object
                var citizen = new Citizen(
                    name,
                    age,
                    income,
                    residencyYears,
                    zoneType,
                    sector,
                    email,
                    phone
                );
                citizen.Password = password;

                // Module 19: Check for duplicates
                if (_citizenRepository.Exists(citizen.CitizenId))
                {
                    throw new DuplicateCitizenException(
                        $"Citizen with ID {citizen.CitizenId} already exists"
                    );
                }

                // Save to repository
                _citizenRepository.Add(citizen);

                return citizen;
            }
            catch (UnderageException ex)
            {
                ExceptionLogger.LogException(ex, "CitizenService.RegisterCitizen");
                throw; // Re-throw business exception
            }
            catch (ArgumentException ex)
            {
                ExceptionLogger.LogException(ex, "CitizenService.RegisterCitizen");
                throw;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "CitizenService.RegisterCitizen");
                throw new ApplicationException("An error occurred during citizen registration", ex);
            }
        }

        /// <summary>
        /// Get citizen by ID
        /// </summary>
        public Citizen GetCitizen(string citizenId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(citizenId))
                {
                    throw new ArgumentException("Citizen ID cannot be empty", nameof(citizenId));
                }

                var citizen = _citizenRepository.GetById(citizenId);

                if (citizen == null)
                {
                    throw new InvalidCitizenIDException($"Citizen with ID {citizenId} not found");
                }

                return citizen;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, $"CitizenService.GetCitizen({citizenId})");
                throw;
            }
        }

        /// <summary>
        /// Get all citizens
        /// </summary>
        public List<Citizen> GetAllCitizens()
        {
            try
            {
                return _citizenRepository.GetAll();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "CitizenService.GetAllCitizens");
                throw;
            }
        }

        /// <summary>
        /// Update citizen information
        /// Module 4: Pass by reference demonstration
        /// </summary>
        public bool UpdateCitizen(Citizen citizen)
        {
            try
            {
                if (citizen == null)
                {
                    throw new ArgumentNullException(nameof(citizen));
                }

                // Validate updated data
                if (!ValidateCitizenData(citizen))
                {
                    return false;
                }

                _citizenRepository.Update(citizen);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "CitizenService.UpdateCitizen");
                return false;
            }
        }

        /// <summary>
        /// Delete citizen
        /// </summary>
        public bool DeleteCitizen(string citizenId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(citizenId))
                {
                    throw new ArgumentException("Citizen ID cannot be empty", nameof(citizenId));
                }

                _citizenRepository.Delete(citizenId);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, $"CitizenService.DeleteCitizen({citizenId})");
                return false;
            }
        }

        /// <summary>
        /// Search citizens by name or ID
        /// Module 4: String matching
        /// Module 14: Linear search implementation
        /// </summary>
        public List<Citizen> SearchCitizens(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    return new List<Citizen>();
                }

                var allCitizens = _citizenRepository.GetAll();
                var results = new List<Citizen>();

                // Module 14: Linear search for unsorted data
                foreach (var citizen in allCitizens)
                {
                    if (
                        citizen.CitizenId.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                        || citizen.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                    )
                    {
                        results.Add(citizen);
                    }
                }

                return results;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, $"CitizenService.SearchCitizens({searchTerm})");
                throw;
            }
        }

        /// <summary>
        /// Calculate eligibility score
        /// Module 1: Arithmetic operations
        /// </summary>
        public int CalculateEligibilityScore(string citizenId)
        {
            var citizen = GetCitizen(citizenId);
            return citizen.CalculateEligibilityScore();
        }

        /// <summary>
        /// Get recommended service package
        /// Module 2: Conditional logic
        /// </summary>
        public string GetRecommendedServicePackage(string citizenId)
        {
            var citizen = GetCitizen(citizenId);
            var package = citizen.GetEligibleServicePackage();
            return package.ToString();
        }

        /// <summary>
        /// Validate citizen data
        /// Module 4: Validation methods
        /// </summary>
        public bool ValidateCitizenData(Citizen citizen)
        {
            try
            {
                return CitizenValidator.Validate(citizen);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "CitizenService.ValidateCitizenData");
                return false;
            }
        }

        /// <summary>
        /// Module 14: Binary search on sorted citizen IDs
        /// </summary>
        public Citizen BinarySearchById(string citizenId)
        {
            var allCitizens = _citizenRepository.GetAll();
            var sortedCitizens = allCitizens.OrderBy(c => c.CitizenId).ToList();

            int left = 0;
            int right = sortedCitizens.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = string.Compare(sortedCitizens[mid].CitizenId, citizenId);

                if (comparison == 0)
                    return sortedCitizens[mid];
                if (comparison < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null;
        }

        /// <summary>
        /// Module 14: Quick sort implementation
        /// </summary>
        public List<Citizen> QuickSortCitizensByAge(List<Citizen> citizens)
        {
            if (citizens == null || citizens.Count <= 1)
                return citizens;

            var list = citizens.ToList();
            QuickSort(list, 0, list.Count - 1);
            return list;
        }

        private void QuickSort(List<Citizen> citizens, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(citizens, low, high);
                QuickSort(citizens, low, pi - 1);
                QuickSort(citizens, pi + 1, high);
            }
        }

        private int Partition(List<Citizen> citizens, int low, int high)
        {
            int pivot = citizens[high].Age;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (citizens[j].Age < pivot)
                {
                    i++;
                    Swap(citizens, i, j);
                }
            }

            Swap(citizens, i + 1, high);
            return i + 1;
        }

        private void Swap(List<Citizen> citizens, int i, int j)
        {
            var temp = citizens[i];
            citizens[i] = citizens[j];
            citizens[j] = temp;
        }
    }
}
