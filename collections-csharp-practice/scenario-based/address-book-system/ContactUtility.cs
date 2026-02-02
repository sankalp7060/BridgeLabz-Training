using System;
using System.IO;

class ContactUtility : IContact
{
    private Contact[] contacts = new Contact[100];
    private int count = 0;
    public string BookName { get; private set; }
    private string filePath;

    public ContactUtility(string bookName)
    {
        BookName = bookName;
        filePath = $"{BookName}.txt"; // Each address book will have its own file
        LoadFromFile(); // Load contacts from file on initialization
    }

    public void AddContact()
    {
        if (count >= contacts.Length)
        {
            Console.WriteLine("Address Book is full!");
            return;
        }

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

        // Check for duplicate phone
        for (int i = 0; i < count; i++)
        {
            if (contacts[i].PhoneNumber == phone)
            {
                Console.WriteLine("Duplicate entry! Phone number already exists.");
                return;
            }
        }

        contacts[count] = new Contact(firstName, lastName, address, city, state, zip, phone, email);
        count++;
        Console.WriteLine("Contact created successfully!");
        SaveToFile(); // Save after adding
    }

    public void EditContact()
    {
        Console.Write("Enter First Name to edit: ");
        string name = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        string phone = Console.ReadLine();

        for (int i = 0; i < count; i++)
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
                SaveToFile();
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

        for (int i = 0; i < count; i++)
        {
            if (
                contacts[i].FirstName.Equals(name, StringComparison.OrdinalIgnoreCase)
                && contacts[i].PhoneNumber == phone
            )
            {
                for (int j = i; j < count - 1; j++)
                    contacts[j] = contacts[j + 1];
                contacts[count - 1] = null;
                count--;
                Console.WriteLine("Contact deleted successfully!");
                SaveToFile();
                return;
            }
        }
        Console.WriteLine("Contact not found.");
    }

    // Add Multiple Contacts
    public void AddMultipleContact()
    {
        while (true)
        {
            AddContact();
            Console.WriteLine(
                "Press ENTER to exit adding multiple contacts, any other key to continue."
            );
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
                break;
            Console.WriteLine();
        }
    }

    // File I/O Methods
    private void SaveToFile()
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            for (int i = 0; i < count; i++)
            {
                sw.WriteLine(
                    $"{contacts[i].FirstName}|{contacts[i].LastName}|{contacts[i].Address}|{contacts[i].City}|{contacts[i].State}|{contacts[i].Zip}|{contacts[i].PhoneNumber}|{contacts[i].Email}"
                );
            }
        }
    }

    private void LoadFromFile()
    {
        if (!File.Exists(filePath))
            return;

        string[] lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 8)
            {
                contacts[count++] = new Contact(
                    parts[0],
                    parts[1],
                    parts[2],
                    parts[3],
                    parts[4],
                    parts[5],
                    parts[6],
                    parts[7]
                );
            }
        }
    }

    public bool SearchContact(string city, string state)
    {
        bool found = false;
        for (int i = 0; i < count; i++)
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
        for (int i = 0; i < count; i++)
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
        {
            Console.WriteLine($"[{BookName}] No persons found in city: {city}");
        }
    }

    public void ViewPersonsByState(string state)
    {
        bool found = false;
        for (int i = 0; i < count; i++)
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
        {
            Console.WriteLine($"[{BookName}] No persons found in state: {state}");
        }
    }

    public int CountByCity(string city)
    {
        int cityCount = 0;
        for (int i = 0; i < count; i++)
        {
            if (contacts[i].City.Equals(city, StringComparison.OrdinalIgnoreCase))
                cityCount++;
        }
        return cityCount;
    }

    public int CountByState(string state)
    {
        int stateCount = 0;
        for (int i = 0; i < count; i++)
        {
            if (contacts[i].State.Equals(state, StringComparison.OrdinalIgnoreCase))
                stateCount++;
        }
        return stateCount;
    }

    public void SortContactsByName()
    {
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                int firstCompare = string.Compare(
                    contacts[j].FirstName,
                    contacts[j + 1].FirstName,
                    StringComparison.OrdinalIgnoreCase
                );
                int lastCompare = string.Compare(
                    contacts[j].LastName,
                    contacts[j + 1].LastName,
                    StringComparison.OrdinalIgnoreCase
                );
                if (firstCompare > 0 || (firstCompare == 0 && lastCompare > 0))
                {
                    var temp = contacts[j];
                    contacts[j] = contacts[j + 1];
                    contacts[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Contacts sorted by Name.");
    }

    public void SortContactsByCity()
    {
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if (
                    string.Compare(
                        contacts[j].City,
                        contacts[j + 1].City,
                        StringComparison.OrdinalIgnoreCase
                    ) > 0
                )
                {
                    var temp = contacts[j];
                    contacts[j] = contacts[j + 1];
                    contacts[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Contacts sorted by City.");
    }

    public void SortContactsByState()
    {
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if (
                    string.Compare(
                        contacts[j].State,
                        contacts[j + 1].State,
                        StringComparison.OrdinalIgnoreCase
                    ) > 0
                )
                {
                    var temp = contacts[j];
                    contacts[j] = contacts[j + 1];
                    contacts[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Contacts sorted by State.");
    }

    public void SortContactsByZip()
    {
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if (
                    string.Compare(
                        contacts[j].Zip,
                        contacts[j + 1].Zip,
                        StringComparison.OrdinalIgnoreCase
                    ) > 0
                )
                {
                    var temp = contacts[j];
                    contacts[j] = contacts[j + 1];
                    contacts[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Contacts sorted by Zip.");
    }
}
