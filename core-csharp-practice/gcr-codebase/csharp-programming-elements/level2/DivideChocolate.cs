using System;

class DivideChocolate{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter number of chocolates: ");
        int numberOfChocolates = int.Parse(Console.ReadLine()); //user given number of chocolates
        Console.Write("Enter number of children: ");
        int numberOfChildren = int.Parse(Console.ReadLine()); //user given number of children
        int chocolatesPerChild = numberOfChocolates / numberOfChildren; //number of chocolates tht each children get
        int remainingChocolates = numberOfChocolates % numberOfChildren; //number of remaining chocolate after distribution
        Console.WriteLine("The number of chocolates each child gets is " + chocolatesPerChild + " and the number of remaining chocolates is " + remainingChocolates); //output
    }
}
