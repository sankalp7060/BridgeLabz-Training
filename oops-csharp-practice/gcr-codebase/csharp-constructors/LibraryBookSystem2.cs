using System;

class LibraryBookSystem2
{
    public string ISBN;
    protected string title;
    private string author;

    // Constructor
    public LibraryBookSystem2(string isbn, string title, string author)
    {
        ISBN = isbn;
        this.title = title;
        this.author = author;
    }

    public string GetAuthor()
    {
        return author;
    }
}

class EBook : LibraryBookSystem2
{
    public EBook(string isbn, string title, string author)
        : base(isbn, title, author) { }

    public void Display()
    {
        Console.WriteLine($"{ISBN} - {title} - {GetAuthor()}");
    }
}

class Program
{
    static void Main()
    {
        EBook eb = new EBook("12345", "C# OOP", "Sankalp");
        eb.Display();
    }
}
