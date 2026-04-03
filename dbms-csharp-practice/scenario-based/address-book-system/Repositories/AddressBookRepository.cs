using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AddressBookSystem.Interfaces;
using AddressBookSystem.Models;
using AddressBookSystem.Utilities;

namespace AddressBookSystem.Repositories
{
    public class AddressBookRepository : IAddressBookRepository
    {
        private readonly string connectionString;

        public AddressBookRepository()
        {
            // Direct connection string without ConfigurationManager
            connectionString = DatabaseConfig.ConnectionString;
        }

        public int AddAddressBook(AddressBook addressBook)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query =
                    "INSERT INTO AddressBook (Name) VALUES (@Name); SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", addressBook.Name);

                connection.Open();
                int newId = Convert.ToInt32(command.ExecuteScalar());
                return newId;
            }
        }

        public AddressBook GetAddressBookByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT AddressBookId, Name FROM AddressBook WHERE Name = @Name";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new AddressBook
                    {
                        AddressBookId = Convert.ToInt32(reader["AddressBookId"]),
                        Name = reader["Name"].ToString(),
                    };
                }
                return null;
            }
        }

        public List<AddressBook> GetAllAddressBooks()
        {
            List<AddressBook> addressBooks = new List<AddressBook>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT AddressBookId, Name FROM AddressBook";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    addressBooks.Add(
                        new AddressBook
                        {
                            AddressBookId = Convert.ToInt32(reader["AddressBookId"]),
                            Name = reader["Name"].ToString(),
                        }
                    );
                }
            }
            return addressBooks;
        }

        public bool AddressBookExists(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM AddressBook WHERE Name = @Name";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
