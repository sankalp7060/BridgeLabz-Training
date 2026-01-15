using System;

sealed class MenuManager
{
    public void Menu()
    {
        ITabManager tabManager = new TabManagerUtility();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n===== BrowserBuddy Menu =====");
            Console.WriteLine("1. Open New Tab");
            Console.WriteLine("2. Visit New Page");
            Console.WriteLine("3. Back");
            Console.WriteLine("4. Forward");
            Console.WriteLine("5. Display Current Page");
            Console.WriteLine("6. Close Tab");
            Console.WriteLine("7. Restore Closed Tab");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    tabManager.Open();
                    break;

                case "2":
                    tabManager.Visit();
                    break;

                case "3":
                    tabManager.Back();
                    break;

                case "4":
                    tabManager.Forward();
                    break;

                case "5":
                    tabManager.DisplayCurrentTab();
                    break;

                case "6":
                    tabManager.Close();
                    break;

                case "7":
                    tabManager.RestoreClosedTab();
                    break;

                case "8":
                    exit = true;
                    Console.WriteLine("Exiting BrowserBuddy...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
