using System;

class Payment
{
    public virtual void Pay() => Console.WriteLine("Generic payment");
}

class CardPayment : Payment
{
    public override void Pay() => Console.WriteLine("Card payment");
}

class Polymorphism
{
    static void Main()
    {
        Payment p = new CardPayment();
        p.Pay();
    }
}
