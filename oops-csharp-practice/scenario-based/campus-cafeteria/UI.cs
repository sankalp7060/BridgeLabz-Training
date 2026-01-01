using System;

class UI
{
    private CafeteriaService service = new CafeteriaService();

    public void Start()
    {
        Console.Clear();

        Console.WriteLine(
            "========================================================================================================="
        );
        Console.WriteLine();
        Console.WriteLine("                                                Welcome to Our Cafe");
        Console.WriteLine();

        bool isOrder = false;
        bool hasOrdered = false;

        while (true)
        {
            Console.WriteLine(
                "\n========================================================================================================="
            );
            Console.WriteLine(
                isOrder
                    ? "                                         Would you like order more?"
                    : "                                         Would you like to place an order?"
            );

            Console.WriteLine(
                "=========================================================================================================\n"
            );
            Console.WriteLine("                                                     1. Yes");
            Console.WriteLine("                                                     2. No");
            Console.Write("Select option: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Press any key...");
                Console.ReadKey();
                Console.Clear();
                continue;
            }

            Console.Clear();

            switch (choice)
            {
                case 1:
                    isOrder = true;
                    hasOrdered = true;
                    ShowMenu();
                    break;

                case 2:
                    isOrder = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (!isOrder)
                break;
        }

        Console.Clear();
        PrintBill(hasOrdered);
    }

    private void ShowMenu()
    {
        while (true)
        {
            service.DisplayMenu();
            Console.Write("Select option:- ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Press any key...");
                Console.ReadKey();
                Console.Clear();
                continue;
            }

            if (choice == 11)
            {
                Console.Clear();
                break;
            }

            Console.Clear();

            if (!service.ProcessOrder(choice))
            {
                Console.WriteLine("Invalid menu choice.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    private void PrintBill(bool hasOrdered)
    {
        Console.WriteLine(
            "========================================================================================================="
        );
        Console.WriteLine();

        if (hasOrdered)
        {
            Console.WriteLine(
                $"                                             Your total bill is ${service.TotalBill}"
            );
            Console.WriteLine();
        }

        Console.WriteLine("                                              Thank you for coming");
        Console.WriteLine();
        Console.WriteLine(
            "========================================================================================================="
        );
    }
}
