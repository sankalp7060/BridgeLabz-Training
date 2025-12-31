using System;

public class UserInterface
{
    private AccountDatabase database;

    public UserInterface(AccountDatabase db)
    {
        database = db;
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Welcome to Banking App =====");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            if (choice == "3")
                break;

            switch (choice)
            {
                case "1":
                    Register();
                    break;
                case "2":
                    Login();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    Console.ReadKey();
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Banking App!");
    }

    private void Register()
    {
        Console.Clear();
        Console.WriteLine("===== Register =====");
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        Console.Write("Enter initial deposit: ");
        double deposit;
        while (!double.TryParse(Console.ReadLine(), out deposit) || deposit < 0)
        {
            Console.Write("Invalid amount! Enter again: ");
        }

        BankAccount account = database.AddAccount(name, password, deposit);
        if (account != null)
        {
            Console.WriteLine("Registration successful!");
            Console.WriteLine("Your account number is: " + account.AccountNumber);
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void Login()
    {
        Console.Clear();
        Console.WriteLine("===== Login =====");
        Console.Write("Enter account number: ");
        int accNum;
        while (!int.TryParse(Console.ReadLine(), out accNum))
        {
            Console.Write("Invalid input! Enter account number again: ");
        }

        BankAccount account = database.FindAccount(accNum);
        if (account == null)
        {
            Console.WriteLine("Account not found!");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        if (account.VerifyPassword(password))
        {
            Console.WriteLine("Login successful!");
            Console.ReadKey();
            ShowMenu(account);
        }
        else
        {
            Console.WriteLine("Incorrect password!");
            Console.ReadKey();
        }
    }

    private void ShowMenu(BankAccount account)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Banking Menu =====");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Account Info");
            Console.WriteLine("5. Logout");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            if (choice == "5")
                break;

            switch (choice)
            {
                case "1":
                    Console.Write("Enter deposit amount: ");
                    double dep;
                    while (!double.TryParse(Console.ReadLine(), out dep) || dep <= 0)
                    {
                        Console.Write("Invalid amount! Enter again: ");
                    }
                    account.Deposit(dep);
                    break;

                case "2":
                    Console.Write("Enter withdraw amount: ");
                    double wit;
                    while (!double.TryParse(Console.ReadLine(), out wit) || wit <= 0)
                    {
                        Console.Write("Invalid amount! Enter again: ");
                    }
                    account.Withdraw(wit);
                    break;

                case "3":
                    account.CheckBalance();
                    break;

                case "4":
                    account.ShowAccountInfo();
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
