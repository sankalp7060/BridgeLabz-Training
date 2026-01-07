using System;

/* Movie */
class Movie
{
    public string Title;
    public string Director;
    public int Year;
    public double Rating;

    public Movie(string t, string d, int y, double r)
    {
        Title = t;
        Director = d;
        Year = y;
        Rating = r;
    }
}

/* Node */
class MovieNode
{
    public Movie Data;
    public MovieNode Next,
        Prev;

    public MovieNode(Movie m)
    {
        Data = m;
    }
}

/* Interface */
interface IMovieList
{
    void AddAtPosition();
    void RemoveByTitle();
    void SearchByDirector();
    void SearchByRating();
    void DisplayForward();
    void DisplayReverse();
    void UpdateRating();
}

/* Implementation */
class MovieDoublyLinkedListImpl : IMovieList
{
    MovieNode head,
        tail;

    public void AddAtPosition()
    {
        Movie m = ReadMovie();
        MovieNode n = new MovieNode(m);

        Console.Write("Position: ");
        int pos = int.Parse(Console.ReadLine());

        if (head == null || pos <= 1)
        {
            n.Next = head;
            if (head != null)
                head.Prev = n;
            head = n;
            if (tail == null)
                tail = n;
            return;
        }

        MovieNode t = head;
        for (int i = 1; i < pos - 1 && t.Next != null; i++)
            t = t.Next;

        n.Next = t.Next;
        if (t.Next != null)
            t.Next.Prev = n;
        else
            tail = n;
        t.Next = n;
        n.Prev = t;
    }

    public void RemoveByTitle()
    {
        Console.Write("Title: ");
        string title = Console.ReadLine();

        MovieNode t = head;
        while (t != null)
        {
            if (t.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (t.Prev != null)
                    t.Prev.Next = t.Next;
                else
                    head = t.Next;

                if (t.Next != null)
                    t.Next.Prev = t.Prev;
                else
                    tail = t.Prev;

                Console.WriteLine("Removed");
                return;
            }
            t = t.Next;
        }
        Console.WriteLine("Not found");
    }

    public void SearchByDirector()
    {
        Console.Write("Director: ");
        string d = Console.ReadLine();
        MovieNode t = head;
        while (t != null)
        {
            if (t.Data.Director.Equals(d, StringComparison.OrdinalIgnoreCase))
                Print(t.Data);
            t = t.Next;
        }
    }

    public void SearchByRating()
    {
        Console.Write("Rating: ");
        double r = double.Parse(Console.ReadLine());
        MovieNode t = head;
        while (t != null)
        {
            if (t.Data.Rating == r)
                Print(t.Data);
            t = t.Next;
        }
    }

    public void DisplayForward()
    {
        MovieNode t = head;
        while (t != null)
        {
            Print(t.Data);
            t = t.Next;
        }
    }

    public void DisplayReverse()
    {
        MovieNode t = tail;
        while (t != null)
        {
            Print(t.Data);
            t = t.Prev;
        }
    }

    public void UpdateRating()
    {
        Console.Write("Title: ");
        string title = Console.ReadLine();
        MovieNode t = head;
        while (t != null)
        {
            if (t.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("New Rating: ");
                t.Data.Rating = double.Parse(Console.ReadLine());
                return;
            }
            t = t.Next;
        }
    }

    Movie ReadMovie()
    {
        Console.Write("Title: ");
        string t = Console.ReadLine();
        Console.Write("Director: ");
        string d = Console.ReadLine();
        Console.Write("Year: ");
        int y = int.Parse(Console.ReadLine());
        Console.Write("Rating: ");
        double r = double.Parse(Console.ReadLine());
        return new Movie(t, d, y, r);
    }

    void Print(Movie m)
    {
        Console.WriteLine($"{m.Title} | {m.Director} | {m.Year} | {m.Rating}");
    }
}

/* Main */
class MovieManagementSystem
{
    static void Main()
    {
        IMovieList list = new MovieDoublyLinkedListImpl();
        while (true)
        {
            Console.WriteLine(
                "\n1 Add \n2 Remove \n3 Search Dir \n4 Search Rating \n5 Forward \n6 Reverse \n7 Update \n0 Exit"
            );
            int c = int.Parse(Console.ReadLine());
            if (c == 0)
                break;

            switch (c)
            {
                case 1:
                    list.AddAtPosition();
                    break;
                case 2:
                    list.RemoveByTitle();
                    break;
                case 3:
                    list.SearchByDirector();
                    break;
                case 4:
                    list.SearchByRating();
                    break;
                case 5:
                    list.DisplayForward();
                    break;
                case 6:
                    list.DisplayReverse();
                    break;
                case 7:
                    list.UpdateRating();
                    break;
            }
        }
    }
}
