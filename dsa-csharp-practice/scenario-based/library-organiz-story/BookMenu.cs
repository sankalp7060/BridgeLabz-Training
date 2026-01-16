using System;

sealed class BookMenu
{
    public void Show()
    {
        IBook library = new BookUtility();

        while (true)
        {
            Console.WriteLine("\n--- Library System ---");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Borrow Book");
            Console.WriteLine("3. Return Book");
            Console.WriteLine("4. Display Library");
            Console.WriteLine("5. Exit");

            Console.Write("Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    library.AddBook();
                    break;

                case 2:
                    library.BorrowBook();
                    break;

                case 3:
                    library.ReturnBook();
                    break;

                case 4:
                    library.DisplayLibrary();
                    break;

                case 5:
                    return;
            }
        }
    }
}
