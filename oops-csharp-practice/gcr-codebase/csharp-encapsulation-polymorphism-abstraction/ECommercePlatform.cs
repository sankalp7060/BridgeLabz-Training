using System;

interface ITaxable
{
    double CalculateTax();
    string GetTaxDetails();
}

abstract class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Price { get; private set; }

    public Product(int id, string name, int price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public abstract double CalculateDiscount();

    public void ShowFinalPrice()
    {
        double discount = CalculateDiscount();
        double tax = 0;

        if (this is ITaxable taxable)
        {
            tax = taxable.CalculateTax();
        }

        double finalPrice = Price + tax - discount;
        Console.WriteLine(
            $"Product: {Name}, Price: {Price}, Tax: {tax}, Discount: {discount}, Final Price: {finalPrice}"
        );
    }
}

class Electronics : Product, ITaxable
{
    public Electronics(int id, string name, int price)
        : base(id, name, price) { }

    public double CalculateTax()
    {
        return Price * 0.18;
    }

    public override double CalculateDiscount()
    {
        return Price * 0.1;
    }

    public string GetTaxDetails()
    {
        return "Electronics GST: 18%";
    }
}

class Clothing : Product, ITaxable
{
    public Clothing(int id, string name, int price)
        : base(id, name, price) { }

    public double CalculateTax()
    {
        return Price * 0.12;
    }

    public override double CalculateDiscount()
    {
        return Price * 0.2;
    }

    public string GetTaxDetails()
    {
        return "Clothing GST: 12%";
    }
}

class Groceries : Product
{
    public Groceries(int id, string name, int price)
        : base(id, name, price) { }

    public override double CalculateDiscount()
    {
        return Price * 0.05;
    }
}

class ECommercePlatform
{
    static void Main()
    {
        Product[] products = new Product[5];

        products[0] = new Electronics(1, "Laptop", 60000);
        products[1] = new Electronics(2, "Smartphone", 30000);
        products[2] = new Clothing(3, "Jeans", 2000);
        products[3] = new Clothing(4, "T-Shirt", 1000);
        products[4] = new Groceries(5, "Rice", 500);

        Console.WriteLine("E-Commerce Final Price Calculation:\n");

        for (int i = 0; i < products.Length; i++)
        {
            products[i].ShowFinalPrice();
        }
    }
}
