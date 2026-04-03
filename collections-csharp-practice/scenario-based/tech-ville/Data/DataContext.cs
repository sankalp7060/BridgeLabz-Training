using System;
using System.Collections.Generic;
using TechVilleSmartCity.Models;
using TechVilleSmartCity.Models.Enums;
using TechVilleSmartCity.Utilities;

namespace TechVilleSmartCity.Data
{
    /// <summary>
    /// Simple Data Context - Just holds data in memory
    /// No complex serialization - keeps it simple
    /// </summary>
    public class DataContext
    {
        #region Private Fields
        private List<Citizen> citizens;
        private List<Service> services;
        private Dictionary<string, List<string>> zoneSectorMap;
        private Queue<Citizen> serviceQueue;
        private Stack<Citizen> profileEditHistory;
        private Dictionary<string, Citizen> citizenLookup;
        private int[,] zoneSectorPopulation;
        #endregion

        #region Public Properties
        public List<Citizen> Citizens => citizens;
        public List<Service> Services => services;
        public Dictionary<string, List<string>> ZoneSectorMap => zoneSectorMap;
        public Queue<Citizen> ServiceQueue => serviceQueue;
        public Stack<Citizen> ProfileEditHistory => profileEditHistory;
        public Dictionary<string, Citizen> CitizenLookup => citizenLookup;
        public int[,] ZoneSectorPopulation => zoneSectorPopulation;
        #endregion

        #region Constructor
        public DataContext()
        {
            // Initialize all data structures
            citizens = new List<Citizen>();
            services = new List<Service>();
            zoneSectorMap = new Dictionary<string, List<string>>();
            serviceQueue = new Queue<Citizen>();
            profileEditHistory = new Stack<Citizen>();
            citizenLookup = new Dictionary<string, Citizen>();
            zoneSectorPopulation = new int[5, 20];

            InitializeZoneSectorMap();
            AddSampleData(); // Optional: add some test data
        }
        #endregion

        #region Initialization
        private void InitializeZoneSectorMap()
        {
            string[] zones = { "North", "South", "East", "West", "Central" };
            for (int i = 0; i < zones.Length; i++)
            {
                var sectors = new List<string>();
                for (int j = 1; j <= 20; j++)
                    sectors.Add($"Sector-{j}");
                zoneSectorMap[zones[i]] = sectors;
            }
        }

        private void AddSampleData()
        {
            try
            {
                var citizen1 = new Citizen(
                    "John Doe",
                    35,
                    50000,
                    5,
                    ZoneType.North,
                    5,
                    "john@email.com",
                    "1234567890"
                );
                var citizen2 = new Citizen(
                    "Jane Smith",
                    28,
                    45000,
                    3,
                    ZoneType.South,
                    8,
                    "jane@email.com",
                    "9876543210"
                );

                citizens.Add(citizen1);
                citizens.Add(citizen2);
                citizenLookup[citizen1.CitizenId] = citizen1;
                citizenLookup[citizen2.CitizenId] = citizen2;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex, "DataContext.AddSampleData");
            }
        }
        #endregion

        #region Simple Save Method (Just for compatibility)
        /// <summary>
        /// Simple save method - does nothing but prevents errors
        /// In a real app, you'd implement actual saving
        /// </summary>
        public void SaveData()
        {
            // For now, just log that save was called
            Console.WriteLine("Data save requested - running in memory mode");
            // In a real app, you could implement file saving here if needed
        }
        #endregion

        #region Data Operations
        public void AddCitizen(Citizen citizen)
        {
            if (citizen == null)
                return;

            citizens.Add(citizen);
            citizenLookup[citizen.CitizenId] = citizen;

            int zoneIndex = (int)citizen.Zone - 1;
            int sectorIndex = citizen.Sector - 1;
            if (zoneIndex >= 0 && zoneIndex < 5 && sectorIndex >= 0 && sectorIndex < 20)
            {
                zoneSectorPopulation[zoneIndex, sectorIndex]++;
            }
        }

        public Citizen FindCitizenById(string citizenId)
        {
            if (string.IsNullOrEmpty(citizenId))
                return null;
            citizenLookup.TryGetValue(citizenId, out Citizen citizen);
            return citizen;
        }
        #endregion
    }
}
