using System;
using System.Collections.Generic;
using AddressBookSystem.Entities;

namespace AddressBookSystem.Services
{
    public class AddressBookService : IAddressBookService
    {
        private Dictionary<string, AddressBook> addressBooks =
            new Dictionary<string, AddressBook>();

        public event Action<string> OnContactAdded;

        public void AddAddressBook(string name)
        {
            if (!addressBooks.ContainsKey(name))
                addressBooks[name] = new AddressBook { Name = name };
            else
                Console.WriteLine("Address Book already exists!");
        }

        public void AddContact(string addressBookName, Contact contact)
        {
            if (!addressBooks.ContainsKey(addressBookName))
            {
                Console.WriteLine("Address Book does not exist!");
                return;
            }

            AddressBook ab = addressBooks[addressBookName];
            foreach (Contact c in ab.Contacts)
            {
                if (c.FirstName == contact.FirstName && c.LastName == contact.LastName)
                {
                    Console.WriteLine("Duplicate Contact Found! Cannot add.");
                    return;
                }
            }

            ab.Contacts.Add(contact);
            OnContactAdded?.Invoke(contact.FirstName + " " + contact.LastName);
        }

        public void EditContact(
            string addressBookName,
            string firstName,
            string lastName,
            Contact updatedContact
        )
        {
            if (!addressBooks.ContainsKey(addressBookName))
                return;

            AddressBook ab = addressBooks[addressBookName];
            foreach (Contact c in ab.Contacts)
            {
                if (c.FirstName == firstName && c.LastName == lastName)
                {
                    c.FirstName = updatedContact.FirstName;
                    c.LastName = updatedContact.LastName;
                    c.Address = updatedContact.Address;
                    c.City = updatedContact.City;
                    c.State = updatedContact.State;
                    c.Zip = updatedContact.Zip;
                    c.PhoneNumber = updatedContact.PhoneNumber;
                    c.Email = updatedContact.Email;
                    Console.WriteLine("Contact Updated Successfully!");
                    return;
                }
            }
            Console.WriteLine("Contact Not Found!");
        }

        public void DeleteContact(string addressBookName, string firstName, string lastName)
        {
            if (!addressBooks.ContainsKey(addressBookName))
                return;

            AddressBook ab = addressBooks[addressBookName];
            int removed = ab.Contacts.RemoveAll(c =>
                c.FirstName == firstName && c.LastName == lastName
            );
            if (removed > 0)
                Console.WriteLine("Contact Deleted Successfully!");
            else
                Console.WriteLine("Contact Not Found!");
        }

        public List<Contact> SearchByCityOrState(string location)
        {
            List<Contact> result = new List<Contact>();
            foreach (AddressBook ab in addressBooks.Values)
            {
                foreach (Contact c in ab.Contacts)
                {
                    if (
                        c.City.Equals(location, StringComparison.OrdinalIgnoreCase)
                        || c.State.Equals(location, StringComparison.OrdinalIgnoreCase)
                    )
                        result.Add(c);
                }
            }
            return result;
        }

        public List<Contact> ViewByCityOrState(string location) => SearchByCityOrState(location);

        public int CountByCityOrState(string location)
        {
            int count = 0;
            foreach (AddressBook ab in addressBooks.Values)
            {
                foreach (Contact c in ab.Contacts)
                {
                    if (
                        c.City.Equals(location, StringComparison.OrdinalIgnoreCase)
                        || c.State.Equals(location, StringComparison.OrdinalIgnoreCase)
                    )
                        count++;
                }
            }
            return count;
        }

        public void SortByName(string addressBookName)
        {
            if (!addressBooks.ContainsKey(addressBookName))
                return;
            AddressBook ab = addressBooks[addressBookName];

            for (int i = 0; i < ab.Contacts.Count - 1; i++)
            {
                for (int j = 0; j < ab.Contacts.Count - i - 1; j++)
                {
                    if (string.Compare(ab.Contacts[j].FirstName, ab.Contacts[j + 1].FirstName) > 0)
                    {
                        Contact temp = ab.Contacts[j];
                        ab.Contacts[j] = ab.Contacts[j + 1];
                        ab.Contacts[j + 1] = temp;
                    }
                }
            }
        }

        public void SortByCityStateZip(string addressBookName)
        {
            if (!addressBooks.ContainsKey(addressBookName))
                return;
            AddressBook ab = addressBooks[addressBookName];

            for (int i = 0; i < ab.Contacts.Count - 1; i++)
            {
                for (int j = 0; j < ab.Contacts.Count - i - 1; j++)
                {
                    string key1 = ab.Contacts[j].City + ab.Contacts[j].State + ab.Contacts[j].Zip;
                    string key2 =
                        ab.Contacts[j + 1].City + ab.Contacts[j + 1].State + ab.Contacts[j + 1].Zip;
                    if (string.Compare(key1, key2) > 0)
                    {
                        Contact temp = ab.Contacts[j];
                        ab.Contacts[j] = ab.Contacts[j + 1];
                        ab.Contacts[j + 1] = temp;
                    }
                }
            }
        }

        public List<string> GetAddressBookNames()
        {
            List<string> names = new List<string>();
            foreach (string key in addressBooks.Keys)
                names.Add(key);
            return names;
        }
    }
}
