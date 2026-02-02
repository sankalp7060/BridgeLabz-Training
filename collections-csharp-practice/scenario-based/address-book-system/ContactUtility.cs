using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ContactUtility : IContact
{
    private List<Contact> contacts = new List<Contact>(); // Changed to List
    public string BookName { get; private set; }
    private string filePath;

    public ContactUtility(string bookName)
    {
        BookName = bookName;
        filePath = $"{BookName}.csv";
        LoadFromCSV();
    }

    public void AddContact()
    {
        Console.WriteLine("Creating a new contact...");

        Console.Write("First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("City: ");
        string city = Console.ReadLine();

        Console.Write("State: ");
        string state = Console.ReadLine();

        Console.Write("Zip: ");
        string zip = Console.ReadLine();

        Console.Write("Phone Number: ");
        string phone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        // Check duplicate phone
        for (int i = 0; i < contacts.Count; i++)
        {
            if (contacts[i].PhoneNumber == phone)
            {
                Console.WriteLine("Duplicate entry! Phone number already exists.");
                return;
            }
        }

        contacts.Add(new Contact(firstName, lastName, address, city, state, zip, phone, email));
        Console.WriteLine("Contact created successfully!");
        SaveToCSV();
    }

    public void EditContact()
    {
        Console.Write("Enter First Name to edit: ");
        string name = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        string phone = Console.ReadLine();

        for (int i = 0; i < contacts.Count; i++)
        {
            if (
                contacts[i].FirstName.Equals(name, StringComparison.OrdinalIgnoreCase)
                && contacts[i].PhoneNumber == phone
            )
            {
                Console.Write("New Last Name: ");
                contacts[i].LastName = Console.ReadLine();
                Console.Write("New Address: ");
                contacts[i].Address = Console.ReadLine();
                Console.Write("New City: ");
                contacts[i].City = Console.ReadLine();
                Console.Write("New State: ");
                contacts[i].State = Console.ReadLine();
                Console.Write("New Zip: ");
                contacts[i].Zip = Console.ReadLine();
                Console.Write("New Phone Number: ");
                contacts[i].PhoneNumber = Console.ReadLine();
                Console.Write("New Email: ");
                contacts[i].Email = Console.ReadLine();
                Console.WriteLine("Contact updated successfully!");
                SaveToCSV();
                return;
            }
        }

        Console.WriteLine("Contact not found.");
    }

    public void DeleteContact()
    {
        Console.Write("Enter First Name to delete: ");
        string name = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        string phone = Console.ReadLine();

        for (int i = 0; i < contacts.Count; i++)
        {
            if (
                contacts[i].FirstName.Equals(name, StringComparison.OrdinalIgnoreCase)
                && contacts[i].PhoneNumber == phone
            )
            {
                contacts.RemoveAt(i);
                Console.WriteLine("Contact deleted successfully!");
                SaveToCSV();
                return;
            }
        }

        Console.WriteLine("Contact not found.");
    }

    public void AddMultipleContact()
    {
        while (true)
        {
            AddContact();
            Console.WriteLine(
                "Press ENTER to stop adding multiple contacts, any other key to continue."
            );
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
                break;
            Console.WriteLine();
        }
    }

    // ---------------- CSV Methods ----------------
    private void SaveToCSV()
    {
        using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            sw.WriteLine("FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email");
            for (int i = 0; i < contacts.Count; i++)
            {
                sw.WriteLine(
                    $"{contacts[i].FirstName},{contacts[i].LastName},{contacts[i].Address},{contacts[i].City},{contacts[i].State},{contacts[i].Zip},{contacts[i].PhoneNumber},{contacts[i].Email}"
                );
            }
        }
    }

    private void LoadFromCSV()
    {
        if (!File.Exists(filePath))
            return;

        string[] lines = File.ReadAllLines(filePath);
        for (int i = 1; i < lines.Length; i++) // Skip header
        {
            string[] parts = lines[i].Split(',');
            if (parts.Length == 8)
            {
                contacts.Add(
                    new Contact(
                        parts[0],
                        parts[1],
                        parts[2],
                        parts[3],
                        parts[4],
                        parts[5],
                        parts[6],
                        parts[7]
                    )
                );
            }
        }
    }

    // ---------------- Existing Methods ----------------
    public bool SearchContact(string city, string state)
    {
        bool found = false;
        for (int i = 0; i < contacts.Count; i++)
        {
            if (
                (
                    !string.IsNullOrEmpty(city)
                    && contacts[i].City.Equals(city, StringComparison.OrdinalIgnoreCase)
                )
                || (
                    !string.IsNullOrEmpty(state)
                    && contacts[i].State.Equals(state, StringComparison.OrdinalIgnoreCase)
                )
            )
            {
                Console.WriteLine(
                    $"[{BookName}] {contacts[i].FirstName} {contacts[i].LastName} | {contacts[i].City}, {contacts[i].State} | {contacts[i].PhoneNumber}"
                );
                found = true;
            }
        }
        return found;
    }

    public void ViewPersonsByCity(string city)
    {
        bool found = false;
        for (int i = 0; i < contacts.Count; i++)
        {
            if (contacts[i].City.Equals(city, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(
                    $"[{BookName}] {contacts[i].FirstName} {contacts[i].LastName} | {contacts[i].PhoneNumber}"
                );
                found = true;
            }
        }
        if (!found)
            Console.WriteLine($"[{BookName}] No persons found in city: {city}");
    }

    public void ViewPersonsByState(string state)
    {
        bool found = false;
        for (int i = 0; i < contacts.Count; i++)
        {
            if (contacts[i].State.Equals(state, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(
                    $"[{BookName}] {contacts[i].FirstName} {contacts[i].LastName} | {contacts[i].PhoneNumber}"
                );
                found = true;
            }
        }
        if (!found)
            Console.WriteLine($"[{BookName}] No persons found in state: {state}");
    }

    public int CountByCity(string city)
    {
        int total = 0;
        for (int i = 0; i < contacts.Count; i++)
        {
            if (contacts[i].City.Equals(city, StringComparison.OrdinalIgnoreCase))
                total++;
        }
        return total;
    }

    public int CountByState(string state)
    {
        int total = 0;
        for (int i = 0; i < contacts.Count; i++)
        {
            if (contacts[i].State.Equals(state, StringComparison.OrdinalIgnoreCase))
                total++;
        }
        return total;
    }

    public void SortContactsByName()
    {
        if (contacts.Count <= 1)
            return;

        for (int i = 0; i < contacts.Count - 1; i++)
        {
            for (int j = 0; j < contacts.Count - i - 1; j++)
            {
                int firstNameCompare = string.Compare(
                    contacts[j].FirstName,
                    contacts[j + 1].FirstName,
                    StringComparison.OrdinalIgnoreCase
                );
                int lastNameCompare = string.Compare(
                    contacts[j].LastName,
                    contacts[j + 1].LastName,
                    StringComparison.OrdinalIgnoreCase
                );

                if (firstNameCompare > 0 || (firstNameCompare == 0 && lastNameCompare > 0))
                {
                    Contact temp = contacts[j];
                    contacts[j] = contacts[j + 1];
                    contacts[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Contacts sorted alphabetically by name.");
    }

    public void SortContactsByCity()
    {
        for (int i = 0; i < contacts.Count - 1; i++)
        {
            for (int j = 0; j < contacts.Count - i - 1; j++)
            {
                if (
                    string.Compare(
                        contacts[j].City,
                        contacts[j + 1].City,
                        StringComparison.OrdinalIgnoreCase
                    ) > 0
                )
                {
                    Contact temp = contacts[j];
                    contacts[j] = contacts[j + 1];
                    contacts[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Contacts sorted by city.");
    }

    public void SortContactsByState()
    {
        for (int i = 0; i < contacts.Count - 1; i++)
        {
            for (int j = 0; j < contacts.Count - i - 1; j++)
            {
                if (
                    string.Compare(
                        contacts[j].State,
                        contacts[j + 1].State,
                        StringComparison.OrdinalIgnoreCase
                    ) > 0
                )
                {
                    Contact temp = contacts[j];
                    contacts[j] = contacts[j + 1];
                    contacts[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Contacts sorted by state.");
    }

    public void SortContactsByZip()
    {
        for (int i = 0; i < contacts.Count - 1; i++)
        {
            for (int j = 0; j < contacts.Count - i - 1; j++)
            {
                if (
                    string.Compare(
                        contacts[j].Zip,
                        contacts[j + 1].Zip,
                        StringComparison.OrdinalIgnoreCase
                    ) > 0
                )
                {
                    Contact temp = contacts[j];
                    contacts[j] = contacts[j + 1];
                    contacts[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Contacts sorted by zip.");
    }
}
