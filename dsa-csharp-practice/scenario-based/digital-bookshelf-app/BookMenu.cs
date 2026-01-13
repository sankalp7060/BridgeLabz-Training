using System;

sealed class BookMenu
{
    private BookUtility bookUtility;

    public BookMenu(BookUtility utility)
    {
        bookUtility = utility;
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nBook Menu");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Search by Author");
            Console.WriteLine("3. Sort Books Alphabetically");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();
            int choice;

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    bookUtility.AddBook();
                    break;

                case 2:
                    bookUtility.SearchByAuthor();
                    break;

                case 3:
                    bookUtility.SortBooksAlphabetically();
                    break;

                case 4:
                    Console.WriteLine("Exiting Book Menu...");
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
