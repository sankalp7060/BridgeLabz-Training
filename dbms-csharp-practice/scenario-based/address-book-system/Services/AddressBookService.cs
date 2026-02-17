using System.Collections.Generic;
using Interfaces;
using Models;

namespace Services
{
    public class AddressBookService
    {
        private readonly IContactRepository contactRepo;
        private readonly IAddressBookRepository addressRepo;

        public AddressBookService(IContactRepository c, IAddressBookRepository a)
        {
            contactRepo = c;
            addressRepo = a;
        }

        public void AddContact(Contact c) => contactRepo.AddContact(c);

        public void EditContact(Contact c) => contactRepo.EditContact(c);

        public void DeleteContact(string f, string l) => contactRepo.DeleteContact(f, l);

        public List<Contact> SearchCity(string city) => contactRepo.GetByCity(city);

        public int CountCity(string city) => contactRepo.CountByCity(city);
    }
}
