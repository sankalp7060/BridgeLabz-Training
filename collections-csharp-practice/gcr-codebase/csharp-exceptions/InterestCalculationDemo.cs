using System;

class InterestCalculationDemo
{
    static double CalculateInterest(double amount, double rate, int years)
    {
        if (amount < 0 || rate < 0)
        {
            throw new ArgumentException();
        }

        return (amount * rate * years) / 100;
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Rate: ");
            double rate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Years: ");
            int years = Convert.ToInt32(Console.ReadLine());

            double interest = CalculateInterest(amount, rate, years);
            Console.WriteLine("Calculated Interest: " + interest);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid input: Amount and rate must be positive");
        }
    }
}
