using System.Collections.Generic;
using AddressBookSystem.Entities;

namespace AddressBookSystem.Services
{
    public interface IAddressBookService
    {
        void AddAddressBook(string name);
        void AddContact(string addressBookName, Contact contact);
        void EditContact(
            string addressBookName,
            string firstName,
            string lastName,
            Contact updatedContact
        );
        void DeleteContact(string addressBookName, string firstName, string lastName);
        List<Contact> SearchByCityOrState(string location);
        List<Contact> ViewByCityOrState(string location);
        int CountByCityOrState(string location);
        void SortByName(string addressBookName);
        void SortByCityStateZip(string addressBookName);
        List<string> GetAddressBookNames();
        event System.Action<string> OnContactAdded;
    }
}
