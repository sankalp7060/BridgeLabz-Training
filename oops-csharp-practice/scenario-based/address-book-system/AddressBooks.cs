using System;

class AddressBooks : IAddressBook{
    private AddressBookUtility[] books = new AddressBookUtility[10];
    private count = 0;
    public void AddBook(){
        if (count >= addressBooks.Length)
            {
                Console.WriteLine("Cannot add more Address Books.");
                return;
            }
        Console.WriteLine("Enter the name for a new address book:- ");
        string name = Console.ReadLine();

        for(int i = 0;i<count;i++){
            if(books[i].BookName.Equals(name,StringComparison.OrdinalIgnoreCase)){
                Console.WriteLine("Address Book with this name is already exist.");
                return;
            }
        }
        books[count]= new AddressBookUtility(name);
        count++;
        Console.WriteLine($"Address Book '{name}' added successfully!");
    }
    public void ListBook(){
        Console.WriteLine("All address books:- ");
        for(int i=0;i<count;i++){
            Console.WriteLine(books[i].BookName);
        }
    }
    public void SearchPersonAcrossBooks(){
        Console.WriteLine("Enter the city name:- ");
        string city = Console.ReadLine();
        Console.WriteLine("Enter the state name:- ");
        string state = Console.ReadLine();
        Console.WriteLine("\nSearch Results:");
        bool found = false;

        for(int i=0;i<count;i++){
            found = address[i].SearchContact(city,state) || found;
        }
        if(!found){
            Console.WriteLine("No matching person found.");
        }
    }
    public void ViewPersonsAcrossBooks()
    {
        Console.WriteLine("View by:\n1. City\n2. State");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            Console.WriteLine($"\nPersons in City: {city}");

            for (int i = 0; i < count; i++)
            {
                addressBooks[i].ViewPersonsByCity(city);
            }
        }
        else if (choice == "2")
        {
            Console.Write("Enter State: ");
            string state = Console.ReadLine();

            Console.WriteLine($"\nPersons in State: {state}");

            for (int i = 0; i < count; i++)
            {
                addressBooks[i].ViewPersonsByState(state);
            }
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }
}