using System.Threading.Tasks;
using AddressBookSystem.Entities;

namespace AddressBookSystem.DataAccess
{
    public interface IDataSource
    {
        Task SaveAsync(AddressBook addressBook);
        Task<AddressBook> LoadAsync(string addressBookName);
    }
}
