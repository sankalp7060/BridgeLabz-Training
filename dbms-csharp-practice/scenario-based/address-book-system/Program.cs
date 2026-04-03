using System;
using AddressBookSystem.Interfaces;
using AddressBookSystem.Services;
using AddressBookSystem.Views;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Initialize services
                IAddressBookService addressBookService = new AddressBookService();
                IContactService contactService = new ContactService(addressBookService);

                // Initialize and show main menu
                MainMenu mainMenu = new MainMenu(addressBookService, contactService);
                mainMenu.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
