using System;

class Product
{
    public static double Discount = 10;
    public string ProductName;
    public double Price;
    public int Quantity;
    public readonly int ProductID;

    public Product(string productName, double price, int quantity, int productID)
    {
        this.ProductName = productName;
        this.Price = price;
        this.Quantity = quantity;
        this.ProductID = productID;
    }

    public static void UpdateDiscount(double newDiscount)
    {
        Discount = newDiscount;
    }

    public void Display(object obj)
    {
        if (obj is Product)
        {
            Console.WriteLine(
                $"{ProductName}, ID: {ProductID}, Price: {Price}, Discount: {Discount}%"
            );
        }
    }

    static void Main()
    {
        Product p = new Product("Laptop", 50000, 1, 101);
        UpdateDiscount(15);
        p.Display(p);
    }
}
