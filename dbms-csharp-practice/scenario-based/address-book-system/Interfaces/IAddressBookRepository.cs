using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface IAddressBookRepository
    {
        void AddAddressBook(string name);
        List<AddressBook> GetAllAddressBooks();
    }
}
