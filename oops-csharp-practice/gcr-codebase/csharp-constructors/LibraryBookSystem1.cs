using System;

class LibraryBookSystem1
{
    string title;
    string author;
    double price;

    public LibraryBookSystem1()
    {
        title = "Unknown";
        author = "Unknown";
        price = 0;
    }

    public LibraryBookSystem1(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }

    public void Display()
    {
        Console.WriteLine($"{title} | {author} | ₹{price}");
    }

    static void Main()
    {
        LibraryBookSystem1 b1 = new LibraryBookSystem1();
        LibraryBookSystem1 b2 = new LibraryBookSystem1("C# Basics", "Sankalp", 499);

        b1.Display();
        b2.Display();
    }
}
