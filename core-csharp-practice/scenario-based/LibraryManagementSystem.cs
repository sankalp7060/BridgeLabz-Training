using System;

class LibraryManagementSystem
{
    // ================= STORAGE =================
    private static int count = 6;
    private static string[] titles =
    {
        "C Sharp Programming",
        "C++ Progamming",
        "Java Fundamentals",
        "Python Basics",
        "Data Structures",
        "Operating Systems",
    };
    private static string[] authors =
    {
        "Microsoft",
        "Bjarne Stroustrup",
        "James Gosling",
        "Guido van Rossum",
        "Mark Allen",
        "Abraham Silberschatz",
    };
    private static int[] quantity = { 3, 6, 2, 5, 1, 4 };
    private static string[] borrowedBy = new string[20];
    private static DateTime[] issueDate = new DateTime[20];

    // ================= STUDENT STORAGE =================
    private static int studentCount = 0;
    private static string[] studentIds = new string[50];
    private static string[] studentNames = new string[50];
    private static string[] studentPasswords = new string[50];
    private static string loggedInStudent = null;

    // ================= MAIN =================
    static void Main()
    {
        while (true)
        {
            Console.WriteLine(
                "\n========================================================================================================="
            );
            Console.WriteLine("                                       WHO ARE YOU?");
            Console.WriteLine(
                "=========================================================================================================\n"
            );
            Console.WriteLine("                                       1. Student");
            Console.WriteLine("                                       2. Librarian");
            Console.WriteLine("                                       3. Exit\n");
            Console.Write("Select option: ");

            if (!int.TryParse(Console.ReadLine(), out int role))
                continue;

            if (role == 1)
                StudentFlow();
            else if (role == 2)
                LibrarianFlow();
            else if (role == 3)
                return;
        }
    }

    // ================= STUDENT FLOW =================
    private static void StudentFlow()
    {
        Console.WriteLine("\n1. Register\n2. Login");
        Console.Write("Select option: ");
        if (!int.TryParse(Console.ReadLine(), out int choice))
            return;

        if (choice == 1)
            RegisterStudent();
        else if (choice == 2 && LoginStudent())
            StudentMenu();
    }

    private static void RegisterStudent()
    {
        if (studentCount == studentIds.Length)
        {
            Console.WriteLine("Maximum students reached.");
            return;
        }

        Console.Write("Student ID: ");
        string id = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        for (int i = 0; i < studentCount; i++)
            if (studentIds[i] == id)
            {
                Console.WriteLine("Student ID already exists.");
                return;
            }

        Console.Write("Name: ");
        string name = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid Name.");
            return;
        }

        Console.Write("Password: ");
        string pass = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(pass))
        {
            Console.WriteLine("Invalid Password.");
            return;
        }

        studentIds[studentCount] = id;
        studentNames[studentCount] = name;
        studentPasswords[studentCount] = pass;
        studentCount++;

        Console.WriteLine("Registration successful.");
    }

    private static bool LoginStudent()
    {
        Console.Write("Student ID: ");
        string id = Console.ReadLine().Trim();
        Console.Write("Password: ");
        string pass = Console.ReadLine().Trim();

        for (int i = 0; i < studentCount; i++)
            if (studentIds[i] == id && studentPasswords[i] == pass)
            {
                loggedInStudent = studentNames[i];
                return true;
            }

        Console.WriteLine("Invalid credentials.");
        return false;
    }

    private static void StudentMenu()
    {
        while (true)
        {
            ShowStudentMenu();
            if (!int.TryParse(Console.ReadLine(), out int choice))
                continue;

            switch (choice)
            {
                case 1:
                    DisplayBooks();
                    break;
                case 2:
                    SearchBook();
                    break;
                case 3:
                    CheckoutBook();
                    break;
                case 4:
                    ReturnBook();
                    break;
                case 5:
                    ViewMyBooks();
                    break;
                case 6:
                    loggedInStudent = null;
                    return;
            }
        }
    }

    // ================= LIBRARIAN FLOW =================
    private static void LibrarianFlow()
    {
        Console.Write("Librarian ID: ");
        string id = Console.ReadLine().Trim();
        Console.Write("Password: ");
        string pass = Console.ReadLine().Trim();

        if (id != "san@gla" || pass != "123456")
        {
            Console.WriteLine("Unauthorized access.");
            return;
        }

        while (true)
        {
            ShowLibrarianMenu();
            if (!int.TryParse(Console.ReadLine(), out int choice))
                continue;

            switch (choice)
            {
                case 1:
                    DisplayBooks();
                    break;
                case 2:
                    AddBook();
                    break;
                case 3:
                    RemoveBook();
                    break;
                case 4:
                    SortBooks();
                    break;
                case 5:
                    ShowStats();
                    break;
                case 6:
                    return;
            }
        }
    }

    // ================= MENUS =================
    private static void ShowStudentMenu()
    {
        Console.WriteLine(
            "\n========================================================================================================="
        );
        Console.WriteLine("                                       STUDENT MENU");
        Console.WriteLine(
            "=========================================================================================================\n"
        );
        Console.WriteLine("                                       1. Display All Books");
        Console.WriteLine("                                       2. Search Book ");
        Console.WriteLine("                                       3. Checkout Book");
        Console.WriteLine("                                       4. Return Book");
        Console.WriteLine("                                       5. View My Borrowed Books");
        Console.WriteLine("                                       6. Logout\n");
        Console.Write("Select option: ");
    }

    private static void ShowLibrarianMenu()
    {
        Console.WriteLine(
            "\n========================================================================================================="
        );
        Console.WriteLine("                                       LIBRARIAN MENU");
        Console.WriteLine(
            "=========================================================================================================\n"
        );
        Console.WriteLine("                                       1. Display All Books");
        Console.WriteLine("                                       2. Add Book");
        Console.WriteLine("                                       3. Remove Book");
        Console.WriteLine("                                       4. Sort Book");
        Console.WriteLine("                                       5. Statistics");
        Console.WriteLine("                                       6. Logout\n");
        Console.Write("Select option: ");
    }

    // ================= CORE FEATURES =================
    private static void DisplayBooks()
    {
        if (count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        Console.WriteLine("\n==================== BOOK LIST ====================\n");

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Book ID   : {i}");
            Console.WriteLine($"Title     : {titles[i]}");
            Console.WriteLine($"Author    : {authors[i]}");
            Console.WriteLine($"Quantity  : {quantity[i]}");
            Console.WriteLine($"Status    : {(quantity[i] > 0 ? "Available" : "Out of Stock")}");
            Console.WriteLine("--------------------------------------------------");
        }
    }

    private static void SearchBook()
    {
        Console.Write("Enter title keyword: ");
        string key = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(key))
            return;

        for (int i = 0; i < count; i++)
            if (titles[i].IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0)
                Console.WriteLine($"ID:{i} | {titles[i]} | Qty:{quantity[i]}");
    }

    private static void CheckoutBook()
    {
        Console.Write("Book ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id) || id < 0 || id >= count)
            return;
        if (quantity[id] == 0 || borrowedBy[id] == loggedInStudent)
            return;

        quantity[id]--;
        borrowedBy[id] = loggedInStudent;
        issueDate[id] = DateTime.Now;

        Console.WriteLine("Book issued successfully.");
    }

    private static void ReturnBook()
    {
        Console.Write("Book ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id) || id < 0 || id >= count)
            return;
        if (borrowedBy[id] != loggedInStudent)
            return;

        int days = (DateTime.Now - issueDate[id]).Days;
        if (days > 7)
            Console.WriteLine($"Fine: ₹{(days - 7) * 5}");

        borrowedBy[id] = null;
        quantity[id]++;
    }

    private static void AddBook()
    {
        if (count == titles.Length)
        {
            Array.Resize(ref titles, titles.Length * 2);
            Array.Resize(ref authors, authors.Length * 2);
            Array.Resize(ref quantity, quantity.Length * 2);
            Array.Resize(ref borrowedBy, borrowedBy.Length * 2);
            Array.Resize(ref issueDate, issueDate.Length * 2);
        }

        Console.Write("Title: ");
        string title = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Invalid title.");
            return;
        }

        Console.Write("Author: ");
        string author = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(author))
        {
            Console.WriteLine("Invalid author.");
            return;
        }

        Console.Write("Quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }

        titles[count] = title;
        authors[count] = author;
        quantity[count] = qty;
        borrowedBy[count] = null;
        issueDate[count] = DateTime.MinValue;

        count++;
        Console.WriteLine("Book added successfully.");
    }

    private static void RemoveBook()
    {
        Console.Write("Book ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id) || id < 0 || id >= count)
        {
            Console.WriteLine("Invalid Book ID.");
            return;
        }

        for (int i = id; i < count - 1; i++)
        {
            titles[i] = titles[i + 1];
            authors[i] = authors[i + 1];
            quantity[i] = quantity[i + 1];
            borrowedBy[i] = borrowedBy[i + 1];
            issueDate[i] = issueDate[i + 1];
        }

        titles[count - 1] = null;
        authors[count - 1] = null;
        quantity[count - 1] = 0;
        borrowedBy[count - 1] = null;
        issueDate[count - 1] = DateTime.MinValue;

        count--;
        Console.WriteLine("Book removed successfully.");
    }

    private static void SortBooks()
    {
        for (int i = 0; i < count - 1; i++)
        for (int j = i + 1; j < count; j++)
            if (string.Compare(titles[i], titles[j], true) > 0)
                Swap(i, j);
    }

    private static void Swap(int i, int j)
    {
        (titles[i], titles[j]) = (titles[j], titles[i]);
        (authors[i], authors[j]) = (authors[j], authors[i]);
        (quantity[i], quantity[j]) = (quantity[j], quantity[i]);
        (borrowedBy[i], borrowedBy[j]) = (borrowedBy[j], borrowedBy[i]);
        (issueDate[i], issueDate[j]) = (issueDate[j], issueDate[i]);
    }

    private static void ShowStats()
    {
        int totalBooks = 0;
        int issuedBooks = 0;

        for (int i = 0; i < count; i++)
        {
            totalBooks += quantity[i];
            if (!string.IsNullOrEmpty(borrowedBy[i]))
                issuedBooks += 1;
        }

        Console.WriteLine($"Total Book Types      : {count}");
        Console.WriteLine($"Total Available Books : {totalBooks}");
        Console.WriteLine($"Total Issued Books    : {issuedBooks}");
    }

    private static void ViewMyBooks()
    {
        Console.WriteLine($"\nBooks issued to {loggedInStudent}:\n");
        bool found = false;
        for (int i = 0; i < count; i++)
        {
            if (borrowedBy[i] == loggedInStudent)
            {
                Console.WriteLine($"Book ID   : {i}");
                Console.WriteLine($"Title     : {titles[i]}");
                Console.WriteLine($"Author    : {authors[i]}");
                Console.WriteLine($"Issued On : {issueDate[i]:dd-MM-yyyy}");
                Console.WriteLine("--------------------------------------------------");
                found = true;
            }
        }
        if (!found)
            Console.WriteLine("No books currently issued.");
    }
}
