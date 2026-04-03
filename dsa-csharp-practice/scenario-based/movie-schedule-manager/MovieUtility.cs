using System;

class MovieUtility : ICinema
{
    private Movie[] movies;
    private int count;

    public MovieUtility(int capacity)
    {
        movies = new Movie[capacity];
        count = 0;
    }

    public void Add(string title, string time)
    {
        if (count >= movies.Length)
        {
            Console.WriteLine("Movie list is full!");
            return;
        }

        Console.Write("Enter movie title: ");
        string title = Console.ReadLine();
        Console.Write("Enter show time: ");
        string time = Console.ReadLine();

        movies[count] = new Movie(title, time);
        count++;
        Console.WriteLine("Movie added successfully.");
    }

    public void SearchMovies(string keyword)
    {
        if (count == 0)
        {
            Console.WriteLine("No movies available to search.");
            return;
        }

        Console.Write("Enter keyword to search: ");
        string keyword = Console.ReadLine();
        bool found = false;

        for (int i = 0; i < count; i++)
        {
            if (movies[i].Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine($"{movies[i].Title} at {movies[i].Time}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No movie found with that keyword.");
        }
    }

    public void DisplayAllMovies()
    {
        if (count == 0)
        {
            Console.WriteLine("No movies available.");
            return;
        }

        Console.WriteLine("All Movies:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{i + 1}. {movies[i].Title} - {movies[i].Time}");
        }
    }
}
