using System.Collections.Generic;

namespace AddressBookSystem.Entities
{
    public class AddressBook
    {
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
