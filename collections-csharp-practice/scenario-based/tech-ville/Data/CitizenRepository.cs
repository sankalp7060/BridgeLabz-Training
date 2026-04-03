using System;
using System.Collections.Generic;
using System.Linq;
using TechVilleSmartCity.Models;
using TechVilleSmartCity.Utilities;

namespace TechVilleSmartCity.Data
{
    /// <summary>
    /// Citizen Repository Implementation
    /// Module 10-13: Data access layer with collections
    /// </summary>
    public class CitizenRepository : ICitizenRepository
    {
        private readonly DataContext _context;

        public CitizenRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Citizen GetById(string citizenId)
        {
            try
            {
                // Module 12: O(1) lookup using dictionary
                return _context.FindCitizenById(citizenId);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, $"CitizenRepository.GetById({citizenId})");
                throw;
            }
        }

        public List<Citizen> GetAll()
        {
            return _context.Citizens.ToList();
        }

        public void Add(Citizen citizen)
        {
            try
            {
                if (citizen == null)
                    throw new ArgumentNullException(nameof(citizen));

                if (Exists(citizen.CitizenId))
                    throw new DuplicateCitizenException(
                        $"Citizen with ID {citizen.CitizenId} already exists"
                    );

                _context.AddCitizen(citizen);
                _context.SaveData();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "CitizenRepository.Add");
                throw;
            }
        }

        public void Update(Citizen citizen)
        {
            try
            {
                var existing = GetById(citizen.CitizenId);
                if (existing == null)
                    throw new InvalidCitizenIDException(
                        $"Citizen with ID {citizen.CitizenId} not found"
                    );

                // Update in list
                int index = _context.Citizens.FindIndex(c => c.CitizenId == citizen.CitizenId);
                _context.Citizens[index] = citizen;

                // Update in lookup
                _context.CitizenLookup[citizen.CitizenId] = citizen;

                _context.SaveData();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "CitizenRepository.Update");
                throw;
            }
        }

        public void Delete(string citizenId)
        {
            try
            {
                var citizen = GetById(citizenId);
                if (citizen == null)
                    throw new InvalidCitizenIDException($"Citizen with ID {citizenId} not found");

                _context.Citizens.Remove(citizen);
                _context.CitizenLookup.Remove(citizenId);

                _context.SaveData();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "CitizenRepository.Delete");
                throw;
            }
        }

        public List<Citizen> GetByZone(string zone)
        {
            return _context
                .Citizens.Where(c =>
                    c.Zone.ToString().Equals(zone, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();
        }

        public List<Citizen> GetByAgeRange(int minAge, int maxAge)
        {
            return _context.Citizens.Where(c => c.Age >= minAge && c.Age <= maxAge).ToList();
        }

        public bool Exists(string citizenId)
        {
            return _context.CitizenLookup.ContainsKey(citizenId);
        }

        public int GetTotalCount()
        {
            return _context.Citizens.Count;
        }
    }
}
