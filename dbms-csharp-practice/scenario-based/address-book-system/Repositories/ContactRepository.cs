using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AddressBookSystem.Interfaces;
using AddressBookSystem.Models;
using AddressBookSystem.Utilities;

namespace AddressBookSystem.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly string connectionString;

        public ContactRepository()
        {
            // Direct connection string without ConfigurationManager
            connectionString = DatabaseConfig.ConnectionString;
        }

        public bool AddContact(Contact contact)
        {
            if (ContactExists(contact.AddressBookId, contact.FirstName, contact.LastName))
                return false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query =
                    @"INSERT INTO Contact (AddressBookId, FirstName, LastName, Address, City, State, Zip, Phone, Email) 
                               VALUES (@AddressBookId, @FirstName, @LastName, @Address, @City, @State, @Zip, @Phone, @Email)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AddressBookId", contact.AddressBookId);
                command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                command.Parameters.AddWithValue("@LastName", contact.LastName);
                command.Parameters.AddWithValue("@Address", contact.Address);
                command.Parameters.AddWithValue("@City", contact.City);
                command.Parameters.AddWithValue("@State", contact.State);
                command.Parameters.AddWithValue("@Zip", contact.Zip);
                command.Parameters.AddWithValue("@Phone", contact.Phone);
                command.Parameters.AddWithValue("@Email", contact.Email);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool UpdateContact(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query =
                    @"UPDATE Contact SET FirstName = @FirstName, LastName = @LastName, 
                               Address = @Address, City = @City, State = @State, Zip = @Zip, 
                               Phone = @Phone, Email = @Email WHERE ContactId = @ContactId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ContactId", contact.ContactId);
                command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                command.Parameters.AddWithValue("@LastName", contact.LastName);
                command.Parameters.AddWithValue("@Address", contact.Address);
                command.Parameters.AddWithValue("@City", contact.City);
                command.Parameters.AddWithValue("@State", contact.State);
                command.Parameters.AddWithValue("@Zip", contact.Zip);
                command.Parameters.AddWithValue("@Phone", contact.Phone);
                command.Parameters.AddWithValue("@Email", contact.Email);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool DeleteContact(int contactId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Contact WHERE ContactId = @ContactId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ContactId", contactId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public Contact GetContactByName(int addressBookId, string firstName, string lastName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query =
                    @"SELECT * FROM Contact 
                               WHERE AddressBookId = @AddressBookId AND FirstName = @FirstName AND LastName = @LastName";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AddressBookId", addressBookId);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return MapContactFromReader(reader);
                }
                return null;
            }
        }

        public List<Contact> GetAllContacts(int addressBookId)
        {
            List<Contact> contacts = new List<Contact>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Contact WHERE AddressBookId = @AddressBookId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AddressBookId", addressBookId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    contacts.Add(MapContactFromReader(reader));
                }
            }
            return contacts;
        }

        public bool ContactExists(int addressBookId, string firstName, string lastName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query =
                    @"SELECT COUNT(*) FROM Contact 
                               WHERE AddressBookId = @AddressBookId AND FirstName = @FirstName AND LastName = @LastName";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AddressBookId", addressBookId);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public List<Contact> SearchPersonsByCityOrState(string city, string state)
        {
            List<Contact> contacts = new List<Contact>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query =
                    @"SELECT c.*, a.Name as AddressBookName 
                               FROM Contact c 
                               INNER JOIN AddressBook a ON c.AddressBookId = a.AddressBookId
                               WHERE City = @City OR State = @State";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@City", city ?? "");
                command.Parameters.AddWithValue("@State", state ?? "");

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    contacts.Add(MapContactFromReader(reader));
                }
            }
            return contacts;
        }

        public Dictionary<string, List<Contact>> GetPersonsByCity()
        {
            Dictionary<string, List<Contact>> cityGroups = new Dictionary<string, List<Contact>>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Contact ORDER BY City";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contact contact = MapContactFromReader(reader);
                    if (!cityGroups.ContainsKey(contact.City))
                        cityGroups[contact.City] = new List<Contact>();
                    cityGroups[contact.City].Add(contact);
                }
            }
            return cityGroups;
        }

        public Dictionary<string, List<Contact>> GetPersonsByState()
        {
            Dictionary<string, List<Contact>> stateGroups = new Dictionary<string, List<Contact>>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Contact ORDER BY State";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contact contact = MapContactFromReader(reader);
                    if (!stateGroups.ContainsKey(contact.State))
                        stateGroups[contact.State] = new List<Contact>();
                    stateGroups[contact.State].Add(contact);
                }
            }
            return stateGroups;
        }

        public int GetCountByCity(string city)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Contact WHERE City = @City";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@City", city);

                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public int GetCountByState(string state)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Contact WHERE State = @State";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@State", state);

                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public List<Contact> SortContactsByName(int addressBookId)
        {
            List<Contact> contacts = new List<Contact>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query =
                    @"SELECT * FROM Contact 
                               WHERE AddressBookId = @AddressBookId 
                               ORDER BY FirstName, LastName";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AddressBookId", addressBookId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    contacts.Add(MapContactFromReader(reader));
                }
            }
            return contacts;
        }

        private Contact MapContactFromReader(SqlDataReader reader)
        {
            return new Contact
            {
                ContactId = Convert.ToInt32(reader["ContactId"]),
                AddressBookId = Convert.ToInt32(reader["AddressBookId"]),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Address = reader["Address"].ToString(),
                City = reader["City"].ToString(),
                State = reader["State"].ToString(),
                Zip = reader["Zip"].ToString(),
                Phone = reader["Phone"].ToString(),
                Email = reader["Email"].ToString(),
            };
        }
    }
}
