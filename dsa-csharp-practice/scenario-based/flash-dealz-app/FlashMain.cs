using System;

public class FlashMain
{
    public static void Start()
    {
        Product[] products = new Product[5];

        products[0] = new Product(101, "Laptop", 35.5);
        products[1] = new Product(102, "Mobile", 60.0);
        products[2] = new Product(103, "Shoes", 45.0);
        products[3] = new Product(104, "Watch", 25.0);
        products[4] = new Product(105, "Headphones", 50.0);

        IProduct productUtility = new ProductUtility();

        Console.WriteLine("Before Sorting:");
        productUtility.Display(products);

        productUtility.SortProduct(products);

        Console.WriteLine("\nAfter Sorting (Top Discount First):");
        productUtility.Display(products);

        Console.ReadLine();
    }
}
