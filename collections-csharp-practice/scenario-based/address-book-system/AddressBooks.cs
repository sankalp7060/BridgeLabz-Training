using System;
using System.Collections.Generic;

class AddressBooks : IAddressBook
{
    private List<ContactUtility> books = new List<ContactUtility>(); // List instead of array

    public void AddBook()
    {
        Console.Write("Enter new Address Book Name: ");
        string name = Console.ReadLine();

        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].BookName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Address Book with this name already exists!");
                return;
            }
        }

        books.Add(new ContactUtility(name));
        Console.WriteLine($"Address Book '{name}' added successfully!");
    }

    public void ListBook()
    {
        Console.WriteLine("All Address Books:");
        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine(books[i].BookName);
        }
    }

    public void SearchPersonAcrossBooks()
    {
        Console.Write("Enter City (or leave blank): ");
        string city = Console.ReadLine();
        Console.Write("Enter State (or leave blank): ");
        string state = Console.ReadLine();

        bool found = false;
        for (int i = 0; i < books.Count; i++)
        {
            found = books[i].SearchContact(city, state) || found;
        }
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
            for (int i = 0; i < books.Count; i++)
                books[i].ViewPersonsByCity(city);
        }
        else if (choice == "2")
        {
            Console.Write("Enter State: ");
            string state = Console.ReadLine();
            for (int i = 0; i < books.Count; i++)
                books[i].ViewPersonsByState(state);
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

        int total = 0;
        if (choice == "1")
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();
            for (int i = 0; i < books.Count; i++)
                total += books[i].CountByCity(city);

            Console.WriteLine($"Total persons in city '{city}': {total}");
        }
        else if (choice == "2")
        {
            Console.Write("Enter State: ");
            string state = Console.ReadLine();
            for (int i = 0; i < books.Count; i++)
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
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].BookName.Equals(name, StringComparison.OrdinalIgnoreCase))
                return books[i];
        }
        return null;
    }
}
