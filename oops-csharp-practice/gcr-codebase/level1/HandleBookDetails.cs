using System;

class Book
{
    // Attributes
    public string Title;
    public string Author;
    public double Price;

    // Method to display book details
    public void DisplayDetails()
    {
        Console.WriteLine("Book Details:");
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Price: $" + Price);
    }
}

class HandleBookDetails
{
    static void Main()
    {
        Book book = new Book();

        Console.Write("Enter Book Title: ");
        book.Title = Console.ReadLine();

        Console.Write("Enter Author Name: ");
        book.Author = Console.ReadLine();

        Console.Write("Enter Price: ");
        book.Price = double.Parse(Console.ReadLine());

        book.DisplayDetails();
    }
}
