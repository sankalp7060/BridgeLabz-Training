using System;

class NotificationService
{
    public void Send() => Console.WriteLine("Sending notification");
}

class Order
{
    private NotificationService notification = new NotificationService();

    public void PlaceOrder()
    {
        Console.WriteLine("Order placed");
        notification.Send(); // delegation
    }
}

class Delegation
{
    static void Main()
    {
        Order o = new Order();
        o.PlaceOrder();
    }
}
