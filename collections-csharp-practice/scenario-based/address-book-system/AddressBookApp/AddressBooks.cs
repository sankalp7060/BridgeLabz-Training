using System;
using System.Collections.Generic;

class AddressBooks<T>
    where T : Contact
{
    private List<ContactUtility<T>> books = new List<ContactUtility<T>>();

    public void AddBook()
    {
        Console.Write("Enter Address Book Name: ");
        string name = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Invalid name!");
            return;
        }

        if (GetBookByName(name) != null)
        {
            Console.WriteLine("Address Book already exists!");
            return;
        }

        books.Add(new ContactUtility<T>(name));
        Console.WriteLine($"Address Book '{name}' created successfully!");
    }

    public void ListBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No Address Books found!");
            return;
        }

        Console.WriteLine("\n--- List of Address Books ---");
        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {books[i].BookName}");
        }
    }

    public ContactUtility<T> GetBookByName(string name)
    {
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].BookName.Equals(name, StringComparison.OrdinalIgnoreCase))
                return books[i];
        }
        return null;
    }

    // Search across all books
    public void SearchPersonAcrossBooks()
    {
        Console.Write("Enter City (or leave blank): ");
        string city = Console.ReadLine();
        Console.Write("Enter State (or leave blank): ");
        string state = Console.ReadLine();

        bool foundAny = false;
        foreach (var book in books)
        {
            if (book.SearchContact(city, state))
                foundAny = true;
        }

        if (!foundAny)
            Console.WriteLine("No matching contacts found across books.");
    }

    public void ViewPersonsAcrossBooks()
    {
        Console.Write("Enter City (or leave blank): ");
        string city = Console.ReadLine();
        Console.Write("Enter State (or leave blank): ");
        string state = Console.ReadLine();

        foreach (var book in books)
        {
            if (!string.IsNullOrEmpty(city))
                book.ViewPersonsByCity(city);
            if (!string.IsNullOrEmpty(state))
                book.ViewPersonsByState(state);
        }
    }

    public void CountPersonsAcrossBooks()
    {
        Console.Write("Enter City (or leave blank): ");
        string city = Console.ReadLine();
        Console.Write("Enter State (or leave blank): ");
        string state = Console.ReadLine();

        int total = 0;
        foreach (var book in books)
        {
            if (!string.IsNullOrEmpty(city))
                total += book.CountByCity(city);
            if (!string.IsNullOrEmpty(state))
                total += book.CountByState(state);
        }

        Console.WriteLine($"Total persons matching criteria: {total}");
    }
}
