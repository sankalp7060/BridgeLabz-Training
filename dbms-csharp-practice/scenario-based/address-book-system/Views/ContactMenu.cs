using System;
using System.Collections.Generic;
using AddressBookSystem.Interfaces;
using AddressBookSystem.Models;

namespace AddressBookSystem.Views
{
    public class ContactMenu
    {
        private readonly IContactService _contactService;
        private readonly IAddressBookService _addressBookService;

        public ContactMenu(IContactService contactService, IAddressBookService addressBookService)
        {
            _contactService = contactService;
            _addressBookService = addressBookService;
        }

        public void Show()
        {
            while (true)
            {
                Display();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        EditContact();
                        break;
                    case "3":
                        DeleteContact();
                        break;
                    case "4":
                        ViewAllContacts();
                        break;
                    case "5":
                        SortContacts();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void Display()
        {
            Console.Clear();
            var current = _addressBookService.GetCurrentAddressBook();
            Console.WriteLine("========================================");
            Console.WriteLine($"     MANAGE CONTACTS - {current.Name}");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. View All Contacts");
            Console.WriteLine("5. Sort Contacts by Name");
            Console.WriteLine("6. Back to Main Menu");
            Console.WriteLine("\n========================================");
            Console.Write("Enter your choice: ");
        }

        private void AddContact()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("           ADD CONTACT");
            Console.WriteLine("========================================");

            Contact contact = GetContactInput();
            _contactService.AddContact(contact);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void EditContact()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("          EDIT CONTACT");
            Console.WriteLine("========================================");

            Console.Write("Enter First Name of contact to edit: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name of contact to edit: ");
            string lastName = Console.ReadLine();

            Contact existing = _contactService.GetContact(firstName, lastName);
            if (existing == null)
            {
                Console.WriteLine("\nContact not found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nEnter new details (press Enter to keep current value):");
            Contact updated = GetContactInputWithExisting(existing);

            _contactService.EditContact(firstName, lastName, updated);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void DeleteContact()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("          DELETE CONTACT");
            Console.WriteLine("========================================");

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            _contactService.DeleteContact(firstName, lastName);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void ViewAllContacts()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("          ALL CONTACTS");
            Console.WriteLine("========================================");

            List<Contact> contacts = _contactService.GetAllContacts();

            if (contacts.Count == 0)
            {
                Console.WriteLine("\nNo contacts found.");
            }
            else
            {
                foreach (Contact contact in contacts)
                {
                    DisplayContact(contact);
                    Console.WriteLine("------------------------");
                }
                Console.WriteLine($"\nTotal Contacts: {contacts.Count}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void SortContacts()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("     SORTED CONTACTS (Alphabetical)");
            Console.WriteLine("========================================");

            List<Contact> contacts = _contactService.SortContacts();

            if (contacts.Count == 0)
            {
                Console.WriteLine("\nNo contacts found.");
            }
            else
            {
                foreach (Contact contact in contacts)
                {
                    Console.WriteLine($"• {contact.FullName} - {contact.City}, {contact.State}");
                }
                Console.WriteLine($"\nTotal Contacts: {contacts.Count}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private Contact GetContactInput()
        {
            Contact contact = new Contact();

            Console.Write("First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Address: ");
            contact.Address = Console.ReadLine();

            Console.Write("City: ");
            contact.City = Console.ReadLine();

            Console.Write("State: ");
            contact.State = Console.ReadLine();

            Console.Write("ZIP: ");
            contact.Zip = Console.ReadLine();

            Console.Write("Phone: ");
            contact.Phone = Console.ReadLine();

            Console.Write("Email: ");
            contact.Email = Console.ReadLine();

            return contact;
        }

        private Contact GetContactInputWithExisting(Contact existing)
        {
            Contact contact = new Contact();

            Console.Write($"First Name [{existing.FirstName}]: ");
            string input = Console.ReadLine();
            contact.FirstName = string.IsNullOrWhiteSpace(input) ? existing.FirstName : input;

            Console.Write($"Last Name [{existing.LastName}]: ");
            input = Console.ReadLine();
            contact.LastName = string.IsNullOrWhiteSpace(input) ? existing.LastName : input;

            Console.Write($"Address [{existing.Address}]: ");
            input = Console.ReadLine();
            contact.Address = string.IsNullOrWhiteSpace(input) ? existing.Address : input;

            Console.Write($"City [{existing.City}]: ");
            input = Console.ReadLine();
            contact.City = string.IsNullOrWhiteSpace(input) ? existing.City : input;

            Console.Write($"State [{existing.State}]: ");
            input = Console.ReadLine();
            contact.State = string.IsNullOrWhiteSpace(input) ? existing.State : input;

            Console.Write($"ZIP [{existing.Zip}]: ");
            input = Console.ReadLine();
            contact.Zip = string.IsNullOrWhiteSpace(input) ? existing.Zip : input;

            Console.Write($"Phone [{existing.Phone}]: ");
            input = Console.ReadLine();
            contact.Phone = string.IsNullOrWhiteSpace(input) ? existing.Phone : input;

            Console.Write($"Email [{existing.Email}]: ");
            input = Console.ReadLine();
            contact.Email = string.IsNullOrWhiteSpace(input) ? existing.Email : input;

            return contact;
        }

        private void DisplayContact(Contact contact)
        {
            Console.WriteLine($"Name: {contact.FullName}");
            Console.WriteLine($"Address: {contact.Address}");
            Console.WriteLine($"City: {contact.City}");
            Console.WriteLine($"State: {contact.State}");
            Console.WriteLine($"ZIP: {contact.Zip}");
            Console.WriteLine($"Phone: {contact.Phone}");
            Console.WriteLine($"Email: {contact.Email}");
        }
    }
}
