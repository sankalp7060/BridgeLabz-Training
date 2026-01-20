using System;

sealed class AadharMain
{
    public static void Start()
    {
        Console.Write("Enter storage capacity: ");
        int capacity = int.Parse(Console.ReadLine());

        IAadhar utility = new AadharUtility(capacity);

        while (true)
        {
            Console.WriteLine("\n====== Aadhaar Management System ======");
            Console.WriteLine("1. Add Aadhaar");
            Console.WriteLine("2. Sort Aadhaar Numbers");
            Console.WriteLine("3. Search Aadhaar Number");
            Console.WriteLine("4. Display All Aadhaar Records");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    utility.AddAadharNumber();
                    break;

                case "2":
                    utility.SortAadhar();
                    break;

                case "3":
                    utility.SearchAadhar();
                    break;

                case "4":
                    ((AadharUtility)utility).Display();
                    break;

                case "5":
                    Console.WriteLine("Exiting Program...");
                    return;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }
}
