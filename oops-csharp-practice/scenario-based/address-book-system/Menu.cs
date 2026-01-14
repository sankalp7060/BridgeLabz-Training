using System;

class Menu
{
    private AddressBooks systemBooks = new AddressBooks();

    public void Show()
    {
        while (true)
        {
            Console.WriteLine("\n--- Address Book System ---");
            Console.WriteLine("1. Add New Address Book");
            Console.WriteLine("2. List Address Books");
            Console.WriteLine("3. Edit Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Add Multiple Contacts");
            Console.WriteLine("6. Search Person By City/State");
            Console.WriteLine("7. View Persons By City/State Across Books");
            Console.WriteLine("8. Count Persons By City/State Across Books");
            Console.WriteLine("9. Sort Contacts in an Address Book");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    systemBooks.AddBook();
                    break;

                case "2":
                    systemBooks.ListBook();
                    break;

                case "3":
                    systemBooks.EditContactInBook(); // call method in AddressBooks
                    break;

                case "4":
                    systemBooks.DeleteContactInBook(); // call method in AddressBooks
                    break;

                case "5":
                    systemBooks.AddMultipleContactsToBook(); // call method in AddressBooks
                    break;

                case "6":
                    systemBooks.SearchPersonAcrossBooks();
                    break;

                case "7":
                    systemBooks.ViewPersonsAcrossBooks();
                    break;

                case "8":
                    systemBooks.CountPersonsAcrossBooks();
                    break;

                case "9":
                    systemBooks.SortContactsInBook(); // call method in AddressBooks
                    break;

                case "0":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    break;
            }
        }
    }
}
