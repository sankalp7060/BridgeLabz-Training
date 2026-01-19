using System;
using System.Collections.Generic;

// Abstract base class for all product categories
public abstract class ProductCategory
{
    public string Name { get; set; }

    protected ProductCategory(string name)
    {
        Name = name;
    }
}

// Example categories
public class BookCategory : ProductCategory
{
    public BookCategory(string name)
        : base(name) { }
}

public class ClothingCategory : ProductCategory
{
    public ClothingCategory(string name)
        : base(name) { }
}

// Generic Product class with constraint T : ProductCategory
public class Product<T>
    where T : ProductCategory
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public T Category { get; set; }

    public Product(string productName, double price, T category)
    {
        ProductName = productName;
        Price = price;
        Category = category;
    }

    public void DisplayProduct()
    {
        Console.WriteLine($"Product: {ProductName}, Price: {Price:C}, Category: {Category.Name}");
    }
}

// Generic methods for discount
public static class ProductHelper
{
    // Apply discount to any product
    public static void ApplyDiscount<T>(T product, double percentage)
        where T : Product<ProductCategory>
    {
        if (percentage < 0 || percentage > 100)
        {
            Console.WriteLine("Invalid discount percentage.");
            return;
        }

        product.Price -= product.Price * (percentage / 100);
        Console.WriteLine(
            $"Discount of {percentage}% applied to {product.ProductName}. New Price: {product.Price:C}"
        );
    }
}

// Main Program
class DynamicOnlineMarketPlace
{
    static void Main()
    {
        // Book products
        Product<BookCategory> book1 = new Product<BookCategory>(
            "C# Programming",
            500,
            new BookCategory("Programming")
        );
        Product<BookCategory> book2 = new Product<BookCategory>(
            "Data Structures",
            600,
            new BookCategory("Education")
        );

        // Clothing products
        Product<ClothingCategory> shirt = new Product<ClothingCategory>(
            "T-Shirt",
            300,
            new ClothingCategory("Casual Wear")
        );
        Product<ClothingCategory> jeans = new Product<ClothingCategory>(
            "Jeans",
            1200,
            new ClothingCategory("Denim")
        );

        // Display products
        Console.WriteLine("--- Products ---");
        book1.DisplayProduct();
        book2.DisplayProduct();
        shirt.DisplayProduct();
        jeans.DisplayProduct();

        // Apply discounts
        Console.WriteLine("\n--- Applying Discounts ---");
        ProductHelper.ApplyDiscount(book1, 10); // 10% discount
        ProductHelper.ApplyDiscount(jeans, 15); // 15% discount
    }
}
