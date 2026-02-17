using System.Collections.Generic;
using System.Data.SqlClient;
using Interfaces;
using Models;

namespace DataAccess
{
    public class AddressBookRepository : IAddressBookRepository
    {
        public void AddAddressBook(string name)
        {
            using SqlConnection con = DBConnection.GetConnection();
            string query = "INSERT INTO AddressBook(Name) VALUES(@Name)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", name);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public List<AddressBook> GetAllAddressBooks()
        {
            List<AddressBook> list = new();

            using SqlConnection con = DBConnection.GetConnection();
            SqlCommand cmd = new("SELECT * FROM AddressBook", con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(
                    new AddressBook
                    {
                        AddressBookId = (int)reader["AddressBookId"],
                        Name = reader["Name"].ToString(),
                    }
                );
            }

            return list;
        }
    }
}
