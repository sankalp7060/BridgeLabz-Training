using System;

class AddressBooks
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

        Console.Write("Enter the name for a new address book: ");
        string name = Console.ReadLine();

        for (int i = 0; i < count; i++)
        {
            if (books[i].BookName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Address Book with this name already exists.");
                return;
            }
        }

        books[count] = new ContactUtility(name);
        count++;
        Console.WriteLine($"Address Book '{name}' added successfully!");
    }

    public void ListBook()
    {
        Console.WriteLine("All address books:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(books[i].BookName);
        }
    }

    public void SearchPersonAcrossBooks()
    {
        Console.Write("Enter City: ");
        string city = Console.ReadLine();
        Console.Write("Enter State: ");
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
        string choice = Console.ReadLine().Trim();

        if (choice == "1")
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();
            for (int i = 0; i < count; i++)
                books[i].ViewPersonsByCity(city);
        }
        else if (choice == "2")
        {
            Console.Write("Enter State: ");
            string state = Console.ReadLine();
            for (int i = 0; i < count; i++)
                books[i].ViewPersonsByState(state);
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }

    public void CountPersonsAcrossBooks()
    {
        Console.WriteLine("Count by:\n1. City\n2. State");
        string choice = Console.ReadLine().Trim();
        int total = 0;

        if (choice == "1")
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();
            for (int i = 0; i < count; i++)
                total += books[i].CountByCity(city);
            Console.WriteLine($"Total persons in city '{city}': {total}");
        }
        else if (choice == "2")
        {
            Console.Write("Enter State: ");
            string state = Console.ReadLine();
            for (int i = 0; i < count; i++)
                total += books[i].CountByState(state);
            Console.WriteLine($"Total persons in state '{state}': {total}");
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }

    public ContactUtility GetBookByName(string name)
    {
        for (int i = 0; i < count; i++)
            if (books[i].BookName.Equals(name, StringComparison.OrdinalIgnoreCase))
                return books[i];
        return null;
    }
}
