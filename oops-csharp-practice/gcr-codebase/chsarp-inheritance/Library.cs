using System;

class Book
{
    public string Title { get; set; }
    public int PublicationYear { get; set; }
}

class Author : Book
{
    public string Name { get; set; }
    public string Bio { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Title} ({PublicationYear}) by {Name}");
    }
}

class Library
{
    static void Main()
    {
        Author book = new Author
        {
            Title = "Clean Code",
            PublicationYear = 2008,
            Name = "Robert C. Martin",
            Bio = "Software Engineer",
        };

        book.DisplayInfo();
    }
}
