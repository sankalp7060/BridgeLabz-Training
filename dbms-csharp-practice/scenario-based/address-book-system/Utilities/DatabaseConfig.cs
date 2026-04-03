using System;

namespace AddressBookSystem.Utilities
{
    public static class DatabaseConfig
    {
        // Try different connection strings until one works
        public static string[] PossibleConnectionStrings = new[]
        {
            "Server=localhost\\SQLEXPRESS;Database=AddressBookDB;Trusted_Connection=True;",
            "Server=.\\SQLEXPRESS;Database=AddressBookDB;Trusted_Connection=True;",
            "Server=(local)\\SQLEXPRESS;Database=AddressBookDB;Trusted_Connection=True;",
            "Server=localhost;Database=AddressBookDB;Trusted_Connection=True;",
            "Server=.;Database=AddressBookDB;Trusted_Connection=True;",
            "Server=(local);Database=AddressBookDB;Trusted_Connection=True;",
            "Server=tcp:localhost,1433;Database=AddressBookDB;Trusted_Connection=True;",
        };

        public static string ConnectionString { get; private set; }

        static DatabaseConfig()
        {
            ConnectionString = DetectWorkingConnection();
        }

        private static string DetectWorkingConnection()
        {
            foreach (string connString in PossibleConnectionStrings)
            {
                try
                {
                    using (var connection = new System.Data.SqlClient.SqlConnection(connString))
                    {
                        connection.Open();
                        Console.WriteLine($"✓ Successfully connected using: {connString}");
                        return connString;
                    }
                }
                catch
                {
                    // Try next connection string
                    continue;
                }
            }

            Console.WriteLine("✗ Could not connect to SQL Server with any connection string.");
            Console.WriteLine("Please check if SQL Server is running and try again.");

            // Return default as fallback
            return PossibleConnectionStrings[0];
        }
    }
}
