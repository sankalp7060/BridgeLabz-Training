using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
        void EditContact(Contact contact);
        void DeleteContact(string firstName, string lastName);

        List<Contact> GetByCity(string city);
        List<Contact> GetByState(string state);

        int CountByCity(string city);
        int CountByState(string state);

        List<Contact> SortByName(int addressBookId);
    }
}
