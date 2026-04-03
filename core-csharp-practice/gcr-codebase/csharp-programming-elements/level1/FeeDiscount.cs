using System;

class FeeDiscount{
    //Main()
    static void Main(String[] args){
        double fee = 125000; //Course fee
        double discountPercent = 10; //Discount offered on a course
        double discount = (fee * discountPercent) / 100; //Total discount that university giving  
        double finalFee = fee - discount; //Fees after the deduction of the discount
        Console.WriteLine($"The discount amount is INR {discount} and final discounted fee is INR {finalFee}"); //Output
    }
}
