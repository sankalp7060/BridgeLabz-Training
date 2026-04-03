using System;

/* ================= BOOK ================= */
class Book
{
    public int BookId;
    public string Title;
    public string Author;
    public string Genre;
    public bool IsAvailable;

    public Book(int id, string title, string author, string genre, bool available)
    {
        BookId = id;
        Title = title;
        Author = author;
        Genre = genre;
        IsAvailable = available;
    }
}

/* ================= NODE ================= */
class BookNode
{
    public Book Data;
    public BookNode Next;
    public BookNode Prev;

    public BookNode(Book book)
    {
        Data = book;
    }
}

/* ================= DOUBLY LINKED LIST ================= */
class LibraryDoublyLinkedList
{
    private BookNode head;
    private BookNode tail;

    /* ---------- ADD OPERATIONS ---------- */
    public void AddAtBeginning()
    {
        Book book = ReadBook();
        BookNode node = new BookNode(book);

        if (head == null)
        {
            head = tail = node;
            return;
        }

        node.Next = head;
        head.Prev = node;
        head = node;
    }

    public void AddAtEnd()
    {
        Book book = ReadBook();
        BookNode node = new BookNode(book);

        if (tail == null)
        {
            head = tail = node;
            return;
        }

        tail.Next = node;
        node.Prev = tail;
        tail = node;
    }

    public void AddAtPosition()
    {
        Console.Write("Enter position: ");
        int pos = int.Parse(Console.ReadLine());

        if (pos <= 1 || head == null)
        {
            AddAtBeginning();
            return;
        }

        Book book = ReadBook();
        BookNode node = new BookNode(book);

        BookNode temp = head;
        for (int i = 1; i < pos - 1 && temp.Next != null; i++)
            temp = temp.Next;

        node.Next = temp.Next;
        node.Prev = temp;

        if (temp.Next != null)
            temp.Next.Prev = node;
        else
            tail = node;

        temp.Next = node;
    }

    /* ---------- REMOVE ---------- */
    public void RemoveById()
    {
        Console.Write("Enter Book ID to remove: ");
        int id = int.Parse(Console.ReadLine());

        BookNode temp = head;

        while (temp != null)
        {
            if (temp.Data.BookId == id)
            {
                if (temp.Prev != null)
                    temp.Prev.Next = temp.Next;
                else
                    head = temp.Next;

                if (temp.Next != null)
                    temp.Next.Prev = temp.Prev;
                else
                    tail = temp.Prev;

                Console.WriteLine("Book removed.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Book not found.");
    }

    /* ---------- SEARCH ---------- */
    public void SearchByTitle()
    {
        Console.Write("Enter Book Title: ");
        string title = Console.ReadLine();

        BookNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                PrintBook(temp.Data);
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("Book not found.");
    }

    public void SearchByAuthor()
    {
        Console.Write("Enter Author Name: ");
        string author = Console.ReadLine();

        BookNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Data.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                PrintBook(temp.Data);
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("Book not found.");
    }

    /* ---------- UPDATE ---------- */
    public void UpdateAvailability()
    {
        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());

        BookNode temp = head;
        while (temp != null)
        {
            if (temp.Data.BookId == id)
            {
                temp.Data.IsAvailable = !temp.Data.IsAvailable;
                Console.WriteLine("Availability status updated.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Book not found.");
    }

    /* ---------- DISPLAY ---------- */
    public void DisplayForward()
    {
        BookNode temp = head;
        if (temp == null)
        {
            Console.WriteLine("Library is empty.");
            return;
        }

        while (temp != null)
        {
            PrintBook(temp.Data);
            temp = temp.Next;
        }
    }

    public void DisplayReverse()
    {
        BookNode temp = tail;
        if (temp == null)
        {
            Console.WriteLine("Library is empty.");
            return;
        }

        while (temp != null)
        {
            PrintBook(temp.Data);
            temp = temp.Prev;
        }
    }

    /* ---------- COUNT ---------- */
    public void CountBooks()
    {
        int count = 0;
        BookNode temp = head;

        while (temp != null)
        {
            count++;
            temp = temp.Next;
        }

        Console.WriteLine($"Total Books: {count}");
    }

    /* ---------- HELPERS ---------- */
    private Book ReadBook()
    {
        Console.Write("Book ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Author: ");
        string author = Console.ReadLine();

        Console.Write("Genre: ");
        string genre = Console.ReadLine();

        Console.Write("Available (true/false): ");
        bool available = bool.Parse(Console.ReadLine());

        return new Book(id, title, author, genre, available);
    }

    private void PrintBook(Book b)
    {
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"ID        : {b.BookId}");
        Console.WriteLine($"Title     : {b.Title}");
        Console.WriteLine($"Author    : {b.Author}");
        Console.WriteLine($"Genre     : {b.Genre}");
        Console.WriteLine($"Available : {(b.IsAvailable ? "Yes" : "No")}");
    }
}

/* ================= MAIN ================= */
class Program
{
    static void Main()
    {
        LibraryDoublyLinkedList library = new LibraryDoublyLinkedList();

        while (true)
        {
            Console.WriteLine("\n1 Add Begin  2 Add End  3 Add Pos");
            Console.WriteLine("4 Remove    5 Search Title");
            Console.WriteLine("6 Search Author  7 Update Availability");
            Console.WriteLine("8 Display Forward  9 Display Reverse");
            Console.WriteLine("10 Count Books  0 Exit");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    library.AddAtBeginning();
                    break;
                case 2:
                    library.AddAtEnd();
                    break;
                case 3:
                    library.AddAtPosition();
                    break;
                case 4:
                    library.RemoveById();
                    break;
                case 5:
                    library.SearchByTitle();
                    break;
                case 6:
                    library.SearchByAuthor();
                    break;
                case 7:
                    library.UpdateAvailability();
                    break;
                case 8:
                    library.DisplayForward();
                    break;
                case 9:
                    library.DisplayReverse();
                    break;
                case 10:
                    library.CountBooks();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
