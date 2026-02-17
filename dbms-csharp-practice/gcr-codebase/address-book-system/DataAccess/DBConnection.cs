using System.Data.SqlClient;

namespace DataAccess
{
    public class DBConnection
    {
        private static string connectionString =
            @"Server=localhost\SQLEXPRESS;Database=AddressBookDB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
