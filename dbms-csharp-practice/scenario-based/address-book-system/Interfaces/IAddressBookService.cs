using System.Collections.Generic;
using AddressBookSystem.Models;

namespace AddressBookSystem.Interfaces
{
    public interface IAddressBookService
    {
        bool CreateAddressBook(string name);
        AddressBook GetCurrentAddressBook();
        bool SetCurrentAddressBook(string name);
        List<string> GetAllAddressBookNames();
    }
}
