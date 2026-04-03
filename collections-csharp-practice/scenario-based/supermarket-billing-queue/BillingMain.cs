using System;
using System.Collections.Generic;

sealed class BillingMain
{
    public static void Start()
    {
        ICheckoutService checkout = new CheckoutService();

        // Sample Customers
        Customer c1 = new Customer("Rahul");
        c1.CartItems.Add("Milk");
        c1.CartItems.Add("Bread");

        Customer c2 = new Customer("Anita");
        c2.CartItems.Add("Rice");
        c2.CartItems.Add("Eggs");
        c2.CartItems.Add("Milk");

        checkout.AddCustomer(c1);
        checkout.AddCustomer(c2);

        checkout.DisplayQueue();

        checkout.ProcessNextCustomer();
        checkout.ProcessNextCustomer();

        Console.ReadLine();
    }
}
