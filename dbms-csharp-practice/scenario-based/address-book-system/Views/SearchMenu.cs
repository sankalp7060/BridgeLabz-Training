using System;
using System.Collections.Generic;
using AddressBookSystem.Interfaces;
using AddressBookSystem.Models;

namespace AddressBookSystem.Views
{
    public class SearchMenu
    {
        private readonly IContactService _contactService;

        public SearchMenu(IContactService contactService)
        {
            _contactService = contactService;
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
                        SearchByCityOrState();
                        break;
                    case "2":
                        _contactService.DisplayPersonsByCity();
                        break;
                    case "3":
                        _contactService.DisplayPersonsByState();
                        break;
                    case "4":
                        GetCountByCity();
                        break;
                    case "5":
                        GetCountByState();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private void Display()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("    SEARCH AND VIEW ACROSS BOOKS");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Search Persons by City or State");
            Console.WriteLine("2. View Persons by City");
            Console.WriteLine("3. View Persons by State");
            Console.WriteLine("4. Get Count by City");
            Console.WriteLine("5. Get Count by State");
            Console.WriteLine("6. Back to Main Menu");
            Console.WriteLine("\n========================================");
            Console.Write("Enter your choice: ");
        }

        private void SearchByCityOrState()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("         SEARCH PERSONS");
            Console.WriteLine("========================================");

            Console.Write("Enter City (or press Enter to skip): ");
            string city = Console.ReadLine();

            Console.Write("Enter State (or press Enter to skip): ");
            string state = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(city) && string.IsNullOrWhiteSpace(state))
            {
                Console.WriteLine("\nPlease enter at least one search criterion.");
                return;
            }

            List<Contact> results = _contactService.SearchPersonsByCityOrState(city, state);

            Console.WriteLine($"\nFound {results.Count} matching contact(s):");
            Console.WriteLine("------------------------");

            foreach (Contact contact in results)
            {
                DisplaySearchResult(contact);
                Console.WriteLine("------------------------");
            }
        }

        private void GetCountByCity()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("          COUNT BY CITY");
            Console.WriteLine("========================================");

            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            int count = _contactService.GetCountByCity(city);
            Console.WriteLine($"\nNumber of contacts in {city}: {count}");
        }

        private void GetCountByState()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("         COUNT BY STATE");
            Console.WriteLine("========================================");

            Console.Write("Enter State: ");
            string state = Console.ReadLine();

            int count = _contactService.GetCountByState(state);
            Console.WriteLine($"\nNumber of contacts in {state}: {count}");
        }

        private void DisplaySearchResult(Contact contact)
        {
            Console.WriteLine($"Name: {contact.FullName}");
            Console.WriteLine($"City: {contact.City}");
            Console.WriteLine($"State: {contact.State}");
            Console.WriteLine($"Phone: {contact.Phone}");
            Console.WriteLine($"Email: {contact.Email}");
        }
    }
}
