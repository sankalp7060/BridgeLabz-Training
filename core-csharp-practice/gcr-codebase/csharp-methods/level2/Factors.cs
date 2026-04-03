using System;

class FactorsCalculator{
    //Main()
    static void Main(){
        Console.WriteLine("Enter a number:- ");
        int number = int.Parse(Console.ReadLine()); //User input number
        int[] factors = FindFactors(number); //Call method to find factors

        Console.WriteLine("Factors of " + number + " are:- ");
        foreach(int factor in factors){
            Console.Write(factor + " "); //Display all factors
        }
        Console.WriteLine(); //For new line

        int sum = CalculateSum(factors); //Sum of factors
        int sumOfSquares = CalculateSumOfSquares(factors); //Sum of squares
        int product = CalculateProduct(factors); //Product of factors

        Console.WriteLine("Sum of factors:- " + sum); //Display sum of factors
        Console.WriteLine("Sum of squares of factors:- " + sumOfSquares); //Display sum of squares of factors
        Console.WriteLine("Product of factors:- " + product); //Display product of all factors
    }

    //Method to find factors and return array
    static int[] FindFactors(int number){

        //Variable to store total factors
        int count = 0;

        //Count total factors using loop
        for(int i = 1; i <= number; i++){
            if(number % i == 0){
                count++; //Count total factors
            }
        }

        int[] factors = new int[count]; //Initialize array to store all factors
        int index = 0;
        for(int i = 1; i <= number; i++){
            if(number % i == 0){
                factors[index] = i; //Store factor in array
                index++;
            }
        }

        return factors; //Return array of factors
    }

    //Method to calculate sum of factors
    static int CalculateSum(int[] factors){
        int sum = 0;
        foreach(int f in factors){
            sum += f;
        }
        return sum;
    }

    //Method to calculate product of factors
    static int CalculateProduct(int[] factors){
        int product = 1;
        foreach(int f in factors){
            product *= f;
        }
        return product;
    }

    //Method to calculate sum of squares of factors
    static int CalculateSumOfSquares(int[] factors){
        int sumSq = 0;
        foreach(int f in factors){
            sumSq += (int)Math.Pow(f, 2); //Use Math.Pow for square
        }
        return sumSq;
    }
}
