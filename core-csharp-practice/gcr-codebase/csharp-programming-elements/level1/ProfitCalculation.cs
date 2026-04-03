using System;

class ProfitCalculation{
    //Main()
    static void Main(String[] args){
        double cp = 129; //Cost Price
        double sp = 191; //Selling Price
        double profit = sp - cp; //Calculate profit by subtracting cost price from selling price
        double profitPercent = (profit / cp) * 100; //Calculate profit percent by dividing profit by cost price and then multiplied the result by 100
        Console.WriteLine($"The Cost Price is {cp} and Selling Price is {sp}\n" +
                          $"The Profit is {profit} and the Profit Percentage is {profitPercent}"); //Output
    }
}
