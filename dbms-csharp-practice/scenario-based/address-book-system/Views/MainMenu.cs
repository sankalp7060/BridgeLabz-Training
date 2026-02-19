using System;
using AddressBookSystem.Interfaces;

namespace AddressBookSystem.Views
{
    public class MainMenu
    {
        private readonly IAddressBookService _addressBookService;
        private readonly IContactService _contactService;
        private readonly AddressBookMenu _addressBookMenu;
        private readonly ContactMenu _contactMenu;
        private readonly SearchMenu _searchMenu;

        public MainMenu(IAddressBookService addressBookService, IContactService contactService)
        {
            _addressBookService = addressBookService;
            _contactService = contactService;
            _addressBookMenu = new AddressBookMenu(_addressBookService);
            _contactMenu = new ContactMenu(_contactService, _addressBookService);
            _searchMenu = new SearchMenu(_contactService);
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
                        _addressBookMenu.CreateAddressBook();
                        break;
                    case "2":
                        _addressBookMenu.SelectAddressBook();
                        break;
                    case "3":
                        if (CheckAddressBookSelected())
                            _contactMenu.Show();
                        break;
                    case "4":
                        _searchMenu.Show();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
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
            Console.WriteLine("     ADDRESS BOOK SYSTEM");
            Console.WriteLine("========================================");
            Console.WriteLine($"Current Address Book: {(current != null ? current.Name : "None")}");
            Console.WriteLine("\n1. Create New Address Book");
            Console.WriteLine("2. Select Address Book");
            Console.WriteLine("3. Manage Contacts");
            Console.WriteLine("4. Search and View Across Books");
            Console.WriteLine("5. Exit");
            Console.WriteLine("\n========================================");
            Console.Write("Enter your choice: ");
        }

        private bool CheckAddressBookSelected()
        {
            if (_addressBookService.GetCurrentAddressBook() == null)
            {
                Console.WriteLine("\nPlease select or create an address book first.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return false;
            }
            return true;
        }
    }
}
