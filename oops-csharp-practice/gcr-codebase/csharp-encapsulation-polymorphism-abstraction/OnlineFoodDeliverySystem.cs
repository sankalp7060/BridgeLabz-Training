using System;

interface IDiscountable
{
    double ApplyDiscount();
    string GetDiscountDetails();
}

abstract class FoodItem
{
    public string Name { get; private set; }
    protected double Price { get; private set; }
    protected int Quantity { get; private set; }

    public FoodItem(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public abstract double CalculateTotalPrice();

    public void GetItemDetails()
    {
        Console.WriteLine($"Item: {Name}, Quantity: {Quantity}, Base Price: {Price}");
    }
}

class VegItem : FoodItem, IDiscountable
{
    public VegItem(string name, double price, int quantity)
        : base(name, price, quantity) { }

    public override double CalculateTotalPrice()
    {
        return Price * Quantity;
    }

    public double ApplyDiscount()
    {
        return CalculateTotalPrice() * 0.1;
    }

    public string GetDiscountDetails()
    {
        return "Veg Item Discount: 10%";
    }
}

class NonVegItem : FoodItem, IDiscountable
{
    public NonVegItem(string name, double price, int quantity)
        : base(name, price, quantity) { }

    public override double CalculateTotalPrice()
    {
        double extraCharge = Price * 0.20; // extra charge per item
        return (Price + extraCharge) * Quantity;
    }

    public double ApplyDiscount()
    {
        return CalculateTotalPrice() * 0.2;
    }

    public string GetDiscountDetails()
    {
        return "Non - Veg Item Discount: 20%";
    }
}

class OnlineFoodDeliverySystem
{
    static void Main()
    {
        FoodItem[] items = new FoodItem[3];

        items[0] = new VegItem("Paneer Butter Masala", 250, 2);
        items[1] = new NonVegItem("Chicken Biryani", 300, 1);
        items[2] = new VegItem("Veg Fried Rice", 180, 3);

        Console.WriteLine("Food Order Details:\n");

        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetItemDetails();

            double total = items[i].CalculateTotalPrice();
            double discount = 0;

            if (items[i] is IDiscountable discountable)
            {
                discount = discountable.ApplyDiscount();
                Console.WriteLine(discountable.GetDiscountDetails());
            }

            double finalAmount = total - discount;

            Console.WriteLine(
                $"Total: {total}, Discount: {discount}, Final Amount: {finalAmount}\n"
            );
        }
    }
}
