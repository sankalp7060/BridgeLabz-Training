using System;

class Order
{
    public int OrderId { get; set; }
    public string OrderDate { get; set; }
}

class ShippedOrder : Order
{
    public string TrackingNumber { get; set; }
}

class DeliveredOrder : ShippedOrder
{
    public string DeliveryDate { get; set; }

    public string GetOrderStatus()
    {
        return "Delivered";
    }
}

class OrderManagement
{
    static void Main()
    {
        DeliveredOrder order = new DeliveredOrder
        {
            OrderId = 1,
            OrderDate = "01-Jan",
            TrackingNumber = "TRK123",
            DeliveryDate = "05-Jan",
        };

        Console.WriteLine(order.GetOrderStatus());
    }
}
