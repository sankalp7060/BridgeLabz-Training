using System;
using Microsoft.Data.SqlClient;

namespace HealthCareClinicSystem.Utilities
{
    public static class DatabaseConnection
    {
        // Try different common SQL Server instance names
        private static readonly string[] PossibleConnections = new[]
        {
            "Server=localhost\\SQLEXPRESS;Database=HealthCareClinicDB;Trusted_Connection=True;TrustServerCertificate=True;",
            "Server=.\\SQLEXPRESS;Database=HealthCareClinicDB;Trusted_Connection=True;TrustServerCertificate=True;",
            "Server=localhost;Database=HealthCareClinicDB;Trusted_Connection=True;TrustServerCertificate=True;",
            "Server=(local);Database=HealthCareClinicDB;Trusted_Connection=True;TrustServerCertificate=True;",
        };

        private static string _connectionString;

        static DatabaseConnection()
        {
            TestAndSetConnection();
        }

        private static void TestAndSetConnection()
        {
            foreach (string connString in PossibleConnections)
            {
                try
                {
                    using (var conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        _connectionString = connString;
                        Console.WriteLine($"✓ Connected using: {connString}");
                        return;
                    }
                }
                catch
                {
                    // Try next connection string
                    continue;
                }
            }

            // If all fail, use the first one and let the application handle the error
            _connectionString = PossibleConnections[0];
            Console.WriteLine(
                "⚠ Could not automatically detect SQL Server. Using default connection string."
            );
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public static void TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    Console.WriteLine("✓ Database connection successful!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Database connection failed: {ex.Message}");
                Console.WriteLine("Please ensure:");
                Console.WriteLine("1. SQL Server is running");
                Console.WriteLine("2. Database 'HealthCareClinicDB' exists");
                Console.WriteLine("3. Windows Authentication is enabled");
            }
        }
    }
}
