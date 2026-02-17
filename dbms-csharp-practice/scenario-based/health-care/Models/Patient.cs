namespace Models
{
    /// <summary>
    /// Represents a Patient entity in the system.
    /// Maps directly to the Patients table in HealthCareDB.
    /// </summary>
    public class Patient
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public string DOB { get; set; } // Stored as string for simplicity; can use DateTime
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }
    }
}
