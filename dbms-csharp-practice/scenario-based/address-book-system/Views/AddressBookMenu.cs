using System;
using System.Collections.Generic;
using AddressBookSystem.Interfaces;

namespace AddressBookSystem.Views
{
    public class AddressBookMenu
    {
        private readonly IAddressBookService _addressBookService;

        public AddressBookMenu(IAddressBookService addressBookService)
        {
            _addressBookService = addressBookService;
        }

        public void CreateAddressBook()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        CREATE ADDRESS BOOK");
            Console.WriteLine("========================================");
            Console.Write("Enter Address Book Name: ");
            string name = Console.ReadLine();

            _addressBookService.CreateAddressBook(name);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void SelectAddressBook()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        SELECT ADDRESS BOOK");
            Console.WriteLine("========================================");

            List<string> books = _addressBookService.GetAllAddressBookNames();

            if (books.Count == 0)
            {
                Console.WriteLine("\nNo address books available. Create one first.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nAvailable Address Books:");
            Console.WriteLine("------------------------");
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i]}");
            }

            Console.Write("\nSelect Address Book (number): ");
            if (
                int.TryParse(Console.ReadLine(), out int choice)
                && choice > 0
                && choice <= books.Count
            )
            {
                _addressBookService.SetCurrentAddressBook(books[choice - 1]);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void ListAllAddressBooks()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        ALL ADDRESS BOOKS");
            Console.WriteLine("========================================");

            List<string> books = _addressBookService.GetAllAddressBookNames();

            if (books.Count == 0)
            {
                Console.WriteLine("\nNo address books found.");
            }
            else
            {
                Console.WriteLine($"\nTotal Address Books: {books.Count}");
                Console.WriteLine("------------------------");
                foreach (string book in books)
                {
                    Console.WriteLine($"• {book}");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
