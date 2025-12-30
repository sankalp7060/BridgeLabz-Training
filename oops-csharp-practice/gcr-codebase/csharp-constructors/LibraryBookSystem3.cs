using System;

class LibraryBookSystem3
{
    string title;
    string author;
    double price;
    bool available = true;

    // Constructor must match the class name
    public LibraryBookSystem3(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }

    public void BorrowBook()
    {
        if (available)
        {
            available = false;
            Console.WriteLine("Book borrowed");
        }
        else
        {
            Console.WriteLine("Book not available");
        }
    }

    static void Main()
    {
        LibraryBookSystem3 b = new LibraryBookSystem3("C# Mastery", "Sankalp", 599);
        b.BorrowBook();
        b.BorrowBook();
    }
}
