using System;

class NumberAnalyzer{
    //Main()
    static void Main(){
        int[] numbers = new int[5]; //Array to store numbers

        for(int i = 0; i < numbers.Length; i++){
            Console.WriteLine("Enter number:- ");
            numbers[i] = int.Parse(Console.ReadLine()); //User given number

            if(IsPositive(numbers[i])){
                if(IsEven(numbers[i]))
                    Console.WriteLine("Positive Even");
                else
                    Console.WriteLine("Positive Odd");
            }else{
                Console.WriteLine("Negative");
            }
        }

        int compareResult = Compare(numbers[0], numbers[4]); //Compare first and last
        Console.WriteLine("Comparison Result:- " + compareResult);
    }

    //Method to check positive number
    static bool IsPositive(int number){
        return number >= 0;
    }

    //Method to check even number
    static bool IsEven(int number){
        return number % 2 == 0;
    }

    //Method to compare two numbers
    static int Compare(int number1, int number2){
        if(number1 > number2) return 1;
        if(number1 == number2) return 0;
        return -1;
    }
}
