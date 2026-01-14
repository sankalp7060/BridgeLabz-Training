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
            if(books[i].BookName.Equals(name,StringComparison.OrdinalIgnoreCase)>=0){
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
}