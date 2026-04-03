using System;

class Product
{
    public string Name;
    public double Price;

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public void Display()
    {
        Console.WriteLine($"{Name} - ${Price}");
    }
}

class Order
{
    public Product[] Products;
    private int count = 0;

    public Order(int capacity)
    {
        Products = new Product[capacity];
    }

    public void AddProduct(Product product)
    {
        if (count < Products.Length)
        {
            Products[count++] = product;
        }
    }

    public void ShowOrder()
    {
        Console.WriteLine("Order contains:");
        for (int i = 0; i < count; i++)
        {
            Products[i].Display();
        }
    }
}

class Customer
{
    public string Name;
    public Order CustomerOrder;

    public Customer(string name, int orderCapacity)
    {
        Name = name;
        CustomerOrder = new Order(orderCapacity);
    }

    public void PlaceOrder(Product product)
    {
        CustomerOrder.AddProduct(product);
        Console.WriteLine($"{Name} added {product.Name} to the order");
    }

    public void ShowOrder()
    {
        Console.WriteLine($"{Name}'s Order:");
        CustomerOrder.ShowOrder();
    }
}

// Demo
class ECommercePlatform
{
    static void Main()
    {
        Product p1 = new Product("Laptop", 1200);
        Product p2 = new Product("Mouse", 25);

        Customer c1 = new Customer("Alice", 5);
        c1.PlaceOrder(p1);
        c1.PlaceOrder(p2);

        c1.ShowOrder();
    }
}
