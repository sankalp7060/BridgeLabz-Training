using System.Collections.Generic;
using System.Data.SqlClient;
using Interfaces;
using Models;

namespace DataAccess
{
    public class ContactRepository : IContactRepository
    {
        public void AddContact(Contact c)
        {
            using SqlConnection con = DBConnection.GetConnection();

            string query =
                @"INSERT INTO Contact
            (AddressBookId,FirstName,LastName,Address,City,State,Zip,Phone,Email)
            VALUES(@AB,@FN,@LN,@AD,@C,@S,@Z,@P,@E)";

            SqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@AB", c.AddressBookId);
            cmd.Parameters.AddWithValue("@FN", c.FirstName);
            cmd.Parameters.AddWithValue("@LN", c.LastName);
            cmd.Parameters.AddWithValue("@AD", c.Address);
            cmd.Parameters.AddWithValue("@C", c.City);
            cmd.Parameters.AddWithValue("@S", c.State);
            cmd.Parameters.AddWithValue("@Z", c.Zip);
            cmd.Parameters.AddWithValue("@P", c.Phone);
            cmd.Parameters.AddWithValue("@E", c.Email);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void EditContact(Contact c)
        {
            using SqlConnection con = DBConnection.GetConnection();

            string q =
                @"UPDATE Contact SET
                        Address=@AD,City=@C,State=@S,Zip=@Z,
                        Phone=@P,Email=@E
                        WHERE FirstName=@FN AND LastName=@LN";

            SqlCommand cmd = new(q, con);

            cmd.Parameters.AddWithValue("@FN", c.FirstName);
            cmd.Parameters.AddWithValue("@LN", c.LastName);
            cmd.Parameters.AddWithValue("@AD", c.Address);
            cmd.Parameters.AddWithValue("@C", c.City);
            cmd.Parameters.AddWithValue("@S", c.State);
            cmd.Parameters.AddWithValue("@Z", c.Zip);
            cmd.Parameters.AddWithValue("@P", c.Phone);
            cmd.Parameters.AddWithValue("@E", c.Email);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void DeleteContact(string f, string l)
        {
            using SqlConnection con = DBConnection.GetConnection();

            SqlCommand cmd = new("DELETE FROM Contact WHERE FirstName=@F AND LastName=@L", con);

            cmd.Parameters.AddWithValue("@F", f);
            cmd.Parameters.AddWithValue("@L", l);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Contact> GetByCity(string city)
        {
            return Fetch("SELECT * FROM Contact WHERE City=@X", city);
        }

        public List<Contact> GetByState(string state)
        {
            return Fetch("SELECT * FROM Contact WHERE State=@X", state);
        }

        public int CountByCity(string city)
        {
            return Count("SELECT COUNT(*) FROM Contact WHERE City=@X", city);
        }

        public int CountByState(string state)
        {
            return Count("SELECT COUNT(*) FROM Contact WHERE State=@X", state);
        }

        public List<Contact> SortByName(int abId)
        {
            using SqlConnection con = DBConnection.GetConnection();

            SqlCommand cmd = new(
                "SELECT * FROM Contact WHERE AddressBookId=@A ORDER BY FirstName",
                con
            );

            cmd.Parameters.AddWithValue("@A", abId);

            con.Open();
            SqlDataReader r = cmd.ExecuteReader();

            List<Contact> list = new();
            while (r.Read())
                list.Add(new Contact { FirstName = r["FirstName"].ToString() });

            return list;
        }

        private List<Contact> Fetch(string q, string val)
        {
            List<Contact> list = new();

            using SqlConnection con = DBConnection.GetConnection();
            SqlCommand cmd = new(q, con);
            cmd.Parameters.AddWithValue("@X", val);

            con.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
                list.Add(
                    new Contact
                    {
                        FirstName = r["FirstName"].ToString(),
                        LastName = r["LastName"].ToString(),
                    }
                );

            return list;
        }

        private int Count(string q, string val)
        {
            using SqlConnection con = DBConnection.GetConnection();
            SqlCommand cmd = new(q, con);
            cmd.Parameters.AddWithValue("@X", val);

            con.Open();
            return (int)cmd.ExecuteScalar();
        }
    }
}
