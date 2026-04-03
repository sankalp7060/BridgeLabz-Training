using System;

public class BookUtility : IBook
{
    private CustomHashMap map = new CustomHashMap();

    public void AddBook()
    {
        Console.WriteLine("Enter Book id:- ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Book title:- ");
        string title = Console.ReadLine();
        Console.WriteLine("Enter Book's author");
        string author = Console.ReadLine();
        Console.WriteLine("Enter Book genre");
        string genre = Console.ReadLine();

        Book book = new Book(id, title, author, genre);

        map.Put(book.Genre, book);
    }

    public void BorrowBook()
    {
        Console.WriteLine("Enter Book genre");
        string genre = Console.ReadLine();
        Console.WriteLine("Enter Book id:- ");
        int id = Convert.ToInt32(Console.ReadLine());
        bool removed = map.Remove(genre, id);
        if (removed)
            Console.WriteLine("Book Borrowed Successfully");
        else
            Console.WriteLine("Book Not Found");
    }

    public void ReturnBook()
    {
        Console.WriteLine("Enter Book id:- ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Book title:- ");
        string title = Console.ReadLine();
        Console.WriteLine("Enter Book's author");
        string author = Console.ReadLine();
        Console.WriteLine("Enter Book genre");
        string genre = Console.ReadLine();

        Book book = new Book(id, title, author, genre);

        map.Put(book.Genre, book);
    }

    public void DisplayLibrary()
    {
        map.Display();
    }
}
