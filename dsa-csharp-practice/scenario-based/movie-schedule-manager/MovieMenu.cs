using System;

sealed class MovieMenu
{
    private MovieUtility movieManager;

    public MovieMenu(MovieUtility manager)
    {
        movieManager = manager;
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nCinemaTime Menu");
            Console.WriteLine("1. Add Movie");
            Console.WriteLine("2. View All Movies");
            Console.WriteLine("3. Search Movie");
            Console.WriteLine("4. Exit");
            Console.Write("Choose option: ");

            string input = Console.ReadLine();
            int choice;
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    movieManager.Add();
                    break;

                case 2:
                    movieManager.DisplayAllMovies();
                    break;

                case 3:
                    movieManager.SearchMovies();
                    break;

                case 4:
                    Console.WriteLine("Exiting menu...");
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
