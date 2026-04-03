using System;

interface IReservable
{
    void ReserveItem(string borrowerName);
    bool CheckAvailability();
}

abstract class LibraryItem
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    protected bool isAvailable = true;
    private string borrower;

    public LibraryItem(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }

    protected string GetBorrower()
    {
        return borrower;
    }

    public abstract int GetLoanDuration();

    public void GetItemDetails()
    {
        Console.WriteLine(
            $"ID: {Id}, Title: {Title}, Author: {Author}, Loan Days: {GetLoanDuration()}"
        );
    }

    protected void AssignBorrower(string name)
    {
        borrower = name;
        isAvailable = false;
    }

    protected bool IsItemAvailable()
    {
        return isAvailable;
    }
}

class Book : LibraryItem, IReservable
{
    public Book(int id, string title, string author)
        : base(id, title, author) { }

    public override int GetLoanDuration()
    {
        return 14;
    }

    public void ReserveItem(string borrowerName)
    {
        if (isAvailable)
        {
            AssignBorrower(borrowerName);
            Console.WriteLine($"Book reserved by {borrowerName}");
        }
        else
        {
            Console.WriteLine("Book is already reserved");
        }
    }

    public bool CheckAvailability()
    {
        return IsItemAvailable();
    }
}

class Magazine : LibraryItem, IReservable
{
    public Magazine(int id, string title, string author)
        : base(id, title, author) { }

    public override int GetLoanDuration()
    {
        return 7;
    }

    public void ReserveItem(string borrowerName)
    {
        if (isAvailable)
        {
            AssignBorrower(borrowerName);
            Console.WriteLine($"Magazine reserved by {borrowerName}");
        }
        else
        {
            Console.WriteLine("Magazine is already reserved");
        }
    }

    public bool CheckAvailability()
    {
        return IsItemAvailable();
    }
}

class DVD : LibraryItem
{
    public DVD(int id, string title, string author)
        : base(id, title, author) { }

    public override int GetLoanDuration()
    {
        return 3;
    }
}

class LibraryManagementSystem
{
    static void Main()
    {
        LibraryItem[] items = new LibraryItem[4];

        items[0] = new Book(1, "Clean Code", "Robert C. Martin");
        items[1] = new Magazine(2, "Time", "Time Editors");
        items[2] = new DVD(3, "Inception", "Christopher Nolan");
        items[3] = new Book(4, "Design Patterns", "GoF");

        Console.WriteLine("Library Items:\n");

        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetItemDetails();

            if (items[i] is IReservable reservable)
                Console.WriteLine("Available: " + reservable.CheckAvailability());
            else
                Console.WriteLine("Not reservable");

            Console.WriteLine();
        }

        ((IReservable)items[0]).ReserveItem("Rahul");
        ((IReservable)items[1]).ReserveItem("Anita");
    }
}
