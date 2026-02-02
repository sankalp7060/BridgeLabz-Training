using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ContactUtility<T>
    where T : IContactEntity
{
    private List<T> contacts = new List<T>();
    public string BookName { get; private set; }
    private string filePath;

    public ContactUtility(string bookName)
    {
        BookName = bookName;
        filePath = $"{BookName}.csv";
        LoadFromCSV();
    }

    public void AddContact(Func<T> createContact)
    {
        T contact = createContact();

        foreach (var c in contacts)
        {
            if (c.PhoneNumber == contact.PhoneNumber)
            {
                Console.WriteLine("Duplicate entry! Phone number already exists.");
                return;
            }
        }

        contacts.Add(contact);
        Console.WriteLine("Contact added successfully!");
        SaveToCSV();
    }

    public void EditContact(Func<T, bool> predicate, Action<T> editAction)
    {
        foreach (var c in contacts)
        {
            if (predicate(c))
            {
                editAction(c);
                Console.WriteLine("Contact updated successfully!");
                SaveToCSV();
                return;
            }
        }
        Console.WriteLine("Contact not found.");
    }

    public void DeleteContact(Func<T, bool> predicate)
    {
        for (int i = 0; i < contacts.Count; i++)
        {
            if (predicate(contacts[i]))
            {
                contacts.RemoveAt(i);
                Console.WriteLine("Contact deleted successfully!");
                SaveToCSV();
                return;
            }
        }
        Console.WriteLine("Contact not found.");
    }

    public void AddMultipleContact(Func<T> createContact)
    {
        while (true)
        {
            AddContact(createContact);
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
            foreach (var c in contacts)
            {
                sw.WriteLine(
                    $"{c.FirstName},{c.LastName},{c.Address},{c.City},{c.State},{c.Zip},{c.PhoneNumber},{c.Email}"
                );
            }
        }
    }

    private void LoadFromCSV()
    {
        if (!File.Exists(filePath))
            return;

        string[] lines = File.ReadAllLines(filePath);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            if (parts.Length == 8)
            {
                T c = (T)
                    Activator.CreateInstance(
                        typeof(T),
                        parts[0],
                        parts[1],
                        parts[2],
                        parts[3],
                        parts[4],
                        parts[5],
                        parts[6],
                        parts[7]
                    );
                contacts.Add(c);
            }
        }
    }

    // ---------------- Search / View ----------------
    public bool SearchContact(string city, string state)
    {
        bool found = false;
        foreach (var c in contacts)
        {
            if (
                (
                    !string.IsNullOrEmpty(city)
                    && c.City.Equals(city, StringComparison.OrdinalIgnoreCase)
                )
                || (
                    !string.IsNullOrEmpty(state)
                    && c.State.Equals(state, StringComparison.OrdinalIgnoreCase)
                )
            )
            {
                Console.WriteLine(
                    $"[{BookName}] {c.FirstName} {c.LastName} | {c.City}, {c.State} | {c.PhoneNumber}"
                );
                found = true;
            }
        }
        return found;
    }

    public void ViewPersonsByCity(string city)
    {
        bool found = false;
        foreach (var c in contacts)
        {
            if (c.City.Equals(city, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"[{BookName}] {c.FirstName} {c.LastName} | {c.PhoneNumber}");
                found = true;
            }
        }
        if (!found)
            Console.WriteLine($"[{BookName}] No persons found in city: {city}");
    }

    public void ViewPersonsByState(string state)
    {
        bool found = false;
        foreach (var c in contacts)
        {
            if (c.State.Equals(state, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"[{BookName}] {c.FirstName} {c.LastName} | {c.PhoneNumber}");
                found = true;
            }
        }
        if (!found)
            Console.WriteLine($"[{BookName}] No persons found in state: {state}");
    }

    public int CountByCity(string city)
    {
        int total = 0;
        foreach (var c in contacts)
            if (c.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                total++;
        return total;
    }

    public int CountByState(string state)
    {
        int total = 0;
        foreach (var c in contacts)
            if (c.State.Equals(state, StringComparison.OrdinalIgnoreCase))
                total++;
        return total;
    }

    // ---------------- Sorting ----------------
    public void SortContactsByName()
    {
        contacts.Sort(
            (a, b) =>
            {
                int fn = string.Compare(
                    a.FirstName,
                    b.FirstName,
                    StringComparison.OrdinalIgnoreCase
                );
                return fn != 0
                    ? fn
                    : string.Compare(a.LastName, b.LastName, StringComparison.OrdinalIgnoreCase);
            }
        );
        Console.WriteLine("Contacts sorted by name.");
        SaveToCSV();
    }

    public void SortContactsByCity()
    {
        contacts.Sort((a, b) => string.Compare(a.City, b.City, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine("Contacts sorted by city.");
        SaveToCSV();
    }

    public void SortContactsByState()
    {
        contacts.Sort(
            (a, b) => string.Compare(a.State, b.State, StringComparison.OrdinalIgnoreCase)
        );
        Console.WriteLine("Contacts sorted by state.");
        SaveToCSV();
    }

    public void SortContactsByZip()
    {
        contacts.Sort((a, b) => string.Compare(a.Zip, b.Zip, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine("Contacts sorted by zip.");
        SaveToCSV();
    }
}
