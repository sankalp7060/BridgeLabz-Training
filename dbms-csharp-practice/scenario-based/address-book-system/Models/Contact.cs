namespace AddressBookSystem.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public int AddressBookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
