using System;
using System.Collections.Generic;
using System.Linq;
using AddressBookSystem.Interfaces;
using AddressBookSystem.Models;
using AddressBookSystem.Repositories;

namespace AddressBookSystem.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IAddressBookService _addressBookService;

        public ContactService(IAddressBookService addressBookService)
        {
            _contactRepository = new ContactRepository();
            _addressBookService = addressBookService;
        }

        public bool AddContact(Contact contact)
        {
            AddressBook currentBook = _addressBookService.GetCurrentAddressBook();
            if (currentBook == null)
            {
                Console.WriteLine(
                    "No address book selected. Please create or select an address book first."
                );
                return false;
            }

            contact.AddressBookId = currentBook.AddressBookId;

            if (_contactRepository.AddContact(contact))
            {
                Console.WriteLine("Contact added successfully.");
                return true;
            }
            else
            {
                Console.WriteLine(
                    $"Contact '{contact.FullName}' already exists in this address book."
                );
                return false;
            }
        }

        public bool EditContact(string firstName, string lastName, Contact updatedContact)
        {
            AddressBook currentBook = _addressBookService.GetCurrentAddressBook();
            if (currentBook == null)
            {
                Console.WriteLine("No address book selected.");
                return false;
            }

            Contact existingContact = _contactRepository.GetContactByName(
                currentBook.AddressBookId,
                firstName,
                lastName
            );
            if (existingContact == null)
            {
                Console.WriteLine($"Contact '{firstName} {lastName}' not found.");
                return false;
            }

            updatedContact.ContactId = existingContact.ContactId;
            updatedContact.AddressBookId = currentBook.AddressBookId;

            if (_contactRepository.UpdateContact(updatedContact))
            {
                Console.WriteLine("Contact updated successfully.");
                return true;
            }
            return false;
        }

        public bool DeleteContact(string firstName, string lastName)
        {
            AddressBook currentBook = _addressBookService.GetCurrentAddressBook();
            if (currentBook == null)
            {
                Console.WriteLine("No address book selected.");
                return false;
            }

            Contact contact = _contactRepository.GetContactByName(
                currentBook.AddressBookId,
                firstName,
                lastName
            );
            if (contact == null)
            {
                Console.WriteLine($"Contact '{firstName} {lastName}' not found.");
                return false;
            }

            if (_contactRepository.DeleteContact(contact.ContactId))
            {
                Console.WriteLine("Contact deleted successfully.");
                return true;
            }
            return false;
        }

        public Contact GetContact(string firstName, string lastName)
        {
            AddressBook currentBook = _addressBookService.GetCurrentAddressBook();
            if (currentBook == null)
            {
                Console.WriteLine("No address book selected.");
                return null;
            }

            return _contactRepository.GetContactByName(
                currentBook.AddressBookId,
                firstName,
                lastName
            );
        }

        public List<Contact> GetAllContacts()
        {
            AddressBook currentBook = _addressBookService.GetCurrentAddressBook();
            if (currentBook == null)
            {
                Console.WriteLine("No address book selected.");
                return new List<Contact>();
            }

            return _contactRepository.GetAllContacts(currentBook.AddressBookId);
        }

        public List<Contact> SearchPersonsByCityOrState(string city, string state)
        {
            return _contactRepository.SearchPersonsByCityOrState(city, state);
        }

        public void DisplayPersonsByCity()
        {
            var cityGroups = _contactRepository.GetPersonsByCity();
            foreach (var city in cityGroups)
            {
                Console.WriteLine($"\nCity: {city.Key} - {city.Value.Count} contact(s)");
                foreach (var contact in city.Value)
                {
                    Console.WriteLine(
                        $"  - {contact.FullName} (Book: {GetAddressBookName(contact.AddressBookId)})"
                    );
                }
            }
        }

        public void DisplayPersonsByState()
        {
            var stateGroups = _contactRepository.GetPersonsByState();
            foreach (var state in stateGroups)
            {
                Console.WriteLine($"\nState: {state.Key} - {state.Value.Count} contact(s)");
                foreach (var contact in state.Value)
                {
                    Console.WriteLine(
                        $"  - {contact.FullName} (Book: {GetAddressBookName(contact.AddressBookId)})"
                    );
                }
            }
        }

        public int GetCountByCity(string city)
        {
            return _contactRepository.GetCountByCity(city);
        }

        public int GetCountByState(string state)
        {
            return _contactRepository.GetCountByState(state);
        }

        public List<Contact> SortContacts()
        {
            AddressBook currentBook = _addressBookService.GetCurrentAddressBook();
            if (currentBook == null)
            {
                Console.WriteLine("No address book selected.");
                return new List<Contact>();
            }

            return _contactRepository.SortContactsByName(currentBook.AddressBookId);
        }

        private string GetAddressBookName(int addressBookId)
        {
            var repo = new AddressBookRepository();
            return repo.GetAllAddressBooks()
                    .FirstOrDefault(ab => ab.AddressBookId == addressBookId)
                    ?.Name
                ?? "Unknown";
        }
    }
}
