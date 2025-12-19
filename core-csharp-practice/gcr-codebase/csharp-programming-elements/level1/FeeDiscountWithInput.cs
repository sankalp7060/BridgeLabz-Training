using System;

class FeeDiscountWithInput{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter fee: ");
        double fee = double.Parse(Console.ReadLine()); //User given fee that has to be submitted in the university
        Console.Write("Enter discount percent: ");
        double discountPercent = double.Parse(Console.ReadLine()); //Discount given by the university on the course
        double discount = (fee * discountPercent) / 100; //Formula to calculate discount
        double finalFee = fee - discount; //Calcuting fees after the discount
        Console.WriteLine($"The discount amount is INR {discount} and final discounted fee is INR {finalFee}"); //Output
    }
}
