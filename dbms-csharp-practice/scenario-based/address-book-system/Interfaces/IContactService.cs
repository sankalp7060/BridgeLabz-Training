using System.Collections.Generic;
using AddressBookSystem.Models;

namespace AddressBookSystem.Interfaces
{
    public interface IContactService
    {
        bool AddContact(Contact contact);
        bool EditContact(string firstName, string lastName, Contact updatedContact);
        bool DeleteContact(string firstName, string lastName);
        Contact GetContact(string firstName, string lastName);
        List<Contact> GetAllContacts();
        List<Contact> SearchPersonsByCityOrState(string city, string state);
        void DisplayPersonsByCity();
        void DisplayPersonsByState();
        int GetCountByCity(string city);
        int GetCountByState(string state);
        List<Contact> SortContacts();
    }
}
