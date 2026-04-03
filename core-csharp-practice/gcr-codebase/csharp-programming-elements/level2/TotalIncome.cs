using System;

class TotalIncome{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter salary: ");
        double salary = double.Parse(Console.ReadLine()); //User given salary value
        Console.Write("Enter bonus: ");
        double bonus = double.Parse(Console.ReadLine()); //User given bonus value
        double totalIncome = salary + bonus; //formula to calculate total income
        Console.WriteLine("The salary is INR " + salary + " and bonus is INR " + bonus + ". Hence Total Income is INR " + totalIncome); //Output
    }
}
