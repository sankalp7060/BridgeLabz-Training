using System.Collections.Generic;
using AddressBookSystem.Models;

namespace AddressBookSystem.Interfaces
{
    public interface IAddressBookRepository
    {
        int AddAddressBook(AddressBook addressBook);
        AddressBook GetAddressBookByName(string name);
        List<AddressBook> GetAllAddressBooks();
        bool AddressBookExists(string name);
    }
}
