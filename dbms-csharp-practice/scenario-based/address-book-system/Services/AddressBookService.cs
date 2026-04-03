using System;
using System.Collections.Generic;
using System.Linq;
using AddressBookSystem.Interfaces;
using AddressBookSystem.Models;
using AddressBookSystem.Repositories;

namespace AddressBookSystem.Services
{
    public class AddressBookService : IAddressBookService
    {
        private readonly IAddressBookRepository _addressBookRepository;
        private AddressBook _currentAddressBook;

        public AddressBookService()
        {
            _addressBookRepository = new AddressBookRepository();
        }

        public bool CreateAddressBook(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Address book name cannot be empty.");
                return false;
            }

            if (_addressBookRepository.AddressBookExists(name))
            {
                Console.WriteLine($"Address book '{name}' already exists.");
                return false;
            }

            AddressBook newAddressBook = new AddressBook { Name = name };
            int id = _addressBookRepository.AddAddressBook(newAddressBook);

            if (id > 0)
            {
                _currentAddressBook = new AddressBook { AddressBookId = id, Name = name };
                Console.WriteLine($"Address book '{name}' created and set as current.");
                return true;
            }

            return false;
        }

        public AddressBook GetCurrentAddressBook()
        {
            return _currentAddressBook;
        }

        public bool SetCurrentAddressBook(string name)
        {
            AddressBook addressBook = _addressBookRepository.GetAddressBookByName(name);
            if (addressBook != null)
            {
                _currentAddressBook = addressBook;
                Console.WriteLine($"Current address book set to: {name}");
                return true;
            }
            Console.WriteLine($"Address book '{name}' not found.");
            return false;
        }

        public List<string> GetAllAddressBookNames()
        {
            return _addressBookRepository.GetAllAddressBooks().Select(ab => ab.Name).ToList();
        }
    }
}
