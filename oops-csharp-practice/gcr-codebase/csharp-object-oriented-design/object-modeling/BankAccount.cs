using System;

class Customer
{
    public string Name;
    public double Balance;

    public Customer(string name, double initialBalance)
    {
        Name = name;
        Balance = initialBalance;
    }

    public void ViewBalance()
    {
        Console.WriteLine($"{Name}'s Balance: ${Balance}");
    }
}

class Bank
{
    public string BankName;
    public Customer[] Customers;
    private int count = 0;

    public Bank(string bankName, int capacity)
    {
        BankName = bankName;
        Customers = new Customer[capacity];
    }

    public void OpenAccount(Customer customer)
    {
        if (count < Customers.Length)
        {
            Customers[count++] = customer;
            Console.WriteLine($"{customer.Name} opened an account in {BankName}");
        }
        else
        {
            Console.WriteLine("Bank capacity full!");
        }
    }

    public void ShowAllCustomers()
    {
        Console.WriteLine($"Customers in {BankName}:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(Customers[i].Name);
        }
    }
}

// Demo
class BankAccount
{
    static void Main()
    {
        Bank bank = new Bank("Global Bank", 3);

        Customer c1 = new Customer("Alice", 1000);
        Customer c2 = new Customer("Bob", 2000);

        bank.OpenAccount(c1);
        bank.OpenAccount(c2);

        bank.ShowAllCustomers();

        c1.ViewBalance();
        c2.ViewBalance();
    }
}
