using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ContactUtility<T>
    where T : Contact
{
    private List<T> contacts = new List<T>();
    public string BookName { get; private set; }
    private string filePath;

    public ContactUtility(string bookName)
    {
        BookName = bookName;
        filePath = $"{BookName}.csv";
        try
        {
            LoadFromCSV();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading contacts from CSV: {ex.Message}");
        }
    }

    public void AddContact(Func<T> createContact)
    {
        try
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
            Console.WriteLine("Contact created successfully!");
            SaveToCSV();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding contact: {ex.Message}");
        }
    }

    public void EditContact(Func<T, bool> predicate, Action<T> editAction)
    {
        try
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                if (predicate(contacts[i]))
                {
                    editAction(contacts[i]);
                    Console.WriteLine("Contact updated successfully!");
                    SaveToCSV();
                    return;
                }
            }
            Console.WriteLine("Contact not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error editing contact: {ex.Message}");
        }
    }

    public void DeleteContact(Func<T, bool> predicate)
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting contact: {ex.Message}");
        }
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

    private void SaveToCSV()
    {
        try
        {
            using StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8);
            sw.WriteLine("FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email");
            foreach (var c in contacts)
            {
                sw.WriteLine(
                    $"{c.FirstName},{c.LastName},{c.Address},{c.City},{c.State},{c.Zip},{c.PhoneNumber},{c.Email}"
                );
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to CSV: {ex.Message}");
        }
    }

    private void LoadFromCSV()
    {
        if (!File.Exists(filePath))
            return;

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length == 8)
                {
                    contacts.Add(
                        (T)
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
                            )
                    );
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading CSV: {ex.Message}");
        }
    }

    // ---------------- Existing Methods ----------------
    public bool SearchContact(string city, string state)
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine($"Error searching contacts: {ex.Message}");
            return false;
        }
    }

    public void ViewPersonsByCity(string city)
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine($"Error viewing contacts by city: {ex.Message}");
        }
    }

    public void ViewPersonsByState(string state)
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine($"Error viewing contacts by state: {ex.Message}");
        }
    }

    public int CountByCity(string city)
    {
        try
        {
            int total = 0;
            foreach (var c in contacts)
            {
                if (c.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                    total++;
            }
            return total;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error counting contacts by city: {ex.Message}");
            return 0;
        }
    }

    public int CountByState(string state)
    {
        try
        {
            int total = 0;
            foreach (var c in contacts)
            {
                if (c.State.Equals(state, StringComparison.OrdinalIgnoreCase))
                    total++;
            }
            return total;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error counting contacts by state: {ex.Message}");
            return 0;
        }
    }

    // Sorting methods
    public void SortContactsByName()
    {
        try
        {
            contacts.Sort(
                (a, b) =>
                {
                    int firstNameCompare = string.Compare(
                        a.FirstName,
                        b.FirstName,
                        StringComparison.OrdinalIgnoreCase
                    );
                    return firstNameCompare != 0
                        ? firstNameCompare
                        : string.Compare(
                            a.LastName,
                            b.LastName,
                            StringComparison.OrdinalIgnoreCase
                        );
                }
            );
            Console.WriteLine("Contacts sorted by name.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sorting by name: {ex.Message}");
        }
    }

    public void SortContactsByCity()
    {
        try
        {
            contacts.Sort(
                (a, b) => string.Compare(a.City, b.City, StringComparison.OrdinalIgnoreCase)
            );
            Console.WriteLine("Contacts sorted by city.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sorting by city: {ex.Message}");
        }
    }

    public void SortContactsByState()
    {
        try
        {
            contacts.Sort(
                (a, b) => string.Compare(a.State, b.State, StringComparison.OrdinalIgnoreCase)
            );
            Console.WriteLine("Contacts sorted by state.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sorting by state: {ex.Message}");
        }
    }

    public void SortContactsByZip()
    {
        try
        {
            contacts.Sort(
                (a, b) => string.Compare(a.Zip, b.Zip, StringComparison.OrdinalIgnoreCase)
            );
            Console.WriteLine("Contacts sorted by zip.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sorting by zip: {ex.Message}");
        }
    }
}
