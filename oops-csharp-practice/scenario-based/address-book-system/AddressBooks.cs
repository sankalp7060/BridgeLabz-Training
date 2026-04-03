using System;

class AddressBooks : IAddressBook
{
    private ContactUtility[] books = new ContactUtility[10];
    private int count = 0;

    public void AddBook()
    {
        if (count >= books.Length)
        {
            Console.WriteLine("Cannot add more Address Books.");
            return;
        }
        Console.WriteLine("Enter the name for a new address book:- ");
        string name = Console.ReadLine();

        for (int i = 0; i < count; i++)
        {
            if (books[i].BookName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Address Book with this name is already exist.");
                return;
            }
        }
        books[count] = new ContactUtility(name);
        count++;
        Console.WriteLine($"Address Book '{name}' added successfully!");
    }

    public void ListBook()
    {
        Console.WriteLine("All address books:- ");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(books[i].BookName);
        }
    }

    public void SearchPersonAcrossBooks()
    {
        Console.WriteLine("Enter the city name:- ");
        string city = Console.ReadLine();
        Console.WriteLine("Enter the state name:- ");
        string state = Console.ReadLine();
        Console.WriteLine("\nSearch Results:");
        bool found = false;

        for (int i = 0; i < count; i++)
        {
            found = books[i].SearchContact(city, state) || found;
        }
        if (!found)
        {
            Console.WriteLine("No matching person found.");
        }
    }

    public void ViewPersonsAcrossBooks()
    {
        Console.WriteLine("View by:\n1. City\n2. State");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            Console.WriteLine($"\nPersons in City: {city}");

            for (int i = 0; i < count; i++)
            {
                books[i].ViewPersonsByCity(city);
            }
        }
        else if (choice == "2")
        {
            Console.Write("Enter State: ");
            string state = Console.ReadLine();

            Console.WriteLine($"\nPersons in State: {state}");

            for (int i = 0; i < count; i++)
            {
                books[i].ViewPersonsByState(state);
            }
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }

    public void CountPersonsAcrossBooks()
    {
        Console.WriteLine("View by:\n1. City\n2. State");
        string choice = Console.ReadLine();

        int totalCount = 0;

        if (choice == "1")
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            Console.WriteLine($"\nPersons in City: {city}");

            for (int i = 0; i < count; i++)
            {
                totalCount += books[i].CountByCity(city);
            }
            Console.WriteLine($"\nTotal persons in city '{city}': {totalCount}");
        }
        else if (choice == "2")
        {
            Console.Write("Enter State: ");
            string state = Console.ReadLine();

            Console.WriteLine($"\nPersons in State: {state}");

            for (int i = 0; i < count; i++)
            {
                totalCount += books[i].CountByState(state);
            }
            Console.WriteLine($"\nTotal persons in state '{state}': {totalCount}");
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }

    public void EditContactInBook()
    {
        var book = SelectBook();
        if (book != null)
            book.EditContact();
    }

    public void DeleteContactInBook()
    {
        var book = SelectBook();
        if (book != null)
            book.DeleteContact();
    }

    public void AddMultipleContactsToBook()
    {
        var book = SelectBook();
        if (book != null)
            book.AddMultipleContact();
    }

    public void SortContactsInBook()
    {
        var book = SelectBook();
        if (book != null)
            book.SortContactsByName();
    }

    private ContactUtility SelectBook()
    {
        Console.Write("Enter Address Book Name: ");
        string name = Console.ReadLine();
        for (int i = 0; i < count; i++)
            if (books[i].BookName.Equals(name, StringComparison.OrdinalIgnoreCase))
                return books[i];
        Console.WriteLine("Address Book not found!");
        return null;
    }
}
