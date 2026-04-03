using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ContactUtility<T>
    where T : Contact
{
    private List<T> contacts = new List<T>(); // Store contacts
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
            Console.WriteLine($"Error loading CSV: {ex.Message}");
        }
    }

    // ------------------ Original Methods ------------------
    public void AddContact()
    {
        try
        {
            T contact = CreateContactFromInput();
            if (IsDuplicate(contact))
            {
                Console.WriteLine("Duplicate entry! Phone number already exists.");
                return;
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

    public void EditContact()
    {
        try
        {
            Console.Write("Enter First Name to edit: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            foreach (var c in contacts)
            {
                if (
                    c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase)
                    && c.PhoneNumber == phone
                )
                {
                    EditContactDetails(c);
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

    public void DeleteContact()
    {
        try
        {
            Console.Write("Enter First Name to delete: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            for (int i = 0; i < contacts.Count; i++)
            {
                if (
                    contacts[i].FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase)
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
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting contact: {ex.Message}");
        }
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

    // ------------------ Delegate Overloads ------------------
    public void AddContact(Func<T> createContactFunc)
    {
        try
        {
            T contact = createContactFunc();
            if (IsDuplicate(contact))
            {
                Console.WriteLine("Duplicate entry! Phone number already exists.");
                return;
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

    public void EditContact(Predicate<T> match, Action<T> editAction)
    {
        try
        {
            foreach (var c in contacts)
            {
                if (match(c))
                {
                    editAction(c);
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

    public void DeleteContact(Predicate<T> match)
    {
        try
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                if (match(contacts[i]))
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

    public void AddMultipleContact(Func<T> createContactFunc)
    {
        while (true)
        {
            AddContact(createContactFunc);
            Console.WriteLine(
                "Press ENTER to stop adding multiple contacts, any other key to continue."
            );
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
                break;
            Console.WriteLine();
        }
    }

    // ------------------ CSV Methods ------------------
    private void SaveToCSV()
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving CSV: {ex.Message}");
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
                // Uses reflection to call constructor
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

    // ------------------ Helper Methods ------------------
    private T CreateContactFromInput()
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

        return (T)
            Activator.CreateInstance(
                typeof(T),
                firstName,
                lastName,
                address,
                city,
                state,
                zip,
                phone,
                email
            );
    }

    private void EditContactDetails(T c)
    {
        Console.Write("New Last Name: ");
        c.LastName = Console.ReadLine();
        Console.Write("New Address: ");
        c.Address = Console.ReadLine();
        Console.Write("New City: ");
        c.City = Console.ReadLine();
        Console.Write("New State: ");
        c.State = Console.ReadLine();
        Console.Write("New Zip: ");
        c.Zip = Console.ReadLine();
        Console.Write("New Phone Number: ");
        c.PhoneNumber = Console.ReadLine();
        Console.Write("New Email: ");
        c.Email = Console.ReadLine();
    }

    private bool IsDuplicate(T c)
    {
        foreach (var contact in contacts)
        {
            if (contact.PhoneNumber == c.PhoneNumber)
                return true;
        }
        return false;
    }

    // ------------------ Search, Count, Sort ------------------
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

    // Sorting Methods
    public void SortContactsByName()
    {
        contacts.Sort(
            (a, b) =>
            {
                int firstCompare = string.Compare(
                    a.FirstName,
                    b.FirstName,
                    StringComparison.OrdinalIgnoreCase
                );
                return firstCompare != 0
                    ? firstCompare
                    : string.Compare(a.LastName, b.LastName, StringComparison.OrdinalIgnoreCase);
            }
        );
        Console.WriteLine("Contacts sorted by Name.");
    }

    public void SortContactsByCity()
    {
        contacts.Sort((a, b) => string.Compare(a.City, b.City, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine("Contacts sorted by City.");
    }

    public void SortContactsByState()
    {
        contacts.Sort(
            (a, b) => string.Compare(a.State, b.State, StringComparison.OrdinalIgnoreCase)
        );
        Console.WriteLine("Contacts sorted by State.");
    }

    public void SortContactsByZip()
    {
        contacts.Sort((a, b) => string.Compare(a.Zip, b.Zip, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine("Contacts sorted by Zip.");
    }
}
