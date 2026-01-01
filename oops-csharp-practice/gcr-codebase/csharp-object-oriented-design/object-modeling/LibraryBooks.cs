using System;

class Book
{
    public string Title;
    public string Author;

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public void DisplayBook()
    {
        Console.WriteLine($"Book: {Title}, Author: {Author}");
    }
}

class Library
{
    public string Name;
    public Book[] Books;
    private int count = 0;

    public Library(string name, int capacity)
    {
        Name = name;
        Books = new Book[capacity]; // fixed-size array
    }

    public void AddBook(Book book)
    {
        if (count < Books.Length)
        {
            Books[count++] = book;
            Console.WriteLine($"Added '{book.Title}' to {Name}");
        }
        else
        {
            Console.WriteLine("Library is full!");
        }
    }

    public void ShowBooks()
    {
        Console.WriteLine($"Books in {Name}:");
        for (int i = 0; i < count; i++)
        {
            Books[i].DisplayBook();
        }
    }
}

// Demonstration
class LibraryBooks
{
    static void Main()
    {
        Book b1 = new Book("C# Fundamentals", "John Doe");
        Book b2 = new Book("Data Structures", "Jane Smith");
        Book b3 = new Book("Algorithms", "Bob Martin");

        Library lib1 = new Library("Central Library", 5);
        Library lib2 = new Library("Community Library", 3);

        lib1.AddBook(b1);
        lib1.AddBook(b2);

        lib2.AddBook(b2); // aggregation: b2 exists independently
        lib2.AddBook(b3);

        lib1.ShowBooks();
        lib2.ShowBooks();
    }
}
