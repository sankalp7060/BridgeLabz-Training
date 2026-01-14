using System;

class AddressBookUtility : IContact
{
    private Contact[] contacts = new Contact[100];
    private int count = 0;
    public string BookName { get; private set; }

    public AddressBookUtility(string bookName)
    {
        BookName = bookName;
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

        for (int i = 0; i < count; i++)
        {
            if (contacts[i].PhoneNumber == phone)
            {
                Console.WriteLine(
                    "Duplicate entry! Phone number already exists in this Address Book."
                );
                return;
            }
        }

        contacts[count] = new Contact(firstName, lastName, address, city, state, zip, phone, email);
        count++;
        Console.WriteLine("Contact created successfully!");
    }

    public void EditContact()
    {
        Console.Write("Enter the First Name of the contact to edit: ");
        string name = Console.ReadLine();

        Console.Write("Enter the Phone Number of the contact: ");
        string phone = Console.ReadLine();

        for (int i = 0; i < count; i++)
        {
            if (
                contacts[i].FirstName.Equals(name, StringComparison.OrdinalIgnoreCase)
                && contacts[i].PhoneNumber == phone
            )
            {
                Console.WriteLine("Editing contact...");

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
                return;
            }
        }

        Console.WriteLine("Contact not found.");
    }

    public void DeleteContact()
    {
        Console.Write("Enter the First Name of the contact to delete: ");
        string name = Console.ReadLine();

        Console.Write("Enter the Phone Number of the contact: ");
        string phone = Console.ReadLine();
        for (int i = 0; i < count; i++)
        {
            if (
                contacts[i].FirstName.Equals(name, StringComparison.OrdinalIgnoreCase)
                && contacts[i].PhoneNumber == phone
            )
            {
                for (int j = i; j < count - 1; j++)
                {
                    contacts[j] = contacts[j + 1];
                }
                contacts[count - 1] = null;
                count--;
                Console.WriteLine("Contact deleted successfully!");
                return;
            }
        }
    }

    public void AddMultipleContact()
    {
        while (true)
        {
            AddContact();
            Console.WriteLine("Press ENTER to exit");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                break;
            }
            Console.WriteLine();
        }
    }
}
