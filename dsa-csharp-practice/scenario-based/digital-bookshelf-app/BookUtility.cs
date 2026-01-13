using System;

class BookUtility : IBookApp
{
    private Book[] books;
    private int count;

    public BookUtility(int cap)
    {
        books = new Book[cap];
        count = 0;
    }

    public void AddBook()
    {
        if (count >= books.Length)
        {
            Console.WriteLine("Book list is full!");
            return;
        }

        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
        Console.Write("Enter book author: ");
        string author = Console.ReadLine();

        books[count] = new Book(title, author);
        count++;
        Console.WriteLine("Book added successfully.");
    }

    public void SortBooksAlphabetically()
    {
        if (count <= 1)
        {
            Console.WriteLine("Not enough books to sort.");
            return;
        }
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if (IsGreater(books[j].Title, books[j + 1].Title))
                {
                    Book t = books[j];
                    books[j] = books[j + 1];
                    books[j + 1] = t;
                }
            }
        }
        Console.WriteLine("Books sorted alphabetically by title.");
    }

    public void SearchByAuthor()
    {
        if (count == 0)
        {
            Console.WriteLine("No books in the list.");
            return;
        }

        Console.Write("Enter author name to search: ");
        string author = Console.ReadLine();

        bool found = false;
        for (int i = 0; i < count; i++)
        {
            string combined = books[i].Title + " - " + books[i].Author;
            string[] parts = combined.Split('-');
            string bookAuthor = parts[1].Trim();
            if (bookAuthor.Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Title: {books[i].Title}, Author: {books[i].Author}");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("No book found with that author.");
        }
    }

    private bool IsGreater(string s1, string s2)
    {
        s1 = s1.ToLower();
        s2 = s2.ToLower();
        int len = Math.Min(s1.Length, s2.Length);
        for (int i = 0; i < len; i++)
        {
            if (s1[i] > s2[i])
                return true;
            if (s1[i] < s2[i])
                return false;
        }
        if (s1.Length > s2.Length)
            return true;
        return false;
    }
}
