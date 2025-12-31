using System;

class Book
{
    public static string LibraryName = "Central Library";
    public string Title;
    public string Author;
    public readonly string ISBN;

    public Book(string title, string author, string isbn)
    {
        this.Title = title;
        this.Author = author;
        this.ISBN = isbn;
    }

    public static void DisplayLibraryName()
    {
        Console.WriteLine("Library: " + LibraryName);
    }

    public void Display(object obj)
    {
        if (obj is Book)
        {
            Console.WriteLine($"{Title} by {Author}, ISBN: {ISBN}");
        }
    }

    static void Main()
    {
        Book b = new Book("C# Basics", "MS", "ISBN123");
        DisplayLibraryName();
        b.Display(b);
    }
}
