using System;
using System.Collections.Generic;

class AddressBooks<T>
    where T : IContactEntity
{
    private List<ContactUtility<T>> books = new List<ContactUtility<T>>();

    public void AddBook()
    {
        Console.Write("Enter the name for a new address book: ");
        string name = Console.ReadLine();

        if (books.Exists(b => b.BookName.Equals(name, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Address Book with this name already exists.");
            return;
        }

        books.Add(new ContactUtility<T>(name));
        Console.WriteLine($"Address Book '{name}' added successfully!");
    }

    public void ListBook()
    {
        Console.WriteLine("All Address Books:");
        foreach (var b in books)
            Console.WriteLine(b.BookName);
    }

    public ContactUtility<T> GetBookByName(string name)
    {
        return books.Find(b => b.BookName.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public void SearchPersonAcrossBooks()
    {
        Console.Write("Enter City (or leave empty): ");
        string city = Console.ReadLine();
        Console.Write("Enter State (or leave empty): ");
        string state = Console.ReadLine();

        Console.WriteLine("\nSearch Results:");
        bool found = false;

        foreach (var book in books)
            found = book.SearchContact(city, state) || found;

        if (!found)
            Console.WriteLine("No matching person found.");
    }

    public void ViewPersonsAcrossBooks()
    {
        Console.WriteLine("View by:\n1. City\n2. State");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();
            foreach (var book in books)
                book.ViewPersonsByCity(city);
        }
        else if (choice == "2")
        {
            Console.Write("Enter State: ");
            string state = Console.ReadLine();
            foreach (var book in books)
                book.ViewPersonsByState(state);
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }

    public void CountPersonsAcrossBooks()
    {
        Console.WriteLine("Count by:\n1. City\n2. State");
        string choice = Console.ReadLine();
        int totalCount = 0;

        if (choice == "1")
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();
            foreach (var book in books)
                totalCount += book.CountByCity(city);
            Console.WriteLine($"\nTotal persons in city '{city}': {totalCount}");
        }
        else if (choice == "2")
        {
            Console.Write("Enter State: ");
            string state = Console.ReadLine();
            foreach (var book in books)
                totalCount += book.CountByState(state);
            Console.WriteLine($"\nTotal persons in state '{state}': {totalCount}");
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }
}
