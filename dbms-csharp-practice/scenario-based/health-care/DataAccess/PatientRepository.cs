using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Interfaces;
using Models;

namespace DataAccess
{
    /// <summary>
    /// Repository layer implementation using ADO.NET.
    /// Connects to SQL Server database HealthCareDB to perform CRUD operations on Patients table.
    /// </summary>
    public class PatientRepository : IPatientRepository
    {
        // Connection string to SQL Server
        private readonly string connectionString =
            "Server=localhost;Database=HealthCareDB;Trusted_Connection=True;";

        /// <summary>
        /// Inserts a new patient into Patients table with uniqueness check on phone/email.
        /// </summary>
        public void InsertPatient(Patient patient)
        {
            // Check for duplicates
            if (GetPatientByPhoneOrEmail(patient.Phone, patient.Email) != null)
            {
                Console.WriteLine("Patient with this phone/email already exists.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query =
                    @"INSERT INTO Patients (full_name, dob, gender, phone, email, address, blood_group)
                                 VALUES (@FullName, @DOB, @Gender, @Phone, @Email, @Address, @BloodGroup)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FullName", patient.FullName);
                    cmd.Parameters.AddWithValue("@DOB", patient.DOB);
                    cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                    cmd.Parameters.AddWithValue("@Phone", patient.Phone);
                    cmd.Parameters.AddWithValue("@Email", patient.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue(
                        "@Address",
                        patient.Address ?? (object)DBNull.Value
                    );
                    cmd.Parameters.AddWithValue(
                        "@BloodGroup",
                        patient.BloodGroup ?? (object)DBNull.Value
                    );

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates patient details in Patients table by patient_id.
        /// </summary>
        public void UpdatePatient(Patient patient)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query =
                    @"UPDATE Patients
                                 SET full_name=@FullName, dob=@DOB, gender=@Gender,
                                     phone=@Phone, email=@Email, address=@Address, blood_group=@BloodGroup
                                 WHERE patient_id=@PatientId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FullName", patient.FullName);
                    cmd.Parameters.AddWithValue("@DOB", patient.DOB);
                    cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                    cmd.Parameters.AddWithValue("@Phone", patient.Phone);
                    cmd.Parameters.AddWithValue("@Email", patient.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue(
                        "@Address",
                        patient.Address ?? (object)DBNull.Value
                    );
                    cmd.Parameters.AddWithValue(
                        "@BloodGroup",
                        patient.BloodGroup ?? (object)DBNull.Value
                    );
                    cmd.Parameters.AddWithValue("@PatientId", patient.PatientId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retrieves a patient by ID
        /// </summary>
        public Patient GetPatientById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Patients WHERE patient_id=@Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapPatient(reader);
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieves a patient by phone or email for uniqueness validation
        /// </summary>
        public Patient GetPatientByPhoneOrEmail(string phone, string email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Patients WHERE phone=@Phone OR email=@Email";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Email", email ?? (object)DBNull.Value);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapPatient(reader);
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieves all patients
        /// </summary>
        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Patients";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patients.Add(MapPatient(reader));
                        }
                    }
                }
            }
            return patients;
        }

        /// <summary>
        /// Search patients by name using LIKE for partial matching
        /// </summary>
        public List<Patient> SearchPatientsByName(string name)
        {
            List<Patient> results = new List<Patient>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Patients WHERE full_name LIKE @Name";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", "%" + name + "%");
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(MapPatient(reader));
                        }
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Maps SqlDataReader row to Patient object
        /// </summary>
        private Patient MapPatient(SqlDataReader reader)
        {
            return new Patient
            {
                PatientId = Convert.ToInt32(reader["patient_id"]),
                FullName = reader["full_name"].ToString(),
                DOB = Convert.ToDateTime(reader["dob"]).ToString("yyyy-MM-dd"),
                Gender = reader["gender"].ToString(),
                Phone = reader["phone"].ToString(),
                Email = reader["email"]?.ToString(),
                Address = reader["address"]?.ToString(),
                BloodGroup = reader["blood_group"]?.ToString(),
            };
        }
    }
}
