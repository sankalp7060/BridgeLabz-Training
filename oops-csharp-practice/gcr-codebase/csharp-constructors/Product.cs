using System;

class Product
{
    string productName;
    double price;
    static int totalProducts = 0;

    public Product(string name, double price)
    {
        productName = name;
        this.price = price;
        totalProducts++;
    }

    public void DisplayProductDetails()
    {
        Console.WriteLine($"{productName} - ₹{price}");
    }

    public static void DisplayTotalProducts()
    {
        Console.WriteLine($"Total Products: {totalProducts}");
    }

    static void Main()
    {
        Product p1 = new Product("Laptop", 50000);
        Product p2 = new Product("Phone", 20000);

        p1.DisplayProductDetails();
        Product.DisplayTotalProducts();
    }
}
