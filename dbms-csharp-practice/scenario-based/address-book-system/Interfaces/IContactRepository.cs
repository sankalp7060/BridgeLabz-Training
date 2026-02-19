using System.Collections.Generic;
using AddressBookSystem.Models;

namespace AddressBookSystem.Interfaces
{
    public interface IContactRepository
    {
        bool AddContact(Contact contact);
        bool UpdateContact(Contact contact);
        bool DeleteContact(int contactId);
        Contact GetContactByName(int addressBookId, string firstName, string lastName);
        List<Contact> GetAllContacts(int addressBookId);
        bool ContactExists(int addressBookId, string firstName, string lastName);
        List<Contact> SearchPersonsByCityOrState(string city, string state);
        Dictionary<string, List<Contact>> GetPersonsByCity();
        Dictionary<string, List<Contact>> GetPersonsByState();
        int GetCountByCity(string city);
        int GetCountByState(string state);
        List<Contact> SortContactsByName(int addressBookId);
    }
}
