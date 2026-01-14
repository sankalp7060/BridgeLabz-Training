using System;

class AddressBookUtility : IAddressBook
{
    private Contact[] contacts = new Contact[100];
    private int count;

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

        contacts[count] = new Contact(firstName, lastName, address, city, state, zip, phone, email);
        count++;
        Console.WriteLine("Contact created successfully!");
    }
}
