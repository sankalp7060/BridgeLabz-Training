using System;

class SumNaturalNumbersRecursively{
    //Main()
    static void Main(){
        Console.WriteLine("Enter a natural number:- ");
        int n = int.Parse(Console.ReadLine()); //User input

        //Check that the number n is valid or not
        if(n <= 0){
            Console.WriteLine("Not a natural number");
            return;
        }

        int recursiveSum = SumUsingRecursion(n); //Recursive sum
        int formulaSum = SumUsingFormula(n); //Formula sum

        Console.WriteLine("Sum using recursion:- " + recursiveSum);
        Console.WriteLine("Sum using formula:- " + formulaSum);

        if(recursiveSum == formulaSum)
            Console.WriteLine("Both results are correct and equal");
    }

    //Recursive method
    static int SumUsingRecursion(int n){
        if(n == 1)
            return 1;
        return n + SumUsingRecursion(n - 1);
    }

    //Formula method
    static int SumUsingFormula(int n){
        return (n * (n + 1)) / 2;
    }
}
