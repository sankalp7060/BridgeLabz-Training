using System;

sealed class Menu
{
    public void Show()
    {
        Console.WriteLine("Welcome to Address Book Program\n");

        AddressBooks system = new AddressBooks();

        while (true)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Add Address Book");
            Console.WriteLine("2. List Address Books");
            Console.WriteLine("3. Manage Address Book");
            Console.WriteLine("4. Search Person Across Books");
            Console.WriteLine("5. View Persons Across Books");
            Console.WriteLine("6. Count Persons Across Books");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine().Trim();

            switch (choice)
            {
                case "1":
                    system.AddBook();
                    break;
                case "2":
                    system.ListBook();
                    break;
                case "3":
                    ManageAddressBook(system);
                    break;
                case "4":
                    system.SearchPersonAcrossBooks();
                    break;
                case "5":
                    system.ViewPersonsAcrossBooks();
                    break;
                case "6":
                    system.CountPersonsAcrossBooks();
                    break;
                case "7":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    static void ManageAddressBook(AddressBooks system)
    {
        Console.Write("Enter Address Book Name to manage: ");
        string name = Console.ReadLine();
        ContactUtility book = system.GetBookByName(name);

        if (book == null)
        {
            Console.WriteLine("Address Book not found!");
            return;
        }

        while (true)
        {
            Console.WriteLine($"\n--- Menu for '{book.BookName}' ---");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Add Multiple Contacts");
            Console.WriteLine("5. Sort Contacts");
            Console.WriteLine("6. View Contacts by City");
            Console.WriteLine("7. View Contacts by State");
            Console.WriteLine("8. Go Back");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine().Trim();
            switch (choice)
            {
                case "1":
                    book.AddContact();
                    break;
                case "2":
                    book.EditContact();
                    break;
                case "3":
                    book.DeleteContact();
                    break;
                case "4":
                    book.AddMultipleContact();
                    break;
                case "5":
                    SortMenu(book);
                    break;
                case "6":
                    Console.Write("Enter City: ");
                    book.ViewPersonsByCity(Console.ReadLine());
                    break;
                case "7":
                    Console.Write("Enter State: ");
                    book.ViewPersonsByState(Console.ReadLine());
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    static void SortMenu(ContactUtility book)
    {
        Console.WriteLine("\n--- Sort Contacts ---");
        Console.WriteLine("1. By Name");
        Console.WriteLine("2. By City");
        Console.WriteLine("3. By State");
        Console.WriteLine("4. By Zip");
        Console.Write("Choose an option: ");

        string choice = Console.ReadLine().Trim();
        switch (choice)
        {
            case "1":
                book.SortContactsByName();
                break;
            case "2":
                book.SortContactsByCity();
                break;
            case "3":
                book.SortContactsByState();
                break;
            case "4":
                book.SortContactsByZip();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }
}
