using System;

class TotalPrice{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter unit price: ");
        double unitPrice = double.Parse(Console.ReadLine()); //User given unit price of a item
        Console.Write("Enter quantity: ");
        int quantity = int.Parse(Console.ReadLine()); //User given quantity value of a item
        double totalPrice = unitPrice * quantity; //Formula to calculate total price of a item 
        Console.WriteLine($"The total purchase price is INR {totalPrice} if the quantity {quantity} and unit price is INR {unitPrice}"); //Output
    }
}
