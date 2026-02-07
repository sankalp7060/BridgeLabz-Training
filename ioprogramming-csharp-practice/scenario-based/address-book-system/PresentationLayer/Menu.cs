using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AddressBookSystem.DataAccess;
using AddressBookSystem.Entities;
using AddressBookSystem.Services;

namespace AddressBookSystem.Menu
{
    public class MenuHandler
    {
        private readonly AddressBookService service;
        private readonly CsvDataSource csvSource;
        private readonly JsonFileDataSource jsonSource;

        public MenuHandler()
        {
            service = new AddressBookService();
            csvSource = new CsvDataSource();
            jsonSource = new JsonFileDataSource();
            service.OnContactAdded += name => Console.WriteLine($"[EVENT] Contact Added: {name}");
        }

        public async Task ShowMenuAsync()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--- Address Book Menu ---");
                Console.WriteLine("1. Add Address Book");
                Console.WriteLine("2. Add Contact");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Search by City/State");
                Console.WriteLine("6. View by City/State");
                Console.WriteLine("7. Count by City/State");
                Console.WriteLine("8. Sort by Name");
                Console.WriteLine("9. Sort by City/State/Zip");
                Console.WriteLine("10. Save Address Book to CSV");
                Console.WriteLine("11. Load Address Book from CSV");
                Console.WriteLine("12. Save Address Book to JSON");
                Console.WriteLine("13. Load Address Book from JSON");
                Console.WriteLine("14. Exit");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Address Book Name: ");
                        string abName = Console.ReadLine();
                        service.AddAddressBook(abName);
                        break;
                    case "2":
                        await AddContactAsync();
                        break;
                    case "3":
                        await EditContactAsync();
                        break;
                    case "4":
                        await DeleteContactAsync();
                        break;
                    case "5":
                        await SearchAsync();
                        break;
                    case "6":
                        await ViewAsync();
                        break;
                    case "7":
                        await CountAsync();
                        break;
                    case "8":
                        SortByName();
                        break;
                    case "9":
                        SortByCityStateZip();
                        break;
                    case "10":
                        await SaveCsvAsync();
                        break;
                    case "11":
                        await LoadCsvAsync();
                        break;
                    case "12":
                        await SaveJsonAsync();
                        break;
                    case "13":
                        await LoadJsonAsync();
                        break;
                    case "14":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            }
        }

        private async Task AddContactAsync()
        {
            Console.Write("Address Book Name: ");
            string abName = Console.ReadLine();
            Contact newContact = new Contact();
            Console.Write("First Name: ");
            newContact.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            newContact.LastName = Console.ReadLine();
            Console.Write("Address: ");
            newContact.Address = Console.ReadLine();
            Console.Write("City: ");
            newContact.City = Console.ReadLine();
            Console.Write("State: ");
            newContact.State = Console.ReadLine();
            Console.Write("Zip: ");
            newContact.Zip = Console.ReadLine();
            Console.Write("Phone: ");
            newContact.PhoneNumber = Console.ReadLine();
            Console.Write("Email: ");
            newContact.Email = Console.ReadLine();

            // Add contact on a separate thread
            await Task.Run(() => service.AddContact(abName, newContact));
        }

        private async Task EditContactAsync()
        {
            Console.Write("Address Book Name: ");
            string abName = Console.ReadLine();
            Console.Write("First Name to Edit: ");
            string fName = Console.ReadLine();
            Console.Write("Last Name to Edit: ");
            string lName = Console.ReadLine();

            Contact updated = new Contact();
            Console.Write("New First Name: ");
            updated.FirstName = Console.ReadLine();
            Console.Write("New Last Name: ");
            updated.LastName = Console.ReadLine();
            Console.Write("New Address: ");
            updated.Address = Console.ReadLine();
            Console.Write("New City: ");
            updated.City = Console.ReadLine();
            Console.Write("New State: ");
            updated.State = Console.ReadLine();
            Console.Write("New Zip: ");
            updated.Zip = Console.ReadLine();
            Console.Write("New Phone: ");
            updated.PhoneNumber = Console.ReadLine();
            Console.Write("New Email: ");
            updated.Email = Console.ReadLine();

            await Task.Run(() => service.EditContact(abName, fName, lName, updated));
        }

        private async Task DeleteContactAsync()
        {
            Console.Write("Address Book Name: ");
            string abName = Console.ReadLine();
            Console.Write("First Name to Delete: ");
            string fName = Console.ReadLine();
            Console.Write("Last Name to Delete: ");
            string lName = Console.ReadLine();

            await Task.Run(() => service.DeleteContact(abName, fName, lName));
        }

        private async Task SearchAsync()
        {
            Console.Write("City or State to Search: ");
            string loc = Console.ReadLine();
            List<Contact> results = null;

            await Task.Run(() =>
            {
                results = service.SearchByCityOrState(loc);
            });

            if (results.Count == 0)
                Console.WriteLine("No contacts found.");
            else
            {
                foreach (Contact c in results)
                    Console.WriteLine(c);
            }
        }

        private async Task ViewAsync()
        {
            Console.Write("City or State to View: ");
            string loc = Console.ReadLine();
            List<Contact> results = null;

            await Task.Run(() =>
            {
                results = service.ViewByCityOrState(loc);
            });

            if (results.Count == 0)
                Console.WriteLine("No contacts found.");
            else
            {
                foreach (Contact c in results)
                    Console.WriteLine(c);
            }
        }

        private async Task CountAsync()
        {
            Console.Write("City or State to Count: ");
            string loc = Console.ReadLine();
            int count = 0;

            await Task.Run(() =>
            {
                count = service.CountByCityOrState(loc);
            });

            Console.WriteLine($"Total Contacts: {count}");
        }

        private void SortByName()
        {
            Console.Write("Address Book Name to Sort by Name: ");
            string abName = Console.ReadLine();
            service.SortByName(abName);
            Console.WriteLine("Sorted Successfully!");
        }

        private void SortByCityStateZip()
        {
            Console.Write("Address Book Name to Sort by City/State/Zip: ");
            string abName = Console.ReadLine();
            service.SortByCityStateZip(abName);
            Console.WriteLine("Sorted Successfully!");
        }

        private async Task SaveCsvAsync()
        {
            Console.Write("Address Book Name to Save CSV: ");
            string abName = Console.ReadLine();
            if (service.GetAddressBookNames().Contains(abName))
            {
                AddressBook ab = await csvSource.LoadAsync(abName); // Load existing to preserve
                await csvSource.SaveAsync(ab);
                Console.WriteLine("CSV Saved Successfully!");
            }
            else
                Console.WriteLine("Address Book not found!");
        }

        private async Task LoadCsvAsync()
        {
            Console.Write("Address Book Name to Load CSV: ");
            string abName = Console.ReadLine();
            AddressBook loaded = await csvSource.LoadAsync(abName);
            service.AddAddressBook(abName);
            foreach (Contact c in loaded.Contacts)
                service.AddContact(abName, c);

            Console.WriteLine("CSV Loaded Successfully!");
        }

        private async Task SaveJsonAsync()
        {
            Console.Write("Address Book Name to Save JSON: ");
            string abName = Console.ReadLine();
            if (service.GetAddressBookNames().Contains(abName))
            {
                AddressBook ab = await jsonSource.LoadAsync(abName);
                await jsonSource.SaveAsync(ab);
                Console.WriteLine("JSON Saved Successfully!");
            }
            else
                Console.WriteLine("Address Book not found!");
        }

        private async Task LoadJsonAsync()
        {
            Console.Write("Address Book Name to Load JSON: ");
            string abName = Console.ReadLine();
            AddressBook loaded = await jsonSource.LoadAsync(abName);
            service.AddAddressBook(abName);
            foreach (Contact c in loaded.Contacts)
                service.AddContact(abName, c);

            Console.WriteLine("JSON Loaded Successfully!");
        }
    }
}
